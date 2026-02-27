using UnityEngine;
using TMPro;

public class StatsController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestRollTime;
    // [SerializeField] TextMeshProUGUI bestBlockblasterTime;

    // [SerializeField] TextMeshProUGUI deaths;
    float passedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float best = RollTimer.instance.passedTime();

        if (best < 0)
        {
            bestRollTime.text = "No Records";
            return;
  
        }

        int minutes = Mathf.FloorToInt(best / 60);
        int seconds = Mathf.FloorToInt(best % 60);

        bestRollTime.text = string.Format("Best Roll a Maze Time: {0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
