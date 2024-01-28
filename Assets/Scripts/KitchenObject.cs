using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;
    
    public KitchenObjectSO GetKitchenObject() {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter) {
        Debug.Log(clearCounter + " 1");
        if(this.clearCounter != null) {
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = clearCounter;
        Debug.Log(clearCounter + " 2");

        if (clearCounter.HasKitchenObject()) {
            Debug.LogError("Counter already has a KitcheObject!");
        }

        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter() {
        return clearCounter;
    }
}
