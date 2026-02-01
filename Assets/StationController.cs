using System;
using UnityEngine;

public class StationController : Interactable
{
    [SerializeField]
    private IStation stationController;
    
    public static event Action<IStation> OnStationInteract;

    void Awake()
    {
        stationController = GetComponentInChildren<IStation>();
    }
    public override void Interact()
    {
        OnStationInteract.Invoke(stationController);
    }

    public virtual void InitiateInteraction(PlayerHandController playerHandController)
    {
        
    }
}