using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Camera _playerCamera = default;

    [Header("Options")]
    [SerializeField]
    private float _interactDistance = default;

    [SerializeField]
    private GameObject interactText;

    bool lookingAtInteractable = false; 
    GameObject hitObj;
    void Update() {
        lookingAtInteractable = false; // mogę raycastować na pare obiektów naraz więc sprawdzam czy jeden z nich był interactable
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, _interactDistance);
        if (hit)
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            if (hitObject.transform.tag == "Interactable") {
                Interactable i = hitObject.GetComponent<Interactable>();

                i.LookingAt();

                hitObj = hitObject;
                lookingAtInteractable = true;

                if (Input.GetButtonDown("Use"))
                {
                    i.BaseInteract();
                }
            }
        } 
        if(hitObj && !lookingAtInteractable) { hitObj.GetComponent<Interactable>().EndLooking();  hitObj = null; }

        interactText.SetActive(lookingAtInteractable);
    }

}
