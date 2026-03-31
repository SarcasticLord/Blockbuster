 using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{
    private Rigidbody rb;

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

        // this is the stuff that matters

    public Timer timer;
    
    public Transform BoxSnap;
    public Transform BroomSnap;
    private GameObject holdBox;

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

        // just kidding this is the stuff that really matters

    void Start()
    {
        
    }


    void OnTriggerEnter(Collider other) // player hits the pickups
    {

        if (other.gameObject.CompareTag("pickUp") && holdBox == null)
        {
            holdBox = other.gameObject;

            other.gameObject.transform.position = BoxSnap.position;
            other.gameObject.transform.rotation = BoxSnap.rotation;
            other.gameObject.transform.SetParent(BoxSnap);

            other.GetComponent<PickupController>().StopRotating();
            

        }

        if (other.gameObject.CompareTag("broom") && holdBox == null)
        {
            holdBox = other.gameObject;

            other.gameObject.transform.position = BroomSnap.position;
            other.gameObject.transform.rotation = BroomSnap.rotation;
            other.gameObject.transform.SetParent(BroomSnap);

        }

        if (other.gameObject.CompareTag("exit")) // colliding with the wall debug
        {
            SceneManager.LoadScene(2);
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
