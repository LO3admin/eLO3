using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInteractable : Interactable
{
    public Vector3 destination = Vector3.zero;
    public float speed = 10f;

    public GameObject target;

    private Vector3 startPos;
    private Vector3 destPos;
    private bool open = false;

    void Start()
    {
        if (!target) target = gameObject;
        startPos = target.transform.localPosition;
        destPos = startPos + destination;
    }

    protected override void Interact()
    {
        Debug.Log("from: " + target.transform.localPosition + " to: " + (open ? startPos : destPos));
        StopCoroutine("Move");
        StartCoroutine("Move", open ? startPos : destPos);

        open = !open;
    }

    public IEnumerator Move(Vector3 dest)
    {
        while (Vector3.Distance(transform.localPosition, dest) > 0.001f)
        {
            //target.transform.eulerAngles =  Vector3.Lerp(target.transform.eulerAngles, dAng, rotationSpeed*Time.deltaTime);
            target.transform.localPosition = Vector3.Lerp(target.transform.localPosition, dest, speed * Time.deltaTime);

            yield return null;
        }

        transform.localPosition = dest;

        outline.OutlineWidth = 0;
        yield return null;
    }
}
