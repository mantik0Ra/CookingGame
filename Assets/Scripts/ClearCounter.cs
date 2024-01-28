using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterObjectPosition;
    [SerializeField] private ClearCounter secondClearCounter;

    private KitchenObject kitchenObject;
    private bool testing = false;

    private void Update() {
        if(testing && Input.GetKeyDown(KeyCode.T)) {
            if(kitchenObject != null) {
                kitchenObject.SetClearCounter(secondClearCounter);
                
            }
        }
    }

    public void Interact() {
        if (kitchenObject == null) {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterObjectPosition);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
            testing = true;
        } else {
            Debug.Log(kitchenObject.GetClearCounter());
        }
      
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
