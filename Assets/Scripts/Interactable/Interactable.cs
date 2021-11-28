using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactable GameObjects can be interacted with by the player.
/// A prompt will be shown with a key to press to interact with this object.
/// </summary>
/// 
[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    // Every item with Interactable also needs a collider with a tag "Interactable"
    protected virtual void Interact() { }

    public void BaseInteract() { if (interactable) Interact(); }
    public void LookingAt()
    {
        if (interactable) outline.OutlineWidth = 10;
    } 

    public void EndLooking()
    {
        if(interactable) outline.OutlineWidth = 0;
    }

    [HideInInspector]
    public Outline outline;

    public bool interactable=true;

    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0;
        //outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

}