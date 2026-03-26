using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{

    private int lives = 3;

    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(instance);

        DontDestroyOnLoad(gameObject);
    }

    void start()
    {
        Load();
    }

    public void DecreaseLives()
    {
        lives--;
    }

    public int GetLives()
    {
        return lives;
    }

    public void Save()
    {
        SaveState gameState = new SaveState();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream aFile = File.Create(Application.persistentDataPath + "/player.save");
        bf.Serialize(aFile, gameState);
        aFile.Close();
    }

    void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/player.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream aFile = File.Open(Application.persistentDataPath + "/player.save", FileMode.Open);
            SaveState gameState = (SaveState)bf.Deserialize(aFile);
            aFile.Close();

        }
       
    }

    
}
