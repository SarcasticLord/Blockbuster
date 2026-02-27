using UnityEngine;
using TMPro;

public class RollTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float passedTime;
    bool isRunning = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning) return;
        passedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(passedTime / 60);
        int seconds = Mathf.FloorToInt(passedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void StopTimer()
    {
        isRunning = false;
    }
}
