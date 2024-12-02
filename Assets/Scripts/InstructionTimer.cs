using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownAndFadeOut : MonoBehaviour
{
    // Duration of the countdown in seconds
    public float countdownTime = 2f;
    private TextMeshProUGUI howToJumpText;

    void Start()
    {
        // Find the "HowToJumpText" object in the scene by name and get its TextMeshProUGUI component.
        howToJumpText = GameObject.Find("HowToJumpText")?.GetComponent<TextMeshProUGUI>();

        if (howToJumpText != null)
        {
            // If the text object is found, start the countdown and fade-out coroutine.
            StartCoroutine(CountdownAndFade());
        }
        else
        {
            // Log an error if the text object is not found.
            Debug.LogError("HowToJumpText object it's not in the scene!");
        }
    }

    IEnumerator CountdownAndFade()
    {
        float elapsedTime = 0f;

        // Wait for the countdown duration.
        while (elapsedTime < countdownTime)
        {
            elapsedTime += Time.deltaTime; // Increment the elapsed time.
            yield return null;
        }

        // Fade out the text over a duration of 1 second.
        float fadeDuration = 1f;
        float fadeElapsed = 0f;
        Color originalColor = howToJumpText.color; // Store the original color of the text.

        while (fadeElapsed < fadeDuration)
        {
            fadeElapsed += Time.deltaTime; // Increment the fade-out elapsed time.
            // Linear alpha value from 1 (fully visible) to 0 (fully transparent).
            float alpha = Mathf.Lerp(1f, 0f, fadeElapsed / fadeDuration);
            // Update the text's color with the new alpha value.
            howToJumpText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Whenthe text is fully faded out, destroy the game object.
        Destroy(howToJumpText.gameObject);
    }
}