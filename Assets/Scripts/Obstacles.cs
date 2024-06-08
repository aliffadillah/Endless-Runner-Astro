using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private GameObject player;
    public float baseSpeed = 1.0f; // Base speed of the obstacle
    public float speedMultiplier = 0.3f; // Speed increase per score point
    private float currentSpeed;
    private ScoreManager scoreManager; // Reference to the ScoreManager

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager != null)
        {
            // Adjust the speed based on the score
            currentSpeed = baseSpeed + scoreManager.GetScore() * speedMultiplier;
        }

        // Move the obstacle based on the current speed
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            Destroy(player.gameObject);
        }
    }
}
