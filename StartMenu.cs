using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Starts up the game
public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Loads the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
