
using UnityEngine;

public interface IItem
{
    public void PickUp(PlayerHandController playerHandController);

    public void Drop(PlayerHandController playerHandController);

    public GameObject GetGameObject();
}