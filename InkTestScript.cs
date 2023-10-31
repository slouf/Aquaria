using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using System;
using System.Reflection;

// Test script for played dialogue using Inkle - www.inklestudios.com/ink/
public class InkTestScript : MonoBehaviour
{
    // JSON for the text asset created by Ink
    public TextAsset inkJSON;
    // Story object from Ink import
    private Story story;

    // Dialogue panel where text will get displayed
    public GameObject dialoguePanel;
    // Dialogue text
    public TextMeshProUGUI dialogueText;

    // Speed at which words appear
    public float wordSpeed;
    // Boolean for when a player can interact
    public bool playerIsClose;

    private void Start()
    {
        // Clears any text currently displayed
        dialogueText.text = "";
        // Creates a new story object with a reference to the JSON
        story = new Story(inkJSON.text);
    }

    private void Update()
    {
        // If the player interacts with object while the player is close
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            // Turn on the panel, start the coroutine "Typing"
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            // Display the next line if panel is already enabled
            else if (dialogueText.text == story.currentText)
            {
                NextLine();
            }

        }
        // Quit button (Q)
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }

    // Displays next line in the Ink hierarchy
    private void NextLine()
    {
        // If the story object has the ability to go on
        if (story.canContinue)
        {
            // Clears old text, starts typing again
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            // If the story cannot continue, remove all text
            RemoveText();
        }
    }

    // Typing effect for text
    IEnumerator Typing()
    {
        
        // Creates an array of characters from a line of text and goes through every letter
        foreach (char letter in story.Continue().ToCharArray())
        {
            // If the player is in range, add to the text, letter by letter
            if (playerIsClose)
            {
                dialogueText.text += letter;
                // Wait *wordSpeed* seconds before typing the next letter
                yield return new WaitForSeconds(wordSpeed);
            }
            
        }
        
    }
    // Removes current text from text box
    private void RemoveText()
    {
        dialogueText.text = "";
        // Resets the Ink story to beginning
        story.ResetState();
        // Turns off panel
        dialoguePanel.SetActive(false);
    }

    // Method gets called when player enters collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set playerIsClose to true when player is in range
            playerIsClose = true;
            // Turn on panel
            dialoguePanel.SetActive(true);
            // Start typing
            StartCoroutine(Typing());
        }
    }
    // When player exits the range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set playerIsClose to false when player leaves
            playerIsClose = false;
            // Remove all current text
            RemoveText();
        }
    }
}
