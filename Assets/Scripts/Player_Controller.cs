 using UnityEngine;
public class Player_Controller : MonoBehaviour
{
    public CharacterController characterController;
    public float MovementSpeed =1;
    public float Gravity = 9.8f;

    public Transform check;
    public float radius;
    public LayerMask ground;
    Vector3 velocity;
    bool is_grounded;
    void Update()
    {
        is_grounded = Physics.CheckSphere(check.position, radius, ground);

        if(is_grounded)
        {
            velocity.y = -1;
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       Vector3 move = transform.right * horizontal + transform.forward * vertical;
 
        characterController.Move(move * MovementSpeed * Time.deltaTime);

        velocity.y -=Gravity*Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}