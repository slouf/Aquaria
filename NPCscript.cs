using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// NPC Script for dialogue and stuff (also prototype [maybe?])
public class NPCscript : MonoBehaviour
{
    // Dialogue panel (insert in unity editor)
    public GameObject dialoguePanel;
    // TextMeshProGUI for dialogue text
    public TextMeshProUGUI dialogueText;
    // array of strings for dialogue
    public string[] dialogue;

    // Integer for index of position of text
    private int index = 0;

    // Speed of text (in seconds i think)
    public float wordSpeed;
    // Boolean for when a player is close
    public bool playerIsClose;


    private void Start()
    {
        // Clears any text in the text box
        dialogueText.text = "";
    }

    // Update is called once per frame
    private void Update()
    {
        // If input E is received and player is close run this
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            // If the textbox isn't already turned on
            if (!dialoguePanel.activeInHierarchy)
            {
                // Turn on panel
                dialoguePanel.SetActive(true);
                // Start the typing coroutine
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                // Call next line method of the text of the story matches the index
                NextLine();
            }

        }
        // If the button Q is pressed and the panel is active, turn it off
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }

    public void RemoveText()
    {
        // Clear any dialogue and reset index and turn off panel
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    // I LOVE COROUTINES
    IEnumerator Typing()
    {
        // goes through every character in the word at index in object dialogue and turns every letter into a character
        foreach (char letter in dialogue[index].ToCharArray())
        {
            // Adds a letter to the text box every wordSpeed seconds (for typing effect)
            dialogueText.text += letter;
            // Waits wordSpeed seconds
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    // goes through the next line in the .ink file (the JSON more specifically)
    public void NextLine()
    {
        // If the index reached end of line, add 1 more and clear text and start typing again
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            // If the index did not reach end of line, remove all text
            RemoveText();
        }
    }

    // Gets called when player enters the box collider of object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the object colliding is a player, true
        if (other.CompareTag("Player"))
        {
            //Set playerIsClose to true
            playerIsClose = true;
            //Turn on panel
            dialoguePanel.SetActive(true);
            // Start typing
            StartCoroutine(Typing());
        }
    }

    // When player leaves the collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // self explanatory
            playerIsClose = false;
            // remove text
            RemoveText();
        }
    }
}