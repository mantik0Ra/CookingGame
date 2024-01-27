using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObject;
    [SerializeField] private Transform counterObjectPosition;

    
    public void Interact() {
        Transform kitchenObjectTransform = Instantiate(kitchenObject.prefab, counterObjectPosition);
        kitchenObjectTransform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObject().name);
    }
}
