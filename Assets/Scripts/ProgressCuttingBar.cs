using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCuttingBar : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject progressObject;

    public void ChangeProgress(float numberOfProgress) {
        if (progressBar == null) Debug.LogError("progressBar is null");
        progressBar.fillAmount += numberOfProgress;
        
    }

    public Image GetProgressBar() {
        return progressBar;
    }

    public void SetProgressBar(float amount) {
        if (progressBar == null) Debug.LogError("progressBar is null");
        progressBar.fillAmount = amount;
    }

    public void SetProgressVisible(bool change) {
        progressObject.SetActive(change);
    }

    
}
