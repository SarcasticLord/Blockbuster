using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{

    public GameObject myComputerWindow;
    public GameObject internetExplorerWindow;
    public GameObject statsWindow;

    public GameObject[] MCText;
    public GameObject[] InternetText;
    public GameObject[] StatsText;


      // open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode" open/close windows in "os mode"
    void Start()
    {
        //myComputerWindow.SetActive(false);
        //internetExplorerWindow.SetActive(false);
        //statsWindow.SetActive(false);

        ResetText(MCText);
        ResetText(InternetText);
        ResetText(StatsText);
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

        ResetText(MCText);
        StartCoroutine(WindowText(MCText));
    }

    public void CloseMCwindow() // CLOSE WINDOW
    {
        
        myComputerWindow.SetActive(false);

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
}
