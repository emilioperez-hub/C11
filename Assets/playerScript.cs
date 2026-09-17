using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    [SerializeField]
    private InputAction movementinput;
    [SerializeField]
    private InputAction jumpInput;
    [SerializeField]
    private InputAction run;
    CharacterController controller;
    private float playerSpeed = 2f;

    private float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool grounded;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        movementinput.Enable();
        jumpInput.Enable();
        run.Enable();
    }
    private void OnDisable()
    {
        movementinput.Disable();
        jumpInput.Disable();
        run.Disable();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (gameManager.instance.isPlaying == true)
        {


            grounded = controller.isGrounded;
            if (grounded)
            {
                if (playerVelocity.y < -2)
                    playerVelocity.y = -1;
            }
            Vector2 Movement = movementinput.ReadValue<Vector2>();
            Vector3 direction = transform.right * Movement.x + transform.forward * Movement.y;
            direction = Vector3.ClampMagnitude(direction, 1);

            if (grounded && jumpInput.triggered)
                playerVelocity.y = Mathf.Sqrt(1.2f * -2 * gravityValue);
            playerVelocity.y += gravityValue * Time.deltaTime;

            Vector3 finalMove = direction * playerSpeed + Vector3.up * playerVelocity.y;

            controller.Move(finalMove * Time.deltaTime);
            if(run.triggered)
            {
                playerSpeed = 4f;
            }
        }
    }
}
