using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    public override void Interact(Player player) {
        if(!HasKitchenObject()) {
            // There is no kitchenObject
            if(player.HasKitchenObject()) {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }

        } else {
            // There is has kitchenObject
            if(!player.HasKitchenObject()) {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
