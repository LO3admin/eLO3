using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorInteractable : Interactable
{

    public Vector3 angle = new Vector3(0,0,90);
    public float rotationSpeed = 10f;

    public GameObject target;

    private Quaternion startingAngle;
    private Quaternion desiredAngle;
    private bool open = false;

    void Start() {
        if (!target) target = gameObject;
        startingAngle = target.transform.rotation;
        desiredAngle = startingAngle * Quaternion.Euler(angle);

        Debug.Log("s: " + startingAngle + " d: " + desiredAngle);
    }

    protected override void Interact()
    {

        Debug.Log("from: "+target.transform.rotation + " to: "+(open ? startingAngle : desiredAngle));

        StopCoroutine("Rot");
        StartCoroutine("Rot", open ? startingAngle : desiredAngle);

        open = !open;
    }

    public IEnumerator Rot(Quaternion dAng)
    {
        while (Quaternion.Angle(transform.rotation, dAng) > 2.0f)
        {
            //target.transform.eulerAngles =  Vector3.Lerp(target.transform.eulerAngles, dAng, rotationSpeed*Time.deltaTime);
            target.transform.rotation = Quaternion.Slerp(target.transform.rotation, dAng, rotationSpeed * Time.deltaTime);

            yield return null;
        }

        target.transform.rotation = dAng;

        outline.OutlineWidth = 0;
        yield return null;
    }
}
