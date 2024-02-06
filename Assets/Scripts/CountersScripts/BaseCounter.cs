using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{

    private KitchenObject kitchenObject;

    [SerializeField] private Transform counterObjectPosition;
    public virtual void Interact(Player player) {
        Debug.LogError("BaseCounter.Interact()");
    }

    public virtual void AlternateInteract(Player player) {
        Debug.LogError("BaseCounter.AlternateInteract()");
    }

    public Transform GetKitchenObjectFollowTransform() {
        return counterObjectPosition;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
