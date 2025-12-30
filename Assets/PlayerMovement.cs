using System.IO.Compression;
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
    public float extraSprintSpeed = 4f;
    public float maxStamina = 100f;
    public float staminaDrainRate = 40f;
    public float staminaRegenRate = 10f;
    private bool sprintKeyHeld;
    public RawImage staminaBar;
    private float currentStamina;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {   
        // SAFETY CHECKS (THIS PREVENTS CRASHES)
        if (controller == null || groundCheck == null) return;

        // Movement + Jumping script
        // (don't ask how it works I just copied from Brackeys)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        sprintKeyHeld = Input.GetKey(KeyCode.LeftShift);
        currentStamina = DataManager.Instance.playerStamina;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Checking condition for sprinting
        if (sprintKeyHeld && currentStamina > 0 && (DataManager.Instance.playerLocation == "MainScene" || DataManager.Instance.playerLocation == "MorningScene"))
        {
            // sprint effect
            sprintVolume.weight = Mathf.MoveTowards(sprintVolume.weight, 1f, 2f * Time.deltaTime);
            controller.Move(move * (speed+extraSprintSpeed) * Time.deltaTime);

            // player is sprinting, so we decrease stamina
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }
        else
        {
            // undo sprint effect
            sprintVolume.weight = Mathf.MoveTowards(sprintVolume.weight, 0f, 3f * Time.deltaTime);
            controller.Move(move * speed * Time.deltaTime);

            // right now player isnt sprinting, so we increase stamina
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        // Correcting stamina if its out of bound
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }

        if (currentStamina < 0)
        {
            currentStamina = 0;
        }

        // Updating stamina bar
        staminaBar.rectTransform.localScale = new Vector3(0.1f, currentStamina/10, 1f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        


        // Playing footsteps audio
        if ((x != 0 || z != 0) && isGrounded == true)
        {
            footstepsAudio.enabled = true;
        }
        else
        {
            footstepsAudio.enabled = false;
        }

        DataManager.Instance.playerStamina = currentStamina;
    }
}
