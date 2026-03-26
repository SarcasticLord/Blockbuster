using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TANavigationManager : MonoBehaviour

{
    public static TANavigationManager instance;

    public Room startingRoom;
    public Room currentRoom;

    public delegate void Restart();
    public event Restart onRestart;

    public Exit toKeyNorth;
    public List<Room> rooms;



    private Dictionary<string, Room> exitRooms = new Dictionary<string, Room>();

    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        currentRoom = startingRoom;
        Unpack();
        TAGameManager.instance.Load();
    }

    void Unpack()
    {
        string description = currentRoom.Description;

        exitRooms.Clear();
        foreach (Exit e in currentRoom.exits)
        {
            if (!e.isHidden)
            {
                description += " " + e.description;
                exitRooms.Add(e.direction.ToString(), e.room);
            }
        }

        TAInputManager.instance.UpdateTerminal(description);

        if (currentRoom.name == "dragon")
        {
            SceneManager.LoadScene(2); // opens the windows scene
        }

    }

    public void GameRestart()
    {
        onRestart.Invoke();             // calling the restsrt event
        currentRoom = startingRoom;     // puts the player back at the start
        toKeyNorth.isHidden = true;
       
        bool isFound = false;
        

        Unpack();
    }
    public void SwitchRooms(Room room)
    {
        currentRoom = room;
        Unpack();
    }
    public bool SwitchRooms(string direction)
    {
        if (exitRooms.ContainsKey(direction))
        {
            if (TAGameManager.instance.inventory.Contains("key") || !getExit(direction).isLocked)
            {
                currentRoom = exitRooms[direction];
                TAInputManager.instance.UpdateTerminal(" Opening " + direction);
                Unpack();
                return true;
            }
            else
                return false;


        }
        return false;

    }
    Exit getExit(string direction)
    {
        foreach (Exit e in currentRoom.exits)
        {
            if (e.direction.ToString() == direction)
                return e;
            
        }
        return null;
    }

    public bool getItem(string item)

    {
        bool isFound = false;
        foreach (string i in currentRoom.items)
        {
            if (i == item)
            {
                isFound = true;
                if(item == "systemData")
                {
                    
                    toKeyNorth.isHidden = false;
                    TAInputManager.instance.UpdateTerminal("Downloading system data...");
                }

                if(item == "eventViewer")
                {
                    
                    TAInputManager.instance.UpdateTerminal("Downloading Event Viewer logs...");
                }

                if(item == "knife")
                {
                    
                    TAInputManager.instance.UpdateTerminal("you picked up the knife!!!");
                }
            }
            
        }
        if (isFound)
        {
            currentRoom.items.Remove(item);
            currentRoom.Description = "You already downloaded these files.";
        }
        return isFound;

    }
    public Room GetRoomByName(string name)
    {
        foreach(Room aroom in rooms)
            if (aroom.name == name)
                return aroom;
        return null;
    }
    
}