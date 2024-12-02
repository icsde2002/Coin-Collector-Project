using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownAndFadeOut : MonoBehaviour
{
    public float countdownTime = 2f; // Countdown time in seconds
    private TextMeshProUGUI howToJumpText;

    void Start()
    {
        // Find the "HowToJumpText" object in the scene
        howToJumpText = GameObject.Find("HowToJumpText")?.GetComponent<TextMeshProUGUI>();

        if (howToJumpText != null)
        {
            // Start the countdown and fade-out process
            StartCoroutine(CountdownAndFade());
        }
        else
        {
            Debug.LogError("HowToJumpText object not found in the scene!");
        }
    }

    IEnumerator CountdownAndFade()
    {
        float elapsedTime = 0f;

        // Countdown for N seconds
        while (elapsedTime < countdownTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Fade out the text over 1 second
        float fadeDuration = 1f;
        float fadeElapsed = 0f;
        Color originalColor = howToJumpText.color;

        while (fadeElapsed < fadeDuration)
        {
            fadeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, fadeElapsed / fadeDuration);
            howToJumpText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null; // Wait for the next frame
        }

        // Once faded out, destroy the object
        Destroy(howToJumpText.gameObject);
    }
}
