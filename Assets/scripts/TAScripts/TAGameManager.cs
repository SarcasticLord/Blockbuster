using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Analytics;

public class TAGameManager : MonoBehaviour
{
    public static TAGameManager instance;
    
    public List<string> inventory = new List<string>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        
    }
    // Start is called before the first frame update
    void Start()
    {
        Load();
        TANavigationManager.instance.onRestart += ResetGame; // notice no () its not calling it its pointing to it
        
        

    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Terminal"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream aFile = File.Open(Application.persistentDataPath + "/Terminal", FileMode.Open);
            TASaveState gameState = (TASaveState)bf.Deserialize(aFile);
            aFile.Close();

            Room aroom = TANavigationManager.instance.GetRoomByName(gameState.currentRoom);
            if (aroom != null)
                TANavigationManager.instance.SwitchRooms(aroom);

            inventory = gameState.inventory;
        }
        
    }

    public void Save()
    {
        TASaveState gameState = new TASaveState();
        gameState.currentRoom = TANavigationManager.instance.currentRoom.name;
        gameState.inventory = inventory;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream aFile = File.Create(Application.persistentDataPath + "/Terminal");
        Debug.Log(Application.persistentDataPath);
        bf.Serialize(aFile, gameState);
        aFile.Close();
    }

    void ResetGame()
    {
        inventory.Clear();
    }
}
