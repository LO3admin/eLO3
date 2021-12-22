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
    [HideInInspector]
    public Outline outline;

    public bool interactable=true;
    public bool outlineWhenLooking = true;
    public AudioClip interactSound;
    public bool soundOnInteraction = true;

    private AudioSource source;
    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0;
    }

    // Every item with Interactable also needs a collider with a tag "Interactable"
    protected virtual void Interact() { }

    public void BaseInteract()
    {
        if (interactable) Interact();
        if (soundOnInteraction)
        {
            if(!source) source = gameObject.AddComponent<AudioSource>();

            source.Stop();
            source.clip = interactSound;
            source.Play();
        }
    }
    public void LookingAt() { if (interactable && outlineWhenLooking) outline.OutlineWidth = 10; }
    public void StoppedLooking() { if (interactable) outline.OutlineWidth = 0; }

}