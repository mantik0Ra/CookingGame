using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    public event EventHandler ContainerCounterEventAnim;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        ContainerCounterEventAnim.Invoke(this, EventArgs.Empty);
    }

}
