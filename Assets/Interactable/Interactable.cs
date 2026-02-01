using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    public void DisableInteraction()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public void EnableInteraction()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Interactable");
        
    }
}
