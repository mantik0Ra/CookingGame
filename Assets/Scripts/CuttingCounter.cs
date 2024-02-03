using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingCounter : BaseCounter
{

    private ProgressCuttingBar progressBar;
    public event EventHandler CuttingCounterEventAnim;
    private void Start() {
        progressBar = GetComponent<ProgressCuttingBar>();
    }
    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // There is no kitchenObject
            if (player.HasKitchenObject()) {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                if(GetKitchenObject().IsSliced()) {
                    progressBar.SetProgressVisible(true);
                    progressBar.SetProgressBar(GetKitchenObject().GetCurrentProgressOfCutting());
                }
                
            }

        }
        else {
            // There is has kitchenObject
            if (!player.HasKitchenObject()) {
                GetKitchenObject().SetKitchenObjectParent(player);
                progressBar.SetProgressVisible(false);

            }
        }
    }

    public override void AlternateInteract(Player player) {
        if(HasKitchenObject() && GetKitchenObject().IsSliced()) {
            KitchenObject kitchenObject = GetKitchenObject();
            if (kitchenObject.GetCurrentProgressOfCutting() < kitchenObject.GetSlicedKitchenObject().maxProgress - 0.25f) {
                kitchenObject.ChangeCurrentProgressOfCutting(0.25f);
                progressBar.ChangeProgress(0.25f);
                CuttingCounterEventAnim.Invoke(this, EventArgs.Empty);
            } else {
                GetKitchenObject().DestroySelf();
                progressBar.SetProgressVisible(false);
                KitchenObject.SpawnKitchenObject(kitchenObject.GetSlicedKitchenObject(), this);
            }
    
        }
    }


}
