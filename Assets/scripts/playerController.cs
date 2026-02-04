using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private int stockCount;
    private int netflixCount;

    public float speed = 0;
    public TextMeshProUGUI stockedText;
    public TextMeshProUGUI netflixText;

    public GameObject winTextObject;
    //public GameObject loseTextObject;
    public Timer timer;
    public ParticleSystem confetti;


    void Start()
    {
        rb = GetComponent <Rigidbody>();
        stockCount = 0;
        netflixCount = 0;
        // SetStockedText();
        // SetNetflixText();
        winTextObject.SetActive(false);
        //loseTextObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnMove (InputValue movementValue)
    {
        Vector3 movementVector = movementValue.Get<Vector3>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void Objectives() // when the player gets 10/10 on both netflix and movies they win the game
    {
        stockedText.text = "Stock the shelves: " + stockCount.ToString() + "/10";
        netflixText.text = "Netflix employees stopped: " + netflixCount.ToString() + "/10";

        if (stockCount >= 10 && netflixCount >= 10)
        {
            winTextObject.SetActive(true);

            if (confetti != null)
            {
                confetti.Play();
            }

            if (timer != null)
            {
                timer.StopTimer();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);
            stockCount = stockCount + 1;
            Objectives();

        }


    }

    void OnDestroy() // when the player is killed restart the scene
    {
        if (timer != null)
        {
            timer.StopTimer();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
}
