using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000; //default high score value

	// sets the high score if there is one 
    void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }

        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }

    // Use this for initialization
    void Start()
    {
		// nothing needed here
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;

		//stores the new high score
        if (score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }
}
