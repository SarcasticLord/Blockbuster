using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
public int health;
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
            Destroy (gameObject);
            loseTextObject.SetActive(true);
        }
        
    }

}


