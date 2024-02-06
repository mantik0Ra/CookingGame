using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateSpawnVisual : MonoBehaviour
{

    [SerializeField] private PlateCounter plateCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private List<GameObject> plateVisualList = new List<GameObject>();

    private void Start() {
        plateCounter.OnPlateSpawn += PlateCounter_OnPlateSpawn;
        plateCounter.OnPlateRemove += PlateCounter_OnPlateRemove;
    }

    private void PlateCounter_OnPlateRemove(object sender, System.EventArgs e) {
        RemovePlate();

    }

    private void PlateCounter_OnPlateSpawn(object sender, System.EventArgs e) {
            Transform plate = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            plateVisualList.Add(plate.gameObject);
            plate.localPosition = new Vector3(0, 0.1f * (plateVisualList.Count-1), 0);
        
    }

    public int GetNumOfPlates() {
        return plateVisualList.Count;
    }

    public void AddPlate(GameObject plate) {
        plateVisualList.Add(plate);
    }

    public void RemovePlate() {
        if (plateVisualList.Count == 0) return;
        Destroy(plateVisualList[plateVisualList.Count - 1]);
        plateVisualList.Remove(plateVisualList[plateVisualList.Count - 1]);
    }

    
}
