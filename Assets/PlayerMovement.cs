using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public AudioSource footstepsAudio;

    public Volume sprintVolume; // sprint effects
    public float maxStamina = 100f;
    public float staminaDrainRate = 40f;
    public float staminaRegenRate = 10f;
    private bool sprintKeyHeld;

    public RawImage staminaBar;
    private float currentStamina;

    void Start()
    {
        // Safe default in case DataManager does not exist
        currentStamina = maxStamina;
    }

    void Update()
    {
        // 🔒 HARD SAFETY CHECKS
        if (controller == null || groundCheck == null || staminaBar == null || sprintVolume == null)
            return;

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Sprint input
        sprintKeyHeld = Input.GetKey(KeyCode.LeftShift);

        // 🔒 SAFE DataManager READ
        if (DataManager.Instance != null)
        {
            currentStamina = DataManager.Instance.playerStamina;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Sprinting logic
        if (sprintKeyHeld && currentStamina > 0)
        {
            sprintVolume.weight = Mathf.MoveTowards(sprintVolume.weight, 1f, 2f * Time.deltaTime);
            controller.Move(move * (speed + 4f) * Time.deltaTime);
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }
        else
        {
            sprintVolume.weight = Mathf.MoveTowards(sprintVolume.weight, 0f, 3f * Time.deltaTime);
            controller.Move(move * speed * Time.deltaTime);
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        // Clamp stamina
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        // Update stamina UI
        staminaBar.rectTransform.localScale = new Vector3(0.1f, currentStamina / 10f, 1f);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Footsteps audio
        if ((x != 0 || z != 0) && isGrounded)
        {
            footstepsAudio.enabled = true;
        }
        else
        {
            footstepsAudio.enabled = false;
        }

        // 🔒 SAFE DataManager WRITE
        if (DataManager.Instance != null)
        {
            DataManager.Instance.playerStamina = currentStamina;
        }
    }
}
