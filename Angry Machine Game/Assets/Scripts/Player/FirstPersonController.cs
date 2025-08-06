using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float mouseSensitivity = 1f;

    [Header("Gravity")]
    public float gravity = -9.81f;

    [Header("References")]

    public Transform cameraTransform;

    [Header("Cursor")]
    public Texture2D defaultCursor, clickableCursor;

    private CharacterController controller;
    private PlayerInputActions input;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float cameraPitch = 0f;

    bool clickable = false;
     private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        input = new PlayerInputActions();

        input.Player.Enable();

        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += _ => moveInput = Vector2.zero;

        input.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        input.Player.Look.canceled += _ => lookInput = Vector2.zero;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        if (!clickable)
        {
            float x = (Screen.width - defaultCursor.width) / 2;
            float y = (Screen.height - defaultCursor.height) / 2;
            GUI.DrawTexture(new Rect(x, y, defaultCursor.width, defaultCursor.height), defaultCursor);
        }
        else
        {
            float x = (Screen.width - clickableCursor.width) / 2;
            float y = (Screen.height - clickableCursor.height) / 2;
            GUI.DrawTexture(new Rect(x, y, clickableCursor.width, clickableCursor.height), clickableCursor);
        }
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // small downward force to keep grounded
        }

        // Movement
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * moveSpeed * Time.deltaTime);

                // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        

        // Look
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);


        // FPS Interact Raycast
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f)) // 3f = alcance do olhar
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                clickable = true;
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    hit.collider.GetComponent<Interactable>().Interact();
                }
            }
            else
            {
                clickable = false;
            }
        }
        else
        {
            clickable = false;
        }
    }

}