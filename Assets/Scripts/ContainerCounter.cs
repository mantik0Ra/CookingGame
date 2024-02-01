using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    public event EventHandler ContainerCounterEventAnim;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        if (player.HasKitchenObject()) return;
        KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
        ContainerCounterEventAnim.Invoke(this, EventArgs.Empty);
    }

}
