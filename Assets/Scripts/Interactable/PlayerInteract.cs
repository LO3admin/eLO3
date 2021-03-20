using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Camera _playerCamera = default;

    [SerializeField]
    private GameObject _interactPrompt = default;

    [Header("Options")]
    [SerializeField]
    private float _interactDistance = default;

    [SerializeField]
    [Tooltip("Interact cooldown in seconds")]
    private float _interactCooldown = default;

    private float _nextInteractTime = 0;

    void Update() {
        if (Input.GetButtonDown("Use")) {
            OnInteract();
        } else {
            // Check if an interactable is in front of the player
            Ray ray = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward * _interactDistance);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _interactDistance))
            {
                if (hit.collider.tag == "Interactable")
                {
                    ShowPrompt();
                } else
                {
                    HidePrompt();
                }
            } else
            {
                HidePrompt();
            }
        }
    }

    private void OnInteract() {
        if (Time.time < _nextInteractTime)
        {
            return;
        }
        _nextInteractTime = Time.time + _interactCooldown;

        Ray ray = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward * _interactDistance);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactDistance))
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

                interactable?.Interact(gameObject);
            }
        }
    }

    // TODO: Do this with an animator or a tweening library
    private void ShowPrompt()
    {
        _interactPrompt.SetActive(true);
    }

    private void HidePrompt()
    {
        _interactPrompt.SetActive(false);
    }
}
