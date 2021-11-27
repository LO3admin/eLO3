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

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        running = Input.GetKey(run);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * horizontal + transform.forward * vertical) * (running ? RunningSpeed : MovementSpeed);

        move.y = (characterController.isGrounded) ? 0 : -Gravity;

        characterController.Move(move * Time.deltaTime);
    }
}
