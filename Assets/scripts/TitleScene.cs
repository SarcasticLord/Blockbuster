using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// this is where the scene changer is and where the ui elements on the title and exit screen are

public class TitleScene : MonoBehaviour
{

    public GameObject[] textObjects;
    public GameObject flashingText;


    void Start()
    {
        foreach (GameObject startText in textObjects)
        {
            startText.SetActive(false);
        }
        StartCoroutine(TitleText());

        
    }

    IEnumerator TitleText() 
    {
        foreach (GameObject startText in textObjects) // when the scene loads this "loads" in the ui elements 
        {
            startText.SetActive(true);
            yield return new WaitForSeconds(.05f);
        }

        while (true) // this flashes text
        {
           flashingText.SetActive(false);
           yield return new WaitForSeconds(.25f);

           flashingText.SetActive(true);
           yield return new WaitForSeconds(.75f); 
        }
    }


                        // open scenes
    public void StartGame() // STARTS BLOCKBUSTER
    {
        SceneManager.LoadScene(1);
    }

    public void Minigame() // START ROLL A MAZE
    {
        SceneManager.LoadScene(2);
    }

    public void Exit() // EXITS THE GAME
    {
        SceneManager.LoadScene(3);
    }

    public void Credits() // OPENS CREDITS
    {
        SceneManager.LoadScene(4);
    }

    public void WindowsOS() // OPENS WINDOWS OS
    {
        SceneManager.LoadScene(5);
    }

    public void OpenLinkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/jackhigh/");
    }

    public void OpenPortfolio()
    {
        Application.OpenURL("https://sarcasticstudios.notion.site/Jack-High-s-Portfolio-29c8836d033781e1a2a3f1b1df0a2b26");
    }

    public void ExitConf()  // when the exit button is clicked
    {
        StartCoroutine(RmText());
    }

    // everything that opens and closes the windows have been moved to the window manager

    
    IEnumerator RmText() 
    {
        Debug.Log("Quit the game");

        foreach (GameObject startText in textObjects) // this unloads the text in exit scene
        {
            
            startText.SetActive(false);
            yield return new WaitForSeconds(.05f);
            
        }
        yield return new WaitForSeconds(.20f);
        Application.Quit();                             // then it exits the game after .5
    } 

    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }
}


// DONT FORGET THE INPUT MANAGER DONT FORGET THE INPUT MANAGER DONT FORGET THE INPUT MANAGER DONT FORGET THE INPUT MANAGER DONT FORGET THE INPUT MANAGER