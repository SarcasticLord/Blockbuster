using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;

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

   public int stockCount;
   public int netflixCount;
   public int trashCount;


    public TextMeshProUGUI stockedText;
    public TextMeshProUGUI netflixText;
    public TextMeshProUGUI trashText;

    public GameObject winTextObject;
    //public GameObject loseTextObject;
    public Timer timer;
    void Start()
    {
        Load();
        Objectives();
        
        stockCount = 0;
        netflixCount = 0;
        trashCount = 0;

        StockObjective();
        TrashObjective();
        MetflicksObjective();
        
        winTextObject.SetActive(false);
        //loseTextObject.SetActive(false);
    }

    public void Objectives() // when all three conditions are met end the game
    {
        if (stockCount >= 10 && netflixCount >= 50 && trashCount >= 20) 
        {
            
            winTextObject.SetActive(true);

            if (timer != null)
            {
                timer.StopTimer();
            }
        
        }
        
    }

    public void StockObjective() // stocking the shelves    setting the score to the text
    {
        
        stockedText.text = "Stock the shelves: " + stockCount.ToString() + "/10";
        Objectives();
    }

    public void MetflicksObjective() // killing the metflicks employees    setting the score to the text
    {
       
        netflixText.text = "Metflicks employees stopped: " + netflixCount.ToString();
        Objectives();
    }

    public void TrashObjective() // sweeping up the trash    setting the score to the text
    {
        
        trashText.text = "Trash picked up: " + trashCount.ToString() + "/20";
        Objectives();
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

        gameState.stockCount = stockCount;
        gameState.netflixCount = netflixCount;
        gameState.trashCount = trashCount;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream aFile = File.Create(Application.persistentDataPath + "/system");
        bf.Serialize(aFile, gameState);
        aFile.Close();

        
    }

    void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/system"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream aFile = File.Open(Application.persistentDataPath + "/system", FileMode.Open);
            SaveState gameState = (SaveState)bf.Deserialize(aFile);
            aFile.Close();

            stockCount = gameState.stockCount;
            netflixCount = gameState.netflixCount;
            trashCount = gameState.trashCount;

        }
       
    }

    
}
