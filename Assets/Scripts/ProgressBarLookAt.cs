using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarLookAt : MonoBehaviour
{

    [SerializeField] private Canvas bar;
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private Mode mode;

    public enum Mode {
        LookForward,
        LookForwardInverted
    }

    // Update is called once per frame
    void Update()
    {
        switch(mode) {
            case Mode.LookForward:
                bar.transform.forward = camera.transform.forward;
                return;
            case Mode.LookForwardInverted:
                bar.transform.forward = camera.transform.forward * -1;
                return;

            
        }
    }
}
