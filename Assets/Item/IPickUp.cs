using UnityEngine;
public interface IPickUp
{
    void PickUp(PlayerHandController playerHandController);

    void Drop(PlayerHandController playerHandController);

    GameObject GetGameObject();
}