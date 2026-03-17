using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NotificationManager : MonoBehaviour
{
    public GameObject welcomeNotif;
    public GameObject settingdNotif;
    public GameObject rollamazeNotif;
    public GameObject wbRollamazeNotif;
    public GameObject blockblasterNotif;
    public GameObject wbBlockblasterNotif;

    // critical notifs
    
    public GameObject critWelcomeNotif; // glitchy one
    public GameObject welcomeAfterCrit;
    public GameObject whatHappenedNotif;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        if (SaveState.lastScene == "RollaMaze")
        {
            wbRollamazeNotif.SetActive(true);
            welcomeNotif.SetActive(false);
        }

        else if (SaveState.lastScene == "Blockblaster")
        {
            
            wbBlockblasterNotif.SetActive(true);
            welcomeNotif.SetActive(false);
        }

        else if (SaveState.lastScene == "CritError")
        {
            critWelcomeNotif.SetActive(true);
            Invoke("OpenCriticalError", 1f);
 
        }

        else if (SaveState.lastScene == "Title")
        {
            // there is nothing needed here
        }
        else
        {
            Invoke("OpenWelcome", 1f);
        }

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // there are no open things because the player doesent open them only closes them

    public void CloseNotifications() // close welcome window
    {
        
        settingdNotif.SetActive(false);
        rollamazeNotif.SetActive(false);
        wbRollamazeNotif.SetActive(false);
        blockblasterNotif.SetActive(false);
        wbBlockblasterNotif.SetActive(false);
        critWelcomeNotif.SetActive(false);
        whatHappenedNotif.SetActive(false);

    }

    private void OpenWelcome()      // this all jumps around so much i lowk have a headache
    {
        welcomeNotif.SetActive(true);
    }

    public void CloseWelcome()
    {
        welcomeNotif.SetActive(false);
        Invoke("OpenSettings", 1.5f);
    }

    private void OpenSettings()
    {
        settingdNotif.SetActive(true);
        Invoke("OpenRollaMazeNotif", 5f);
    }


    public void OpenRollaMazeNotif()
    {
        Invoke("OpenRollDelay", 1.5f);
    }

    public void OpenRollDelay()
    {
        rollamazeNotif.SetActive(true);
    }

    private void OpenCriticalError()
    {
        welcomeAfterCrit.SetActive(true);
        critWelcomeNotif.SetActive(false);
    }

    public void CloseCritWelcome()
    {
        welcomeAfterCrit.SetActive(false);
        Invoke("OpenWhatHappened", 1.5f);

    }

    private void OpenWhatHappened()
    {
        whatHappenedNotif.SetActive(true);
    }
    
}
