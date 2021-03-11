using UnityEngine;
 
public class Player_Movement : MonoBehaviour
{
    public float sensitivity;
    private float xRotation = 0.0f;
    public Transform player;
 
    void Start()
    {
   
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);
        player.Rotate(Vector3.up * mouseX);
    }
}
