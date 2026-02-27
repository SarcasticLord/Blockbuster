using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameManager : MonoBehaviour
{

    private int lives = 3;
    private float rollTime = -1f;
    //private float blockblasterTime = -1f;

    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
        
    }

    void Start()
    {
        Load();
        Debug.Log(Application.persistentDataPath);
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

        gameState.rollTime = rollTime;

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

            rollTime = gameState.rollTime;
        }
       
    }

    
}
