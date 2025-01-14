using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public void OnBodyTouched()
    {
        Debug.Log("Body has been touched!");
        GetComponent<Renderer>().material.color = Color.green;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Body has been touched!");
        // Check if the collider belongs to a specific layer, tag, or object
        if (other.name == "Character") // Replace "Player" with the tag you want to detect
        {
            Debug.Log("Body has been touched!");
            OnBodyTouched(); // Trigger the function
        }
    }

    // Optional: Called when another collider exits the trigger
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Body has been touched!");
        if (other.name == "Character")
        {
            Debug.Log("Body is no longer being touched.");
            // Add logic for when the object stops touching
        }
    }
}
