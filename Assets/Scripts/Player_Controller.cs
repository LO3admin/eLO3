 using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Player_Controller : MonoBehaviour
{
    private CharacterController characterController;
    private bool running = false;

    public float MovementSpeed = 5;
    public float RunningSpeed = 7;
    public KeyCode run = KeyCode.LeftShift;
    public float Gravity = 9.8f;

    [Header("Walking Sound")]
    public AudioClip footstepSound;
    public AudioClip runningSound;
    public float volMin=0.7f, volMax=1f, pitchMin=0.7f, pitchMax=1.2f;
    private AudioSource source;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        source = AudioManager.instance.playerSource;
    }

    void Update()
    {
        running = Input.GetKey(run);
        source.clip = running ? runningSound : footstepSound;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * horizontal + transform.forward * vertical).normalized * (running ? RunningSpeed : MovementSpeed);

        if (Input.GetKey(KeyCode.BackQuote)) { move *= 4f; }

        move.y = (characterController.isGrounded) ? 0 : -Gravity;

        characterController.Move(move * Time.deltaTime);

        if(characterController.isGrounded && characterController.velocity.magnitude>2f && !source.isPlaying)
        {
            source.volume = Random.Range(volMin, volMax);
            source.pitch = Random.Range(pitchMin, pitchMax);
            source.Play();
        }
    }
}
