using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterAnimator : MonoBehaviour
{
    private const string CUT = "Cut";
    [SerializeField] private CuttingCounter cuttingCounter;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cuttingCounter.CuttingCounterEventAnim += CuttingCounter_CuttingCounterEventAnim;

    }

    private void CuttingCounter_CuttingCounterEventAnim(object sender, System.EventArgs e) {
        animator.SetTrigger(CUT);
    }
}
