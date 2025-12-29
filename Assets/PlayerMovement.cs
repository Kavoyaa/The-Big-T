using System.IO.Compression;
using UnityEngine;
using UnityEngine.Rendering;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    // SAFETY CHECKS (THIS PREVENTS CRASHES)
    if (controller == null || groundCheck == null)
        return;

    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    if (isGrounded && velocity.y < 0)
    {
        velocity.y = -2f;
    }

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = transform.right * x + transform.forward * z;

    if (Input.GetKey(KeyCode.LeftShift))
    {
        if (sprintVolume != null)
            sprintVolume.weight = Mathf.MoveTowards(sprintVolume.weight, 1f, 2f * Time.deltaTime);

        controller.Move(move * (speed + 5) * Time.deltaTime);
    }
    else
    {
        if (sprintVolume != null)
            sprintVolume.weight = Mathf.MoveTowards(sprintVolume.weight, 0f, 3f * Time.deltaTime);

        controller.Move(move * speed * Time.deltaTime);
    }

    if (Input.GetButtonDown("Jump") && isGrounded)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);

    // Footsteps
    if (footstepsAudio != null)
    {
        footstepsAudio.enabled = (x != 0 || z != 0) && isGrounded;
    }
}

}
