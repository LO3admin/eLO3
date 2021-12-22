using UnityEngine;
 
public class Camera_Controller : MonoBehaviour
{
    public float sensitivity;
    public Transform player;

    private float xRotation = 0.0f;
    private float sMin = 0, sMax = 200;
 
    void Start()
    {
   
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        if (Menu.instance.Paused) return;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);
        player.Rotate(Vector3.up * mouseX);
    }

    public void SetSensitivity(float val)
    {
        if(sMin<sensitivity&& sensitivity<sMax) sensitivity = val;
    }
}
