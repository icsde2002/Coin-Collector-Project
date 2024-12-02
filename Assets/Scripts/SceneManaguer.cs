using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaguer : MonoBehaviour
{
    // Reference to the sound effect that plays when a button is pressed.
    public AudioSource Button_Press;

    // Method to start the game by loading the specified scene.
    public void Play(string Gameplay)
    {
        StartCoroutine(PlaySoundAndLoadScene(Gameplay)); // Play sound and then load the scene.
    }

    // button sound and waiting for it to finish before loading the scene.
    private IEnumerator PlaySoundAndLoadScene(string sceneName)
    {
        // Play the button press sound.
        Button_Press.Play();

        // Wait for the sound clip to finish playing.
        yield return new WaitForSeconds(Button_Press.clip.length);

        // Load the specified scene.
        SceneManager.LoadScene(sceneName);
    }

    // Method to handle the application exit process.
    public void ExitButton()
    {
        // Play the button press sound.
        Button_Press.Play();

        // Close the application.
        Application.Quit();
    }

    void Update()
    {
        // Check if the Escape key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Call the ExitButton method to play the sound and quit the application.
            ExitButton();
        }
    }
}