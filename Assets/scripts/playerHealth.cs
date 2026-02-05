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

    public void TakeDamage(int amount) // takes damage right
    {
        health -= amount;
        slider.value = health;
        if (health <= 0)
        {
            Destroy (gameObject); // destorys the player, player controller does the rest
            loseTextObject.SetActive(true);
        }
        
    }

}


