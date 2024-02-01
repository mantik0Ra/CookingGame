using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // There is no kitchenObject
            if (player.HasKitchenObject()) {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }

        }
        else {
            // There is has kitchenObject
            if (!player.HasKitchenObject()) {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void AlternateInteract(Player player) {
        if(HasKitchenObject()) {
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }


}
