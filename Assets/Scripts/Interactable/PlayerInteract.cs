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

    [SerializeField]
    private LayerMask _interactableLayers;

    Interactable activeObject;
    void Update() {
        if (Menu.instance.Paused) return;

        var hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, _interactDistance, _interactableLayers);
        if (hit && hitInfo.transform.CompareTag("Interactable"))
        {
            var hitObject = hitInfo.transform.gameObject.GetComponent<Interactable>();
            if (hitObject != activeObject)
            {
                activeObject?.StoppedLooking();
                hitObject.LookingAt();
                activeObject = hitObject;
            }

            if (Input.GetButtonDown("Use"))
            {
                activeObject.BaseInteract();
            }
        }
        else if (activeObject) 
        {
            activeObject.StoppedLooking();
            activeObject = null;
        }

        interactText.SetActive(activeObject);
    }
}