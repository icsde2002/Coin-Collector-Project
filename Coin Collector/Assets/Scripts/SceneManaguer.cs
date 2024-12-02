using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//adds a new library.
public class SceneManaguer : MonoBehaviour
{
    public void Play(string Gameplay)
    {
        SceneManager.LoadScene(Gameplay);
    }
    public void ExitButton()
    {
        // Close the application
        Application.Quit();
    }
    void Update()
    {
        // if Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Close the application
            Application.Quit();
        }
    }
}
