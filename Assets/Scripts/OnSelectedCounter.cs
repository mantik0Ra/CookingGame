using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectedCounter : MonoBehaviour
{

    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualClearCounter;

    private void Start() {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e) {
        if(e.selectedCounter == clearCounter) {
            ShowVisual();
        } else {
            HideVisual();
        }
    }

    private void ShowVisual() {
        visualClearCounter.SetActive(true);
    }

    private void HideVisual() {
        visualClearCounter.SetActive(false);
    }
}
