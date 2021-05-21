using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public GameObject rotatingElement;

    public float angle = 90;
    public float rotationSpeed = 0.3f;

    private Quaternion desiredAngle;
    private Quaternion startingAngle;

    private Quaternion quaternionAngle;


    private bool open = false;

    void Start() {
        desiredAngle = rotatingElement.transform.rotation;
        startingAngle = rotatingElement.transform.rotation;
        quaternionAngle = startingAngle * Quaternion.Euler(Vector3.forward * angle);
    }

    void Update() {
        rotatingElement.transform.rotation = Quaternion.Slerp(rotatingElement.transform.rotation, desiredAngle, rotationSpeed);
    }

    public override void Interact()
    {
        open = !open;
        // desiredAngle = startingAngle;
        if (open) {
            desiredAngle = quaternionAngle;
        } else {
            desiredAngle = startingAngle;
        }
    }
}
