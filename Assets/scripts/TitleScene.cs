using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{

    public GameObject[] textObjects;
    public GameObject flashingText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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


                        // this is where all the button linking is going to go
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Minigame()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitConf()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }
    

    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
