using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{
    public NotificationManager notifManager;

    public GameObject myComputerWindow;
    public GameObject internetExplorerWindow;
    public GameObject statsWindow;
    
    public GameObject filesWindow;
    public GameObject startmenu;
    public GameObject rightClickMenu;
    public GameObject RCNewMenu;
    public GameObject newFolderIcon;
    public GameObject newFolderWindow;
    public RectTransform clickArea;
    public GameObject taskbarFiles;
    public GameObject taskbarComputer;

    public GameObject RCfolderMenu;
    public RectTransform clickAreaFolder;
// work around for the "loading" effect on the windows
// without this and resettext the text would stay forever
    public GameObject[] MCText;
    public GameObject[] InternetText;
    public GameObject[] StatsText;
    public GameObject[] FileWindowText;
    public GameObject[] StartMenuText;
    public GameObject[] NewFolderWindow;


      // open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode"
    void Start()
    {
        //myComputerWindow.SetActive(false);
        //internetExplorerWindow.SetActive(false);
        //statsWindow.SetActive(false);
        
        taskbarFiles.SetActive(false);
        taskbarComputer.SetActive(false);


        ResetText(MCText);
        ResetText(InternetText);
        ResetText(StatsText);
        ResetText(FileWindowText);
        ResetText(StartMenuText);
        ResetText(NewFolderWindow);

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(clickAreaFolder, Input.mousePosition)) // right clickig on the folder opens the delete menu and closes the new menu
            {
                RCfolderMenu.SetActive(true);
                RCNewMenu.SetActive(false);
                RCfolderMenu.transform.position = Input.mousePosition;
            }
            else if (RectTransformUtility.RectangleContainsScreenPoint(clickArea, Input.mousePosition))
            {
                rightClickMenu.SetActive(true);
                rightClickMenu.transform.position = Input.mousePosition;
            }

            // else if (RectTransformUtility.RectangleContainsScreenPoint(RCmaze, Input.mousePosition))
            // {
            //     rightClickMenu.SetActive(true);
            //     rightClickMenu.transform.position = Input.mousePosition;
            // }
             
            
        }

        
    }

    void ResetText(GameObject[] textArray) // keeps the text hidden when the ui isnt active
    {
        foreach (GameObject loadText in textArray)
        {
            loadText.SetActive(false);
        }
    }
    IEnumerator WindowText(GameObject[] textArray) 
    {
        foreach (GameObject loadText in textArray) 
        {
            loadText.SetActive(true);
            yield return new WaitForSeconds(.05f);
        }

    }
    public void OpenMCwindow() // OPENS SETTINGS WINDOW 
    {
        myComputerWindow.SetActive(true);
        taskbarComputer.SetActive(true);

        ResetText(MCText);
        StartCoroutine(WindowText(MCText));
    }

    public void CloseMCwindow() // CLOSE WINDOW
    {
        
        myComputerWindow.SetActive(false);
        taskbarComputer.SetActive(false);

        //notifManager.OpenRollaMazeNotif();

        ResetText(MCText);
    }

    public void OpenInternetExplorer() // OPENS internet  WINDOW 
    {
        
        internetExplorerWindow.SetActive(true);

        ResetText(InternetText);
        StartCoroutine(WindowText(InternetText));
    }

    public void CloseInternetExplorer() // close internet window
    {
        
        internetExplorerWindow.SetActive(false);

        ResetText(InternetText);
    }

    public void OpenStatsWindow() // OPENS stats  WINDOW 
    {
        
        statsWindow.SetActive(true);

        ResetText(StatsText);
        StartCoroutine(WindowText(StatsText));
    }

    public void CloseStatsWindow() // close stats window
    {
        
        statsWindow.SetActive(false);

        ResetText(StatsText);
    }

    

    public void OpenFilesWindow() // OPENS files  WINDOW 
    {
        
        filesWindow.SetActive(true);
        taskbarFiles.SetActive(true);

        ResetText(FileWindowText);
        StartCoroutine(WindowText(FileWindowText));

        
    }

    public void OpenRCNewMenu() // OPENS files  WINDOW 
    {
        
        RCNewMenu.SetActive(true);

        
    }
    public void NewFolderIcon()
    {
        newFolderIcon.SetActive(true);
        rightClickMenu.SetActive(false);
        RCfolderMenu.SetActive(false);
        
    }
    public void DeleteFolderIcon()
    {
        newFolderIcon.SetActive(false);
        rightClickMenu.SetActive(false);
        RCfolderMenu.SetActive(false);
    }

    public void OpenNewFolderWindow() // OPENS files  WINDOW 
    {
        
        newFolderWindow.SetActive(true);

        ResetText(NewFolderWindow);
        StartCoroutine(WindowText(NewFolderWindow));

    }
    public void CloseNewFolderWindow() // close files window
    {
        
        newFolderWindow.SetActive(false);

        ResetText(NewFolderWindow);
    }


    public void CloseFilesWindow() // close files window
    {
        
        filesWindow.SetActive(false);
        taskbarFiles.SetActive(false);

        ResetText(FileWindowText);
    }

    public void OpenStart() // OPENS start  WINDOW 
    {
        
        startmenu.SetActive(true);

        ResetText(StartMenuText);
        StartCoroutine(WindowText(StartMenuText));
    }

    public void CloseStart() // close start window
    {
        
        startmenu.SetActive(false);
        rightClickMenu.SetActive(false);
        RCfolderMenu.SetActive(false);

        ResetText(StartMenuText);
    }
}
