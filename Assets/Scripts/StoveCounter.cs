using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoveCounter : BaseCounter
{

    
    [SerializeField] UncookedSO UncookedSO;

    private float cookedTime = 0f;
    private bool isCooking = false;
    private ProgressCuttingBar progressBar;

    private enum State : int {
        Uncooked,
        Cooked,
        Burned
    }

    State state = State.Uncooked;

    private void Start() {
        progressBar = GetComponent<ProgressCuttingBar>();
    }

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // There is no kitchenObject
            if (player.HasKitchenObject()) {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                if (!GetKitchenObject().IsNeedCook()) return;
                Debug.Log(state);
                state = SetCurrentState();
                isCooking = true;
                
            }

        }
        else {
            // There is has kitchenObject
            if (!player.HasKitchenObject()) {
                isCooking = false;
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    private void Update() {
        if(isCooking is true) {
            Cooking(state);
        }
    }

    private void Cooking(State state) {
        
        if (state == State.Burned) return; // if meat is burned;

        if(cookedTime < UncookedSO.cookedTime) {
            cookedTime += Time.deltaTime;
            progressBar.SetProgressVisible(true);
            progressBar.SetProgressBar(cookedTime / 3); // max progress is 1, so we need devide to 3 for getting procent of cookedTime


        } else {
            cookedTime = 0;
            progressBar.SetProgressVisible(false);
            GetKitchenObject().DestroySelf();
            switch (state) {
                case State.Uncooked: // Uncooked
                    KitchenObject.SpawnKitchenObject(UncookedSO.cookedPrefab.GetComponent<KitchenObject>().GetKitchenObject(), this);
                    this.state = SetCurrentState();
                    Debug.Log(state);
                    return;
                case State.Cooked: // Cooked                   
                    KitchenObject.SpawnKitchenObject(UncookedSO.burnedPrefab.GetComponent<KitchenObject>().GetKitchenObject(), this);
                    this.state = SetCurrentState();
                    
                    return;
            }

        }
    }

    private State SetCurrentState() {
        int num = 0;
        foreach(Transform elem in UncookedSO.cookedPrefabs) {
            if (elem.GetComponent<KitchenObject>().GetKitchenObject().prefab == GetKitchenObject().GetKitchenObject().prefab) {
                return (State)num;
            }
            num++;
        }
        return (State)num;
    }


}
