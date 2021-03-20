using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactable GameObjects can be interacted with by the player.
/// A prompt will be shown with a key to press to interact with this object.
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    // Every item with Interactable also needs a collider with a tag "Interactable"
    public virtual void Interact() { }

    public virtual void Interact(GameObject interactor)
    {
        Interact();
    }

}