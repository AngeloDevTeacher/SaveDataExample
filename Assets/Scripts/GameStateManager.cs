using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    protected GameState gameState;
    string desiredPath;
    // UI Reference
    private void Awake()
    {
        desiredPath = Path.Combine(Application.persistentDataPath, "Pinball_Highscore.txt");
    }
    private void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        LoadFromDisk(); // Loads previous Highscore.
        // UI Reference
    }

    public void LoadFromDisk()
    {

        if (File.Exists(desiredPath))
        {
            using (StreamReader streamReader = File.OpenText(desiredPath))
            {
                string jsonString = streamReader.ReadToEnd();

                JsonUtility.FromJsonOverwrite(jsonString, gameState);
            }
        }
    }

    public void SaveToDisk()
    {
        string jsonString = JsonUtility.ToJson(gameState);
        using (StreamWriter streamWriter = File.CreateText(desiredPath))
        {
            streamWriter.Write(jsonString);
        }
    }

}