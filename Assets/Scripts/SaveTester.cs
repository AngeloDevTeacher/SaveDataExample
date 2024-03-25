using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveTester : MonoBehaviour
{
    GameState currentGameState;
    [SerializeField]int savedHighscore = 0;
    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

        currentGameState = GameObject.FindObjectOfType<GameState>();

        savedHighscore = currentGameState.score; //hack - should be able to read the json without overriding the current state.

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {currentGameState.score}";
    }

    public void IncreaseCurrentScore()
    {
        currentGameState.score += 1;
    }
    public void DecreaseCurrentScore()
    {
        currentGameState.score -= 1;
    }
    public void ResetCurrentScore()
    {
        currentGameState.score = 0;
    }

    public void SaveCurrentScore()
    {
        FindObjectOfType<GameSaveManager>().SaveToDisk();
        savedHighscore = currentGameState.score;
    }
    public void LoadSavedScore()
    {
        FindObjectOfType<GameSaveManager>().LoadFromDisk();
    }

    public void AttemptToSaveScoreIfHighscore()
    {
        if (currentGameState.score > savedHighscore )
        {
            SaveCurrentScore();
        }
    }
}
