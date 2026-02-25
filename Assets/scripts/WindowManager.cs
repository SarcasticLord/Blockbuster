using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{

    public GameObject myComputerWindow;
    public GameObject internetExplorerWindow;

      // open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode"
    void Start()
    {
        myComputerWindow.SetActive(false);
        internetExplorerWindow.SetActive(false);
        
    }
    public void OpenMCwindow() // OPENS SETTINGS WINDOW 
    {
        myComputerWindow.SetActive(true);
    }

    public void CloseMCwindow() // CLOSE WINDOW
    {
        myComputerWindow.SetActive(false);
    }

    public void OpenInternetExplorer() // OPENS internet  WINDOW 
    {
        internetExplorerWindow.SetActive(true);
    }

    public void CloseInternetExplorer() // close internet window
    {
        internetExplorerWindow.SetActive(false);
    }
}
