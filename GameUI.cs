using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text scoreText;

    private bool gameInProgress;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        gameInProgress = true;
        player = FindObjectOfType<Player>();
        player.OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameInProgress == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("rockFallMain");
                print($"Game State: {gameInProgress}, Space Pressed!");
            }
        }
        
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        gameInProgress = false;
        scoreText.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    }
}
