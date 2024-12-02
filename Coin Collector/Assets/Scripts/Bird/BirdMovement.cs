using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 Velocity;
    private bool Cooldown;
    private GameObject LookAt;
    private int Speed;
    public GameObject ReferenceJump;
    public GameObject ReferenceFall;
    public TextMeshProUGUI ScoreText;
    private int Score;
    private const string HighScoreKey = "HighScore"; // Key for saving high score
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the "Score" tag
        if (other.CompareTag("Score"))
        {
            // Increment the score
            Score++;

            // Update the score text
            ScoreText.text = "Coins Collected: " + Score.ToString();

            // Destroy the object with the "Score" tag
            Destroy(other.gameObject);
        }

        // Check if the collider has the "Obstacle" tag
        if (other.CompareTag("Obstacle"))
        {
            // Save the high score
            SaveHighScore();

            // Pass current score and high score to the next scene
            PlayerPrefs.SetInt("CurrentScore", Score);

            // Restart the scene
            SceneManager.LoadScene("LostMenu");
        }
    }
    private void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0); // Load high score
        if (Score > highScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Score); // Save new high score
        }
    }

    private void Start()
    {
        Controller = gameObject.GetComponent<CharacterController>();

        // Load the high score at the start (optional: for display purposes)
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        Debug.Log("High Score: " + highScore); // For testing
    }

    private void Update()
    {
        // Gameplay Score
        ScoreText.text = "Coins Collected: " + Score.ToString();


        // Bird Movement Code
        #region Movement

        Velocity.y += -15 * Time.deltaTime;

        // Check for multiple inputs: Space, W, Up Arrow, or Left Mouse Click
        if ((Input.GetKey("space") || Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) && !Cooldown)
        {
            Cooldown = true;
            Velocity.y = Mathf.Sqrt(60);
            StartCoroutine(CooldownRefresh());
        }

        Controller.Move(Velocity * Time.deltaTime);

        #endregion

        //Bird Tilting Code
        #region Tilting

        if (Velocity.y > 0)
        {
            LookAt = ReferenceJump;
            Speed = 5;
        }
        else
        {
            LookAt = ReferenceFall;
            Speed = 10;
        }

        Quaternion LookOnLook = Quaternion.LookRotation(-LookAt.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookOnLook, Speed * Time.deltaTime);

        #endregion
    }
    private IEnumerator CooldownRefresh()
    {
        yield return new WaitForSeconds(0.1f);
        Cooldown = false;
    }
}