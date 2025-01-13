using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;


public class LoadSave : MonoBehaviour
{
    public Transform buttonContainer; // The parent object (with Vertical Layout Group)
    public GameObject buttonPrefab;  // The Button Prefab
    private string saveDirectory = Application.dataPath + "/SaveData"; // Directory where saves are stored
    public PlayerData playerData;

    void Start()
    {
        GenerateSaveButtons();
    }

    void ConfigureButtonContainer()
    {
        if (buttonContainer == null)
        {
            Debug.LogError("ButtonContainer is not assigned in the Inspector.");
            return;
        }

        // Add a Vertical Layout Group component if not already present
        VerticalLayoutGroup layoutGroup = buttonContainer.GetComponent<VerticalLayoutGroup>();
        if (layoutGroup == null)
        {
            layoutGroup = buttonContainer.gameObject.AddComponent<VerticalLayoutGroup>();
        }

        // Configure the Vertical Layout Group properties
        layoutGroup.childAlignment = TextAnchor.UpperCenter; // Align children to the top center
        layoutGroup.spacing = 10; // Set spacing between buttons
        layoutGroup.padding = new RectOffset(10, 10, 10, 10); // Set padding (left, right, top, bottom)
        layoutGroup.childForceExpandHeight = false; // Let buttons keep their height
        layoutGroup.childForceExpandWidth = false; // Let buttons keep their width
    }

    void GenerateSaveButtons()
    {
        if (buttonPrefab == null)
        {
            Debug.LogError("ButtonPrefab is not assigned in the Inspector.");
            return; // Exit early to avoid errors
        }

        if (buttonContainer == null)
        {
            Debug.LogError("ButtonContainer is not assigned in the Inspector.");
            return; // Exit early to avoid errors
        }

        // Ensure the save directory exists
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        // Get all save files in the directory
        string[] saveFiles = Directory.GetFiles(saveDirectory, "player*.json");

        // Create a button for each save file
        foreach (string saveFile in saveFiles)
        {
            GameObject button = Instantiate(buttonPrefab, buttonContainer);
            string saveFileName = Path.GetFileNameWithoutExtension(saveFile);

            // Check if the button prefab has a Text component as a child
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText == null)
            {
                Debug.LogError("Text component not found in button prefab.");
                return; // Exit if the Text component is missing
            }

            // Set the button text to the save file name (e.g., player1, player2)
            buttonText.text = saveFileName;

            // Add a click listener to load the save
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => LoadSaves(saveFile));
        }
    }

    public void LoadSaves(string filePath)
    {
        playerData = SaveSystem.LoadPlayer(filePath);
        ApplyPlayerData(playerData);
        SceneManager.LoadScene("TestScene");
    }
    private void ApplyPlayerData(PlayerData myPlayerData)
    {
        Vector2 position;
        position.x = myPlayerData.xPos;
        position.y = myPlayerData.yPos;

        StaticData.health = myPlayerData.health;
        StaticData.position = position;
        StaticData.newData = true;
        // Here add any other fields of interest, do not forget to also add in the StaticData.cs these fields
    }
}
