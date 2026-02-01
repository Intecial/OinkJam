using System;
using UnityEngine;

public class SupplierInteractable : Interactable
{

    [SerializeField]
    private GameObject itemSlot;

    public override void Interact()
    {
        Debug.Log("Supplier Interacted");
        // base.Interact();
    }
    
}
