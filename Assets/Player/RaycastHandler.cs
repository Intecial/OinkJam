using System;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public static event Action<Collider2D> OnInteractProximity;
    [SerializeField] private float reachDistance = 2f;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask interactableMask;

    [SerializeField] private PlayerHandController playerHandController;
    private RaycastHit2D hit;

    void Awake()
    {
        InputController.OnInteractClicked += CheckForColliders;
    }

    void OnDestroy()
    {
        InputController.OnInteractClicked -= CheckForColliders;
    }

    void Update()
    {
        InitializeRaycast();
        OnInteractProximity?.Invoke(hit.collider);
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void CheckForColliders()
    {
        InitializeRaycast();
        if (playerHandController.isHoldingItem())
        {
            // If Is Station, interact wiht station with the object
            if (hit.collider != null && hit.collider.TryGetComponent<IStation>(out var station))
            {
                station.InteractStation(playerHandController);
            } else
            {
                // Else drop it
                playerHandController.DropItem();
                
            }
        }
        else if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<IPickUp>(out var pickUp))
            {
                pickUp.PickUp(playerHandController);
            }
            else if(hit.collider.TryGetComponent<IStation>(out var station))
            {
                station.InteractStation(playerHandController);
            }
            Debug.Log("Interacted!");
        } else
        {
            
        }
    }

    void InitializeRaycast()
    {
        Vector2 origin = player.position;
        Vector2 direction = player.up; // top-down facing direction

        hit = Physics2D.Raycast(origin, direction, reachDistance, interactableMask);
    }

    private void OnDrawGizmos()
    {
        if (player == null) return;

        Gizmos.color = hit.collider ? Color.red : Color.green;

        Vector3 origin = player.position;
        Vector3 direction = player.up * reachDistance;

        Gizmos.DrawLine(origin, origin + direction);
        Gizmos.DrawSphere(origin + direction, 0.05f);
    }

    public Collider2D GetCollider()
    {
        return hit.collider;
    }

    public GameObject GetCollidedGameObject()
    {
        return hit.collider.gameObject;
    }    
}
