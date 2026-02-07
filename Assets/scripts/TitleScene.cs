using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{

    public GameObject[] textObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject startText in textObjects)
        {
            startText.SetActive(false);
        }
        StartCoroutine(TitleText());
    }

    IEnumerator TitleText() // when the scene loads this "loads" in the ui elements 
    {
        foreach (GameObject startText in textObjects)
        {
            startText.SetActive(true);
            yield return new WaitForSeconds(.05f);
        }
    }
// this is where all the button linking is going to go
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Minigame()
    {
        SceneManager.LoadScene(2);
    }
}
