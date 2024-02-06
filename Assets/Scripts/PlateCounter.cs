using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlateCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private PlateSpawnVisual plateSpawnVisual;
     

    private float plateCounterSpawnTime;
    private float plateCounterSpawnTimeMax = 4f;
    private int currentNumOfPlates = 0;
    private int maxNumOfPlates = 4;

    public event EventHandler OnPlateSpawn;
    public event EventHandler OnPlateRemove;

    private void Start() {
        plateSpawnVisual = GetComponent<PlateSpawnVisual>();
    }

    private void Update() {
        if(currentNumOfPlates < maxNumOfPlates) {
            if(plateCounterSpawnTime < plateCounterSpawnTimeMax) {
                plateCounterSpawnTime += Time.deltaTime;
            } else {
                plateCounterSpawnTime = 0f;
                currentNumOfPlates++;
                if(plateSpawnVisual.GetNumOfPlates() <= 0) {
                    KitchenObject.SpawnKitchenObject(kitchenObjectSO, this);
                }
                OnPlateSpawn.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player) {
        if(HasKitchenObject() && !player.HasKitchenObject()) {
            currentNumOfPlates--;
            OnPlateRemove.Invoke(this, EventArgs.Empty);
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
            if (plateSpawnVisual.GetNumOfPlates() == 0) {
                Debug.Log(plateSpawnVisual.GetNumOfPlates());
                GetKitchenObject().DestroySelf();
            }

            
        }
    }

}
