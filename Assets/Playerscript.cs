using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Playerscript : MonoBehaviour
{
    public Rigidbody rb;
    public float fallThreshold = -5f;
    public int score = 0;
    public Text scoreText;
    public GameObject winpanel;          // The panel with "You Win!" and restart button
    public GameObject restartButton;
    void Start()
    {
        winpanel.SetActive(false);
        UpdateScoreText();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, 500 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-10, 0, 0 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(10, 0, 0 * Time.deltaTime);
        }
    }
    void Update()
    {
        if (transform.position.y < fallThreshold)
            RestartGame();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            RestartGame();
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
        if (score >= 45)
            WinGame();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void WinGame()
    {
        winpanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}