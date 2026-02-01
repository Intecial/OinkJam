using System;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    
    public static event Action<Interactable> OnInteractableHit;
    [SerializeField] private float reachDistance = 2f;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask interactableMask;

    [SerializeField] private PlayerHandController playerHandController;
    private RaycastHit2D hit;

    void Update()
    {
        CheckForColliders();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void CheckForColliders()
    {
        Vector2 origin = player.position;
        Vector2 direction = player.up; // top-down facing direction

        hit = Physics2D.Raycast(origin, direction, reachDistance, interactableMask);

        if (hit.collider != null && !playerHandController.isHoldingItem())
        {
            if(hit.collider.gameObject.TryGetComponent<Interactable>(out var interactable))
            {
                OnInteractableHit.Invoke(interactable);
            }
        } else
        {
            OnInteractableHit.Invoke(null);
        }
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
