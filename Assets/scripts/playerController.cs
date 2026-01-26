using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour

{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    //public GameObject loseTextObject;
    public Timer timer;
    public ParticleSystem confetti;


    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
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
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() // this also includes the win stuff like the text and confetti and stopping the timer
    {
        countText.text = "Ham sandwiches: " + count.ToString() + "/10";

        if (count >= 10)
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
            count = count + 1;
            SetCountText();

        }
    }

    void OnDestroy()
    {
        if (timer != null)
        {
            timer.StopTimer();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
}
