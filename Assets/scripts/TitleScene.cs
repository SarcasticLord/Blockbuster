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

    IEnumerator TitleText()
    {
        foreach (GameObject startText in textObjects)
        {
            startText.SetActive(true);
            yield return new WaitForSeconds(.05f);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Minigame()
    {
        SceneManager.LoadScene(2);
    }
}
