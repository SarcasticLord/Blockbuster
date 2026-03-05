using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{
    private Rigidbody rb;
    private float movementX;
    private float movementZ;

    
    private int stockCount;
    private int netflixCount;


    public TextMeshProUGUI stockedText;
    public TextMeshProUGUI netflixText;

    public GameObject winTextObject;
    //public GameObject loseTextObject;
    public Timer timer;

    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private string actionMapName = "Game";
    [SerializeField] private string movement = "Move";
    [SerializeField] private string rotation = "rotation";
    [SerializeField] private string jump = "jump";
    [SerializeField] private string sprint = "sprint";

    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

   public Vector2 MovementInput { get; private set; }
   public Vector2 RotationInput { get; private set; }
   public bool JumpInput { get; private set; }
   public bool SprintInput { get; private set; }

    void Awake()
    {
        InputActionMap mapRefrence = playerControls.FindActionMap(actionMapName);
        
        movementAction = mapRefrence.FindAction(movement);
        rotationAction = mapRefrence.FindAction(rotation);
        jumpAction = mapRefrence.FindAction(jump);
        sprintAction = mapRefrence.FindAction(sprint);

        SubscribeActionValuesToInputEvents();

    }

    private void SubscribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;

        jumpAction.performed += inputInfo => JumpInput = true;
        jumpAction.canceled += inputInfo => JumpInput = false;

        sprintAction.performed += inputInfo => SprintInput = true;
        sprintAction.canceled += inputInfo => SprintInput = false;
    }

    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }



    void Start()
    {
        
        
        
        stockCount = 0;
        netflixCount = 0;
        // SetStockedText();
        // SetNetflixText();
        winTextObject.SetActive(false);
        //loseTextObject.SetActive(false);
    }

    void Objectives() 
    {
        stockedText.text = "Stock the shelves: " + stockCount.ToString() + "/10";
        netflixText.text = "Netflix employees stopped: " + netflixCount.ToString() + "/10";

        if (stockCount >= 10 && netflixCount >= 10) // both objectives are done then win the game
        {
            winTextObject.SetActive(true);


            if (timer != null)
            {
                timer.StopTimer();
            }
        }
    }

    void OnTriggerEnter(Collider other) // player hits the pickups
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
        Invoke("Die", 2f);
    }


    void Die() // this should be the thing that restarts the scene and stops the timer 
    {
        GameManager.instance.DecreaseLives();
        Debug.Log("lives: " + GameManager.instance.GetLives());
        SceneManager.LoadScene(0);

        if (timer != null)
        {
            timer.StopTimer();
        }
    }

 
}
