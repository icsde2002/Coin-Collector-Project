using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
    private CharacterController Controller; // Character controller for player movement.
    private Vector3 Velocity; // vector to handle vertical movement.
    private bool Cooldown; // Cooldown beetwen jumps.
    private GameObject LookAt; // Reference point for tilting rotation.
    private int Speed; // Speed for tilting adjustment.
    public GameObject ReferenceJump; // Reference object for upward tilting.
    public GameObject ReferenceFall; // Reference object for downward tilting.
    public TextMeshProUGUI ScoreText; // Score Display.
    private int Score; // Player's current score
    private const string HighScoreKey = "HighScore"; // Saving Highscore.
    public AudioSource Jump_Sound; // Sound effect for jumping.
    public AudioSource Coin_Collected_Sound; // Sound effect for collecting a coin.

    private void Start()
    {
        Controller = gameObject.GetComponent<CharacterController>(); // Initialize character controller.

        // Load the high score at the start
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        Debug.Log("High Score: " + highScore); 
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the "Score" tag.
        if (other.CompareTag("Score"))
        {
            // Increase the score.
            Score++;

            Coin_Collected_Sound.Play(); // Play coin collection sound.
            // Update the score text
            ScoreText.text = "Coins Collected: " + Score.ToString();

            // Destroy the object with the "Score" tag.
            Destroy(other.gameObject);
        }

        // Check if the collider has the "Obstacle" tag.
        if (other.CompareTag("Obstacle"))
        {
            // Save highscore.
            SaveHighScore();
            // Pass current score and hig hhscore to the next scene.
            PlayerPrefs.SetInt("CurrentScore", Score);

            // Changing the scene.
            SceneManager.LoadScene("LostMenu");
        }
    }
    private void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0); // Load high score.
        if (Score > highScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Score); // Save new high score.
        }
    }

    private void Update()
    {
        // Gameplay Score.
        ScoreText.text = "Coins Collected: " + Score.ToString();

        // Bird Movement Code.
        #region Movement

        Velocity.y += -15 * Time.deltaTime; // Apply gravity to the bird's vertical velocity.

        // Checking for multiple inputs: Space, W, Up Arrow, or Left Mouse Click.
        if ((Input.GetKey("space") || Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) && !Cooldown)
        {
            Jump_Sound.Play(); // Play jump sound effect.
            Cooldown = true; // Activate cooldown to prevent multiple jumps.
            Velocity.y = Mathf.Sqrt(60); // Set upward velocity for jump.
            StartCoroutine(CooldownRefresh()); // Start cooldown timer.
        }

        Controller.Move(Velocity * Time.deltaTime); // Move the bird based on calculated velocity

        #endregion

        //Bird Tilting Code.
        #region Tilting

        if (Velocity.y > 0)
        {
            LookAt = ReferenceJump; // Set reference for upward tilt.
            Speed = 5; // Set tilt speed for upward movement.
        }
        else
        {
            LookAt = ReferenceFall; // Set reference for downward tilt.
            Speed = 10; // Set tilt speed for downward movement.
        }

        // Calculate and apply rotation towards the target tilt direction.
        Quaternion LookOnLook = Quaternion.LookRotation(-LookAt.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookOnLook, Speed * Time.deltaTime);

        #endregion
    }
    private IEnumerator CooldownRefresh()
    {
        yield return new WaitForSeconds(0.1f); // cooldown duration.
        Cooldown = false; // Reset cooldown to allow to jump.
    }
}