using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterAnimator : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";
    [SerializeField] private ContainerCounter containerCounter;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        containerCounter.ContainerCounterEventAnim += ContainerCounter_ContainerCounterEventAnim;

    }

    private void ContainerCounter_ContainerCounterEventAnim(object sender, System.EventArgs e) {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
