using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private SlicebleKitchenObjectSO slicedKitchenObject;

    private IKitchenObjectParent kitchenObjectParent;

    private float currentProgress = 0f;
    
    
    public KitchenObjectSO GetKitchenObject() {
        return kitchenObjectSO;
    }

    public SlicebleKitchenObjectSO GetSlicedKitchenObject() {
        return slicedKitchenObject;
    }

    public bool IsSliced() {
        return kitchenObjectSO.IsSliced;
    }

    public float GetCurrentProgressOfCutting() {
        return currentProgress;
    }

    public void ChangeCurrentProgressOfCutting(float amount) {
        if (!IsSliced()) return;
        currentProgress += amount;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent) {
        if(this.kitchenObjectParent != null) {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject()) {
            Debug.LogError("IKitchenObjectParent already has a KitcheObject!");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent() {
        return kitchenObjectParent;
    }

    public void DestroySelf() {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }
    
    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent) {
        Transform transformObject = Instantiate(kitchenObjectSO.prefab);

        KitchenObject kitchenObject = transformObject.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }

    public static KitchenObject SpawnKitchenObject(SlicebleKitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent) {
        Transform transformObject = Instantiate(kitchenObjectSO.prefab);

        KitchenObject kitchenObject = transformObject.GetComponent<KitchenObject>();
        
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }
}
