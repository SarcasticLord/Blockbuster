using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RollPlayerHealth : MonoBehaviour
{
public int health;
public Timer timer;
public int maxHealth = 10;
public GameObject loseTextObject;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        loseTextObject.SetActive(false);
    }
    public Slider slider;

    public void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;

        if (health <= 0)
        {
            if (timer != null)
            {
                timer.StopTimer();
            }
            loseTextObject.SetActive(true);
            Invoke("RestartRollGame", 2f);
            Destroy (gameObject, 5f);
        }
        
    }

    void RestartRollGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}



