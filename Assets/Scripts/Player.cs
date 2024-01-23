using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 7f;
    [SerializeField] private GameInput gameInput;
    private float rotationSpeed = 20f;

    private bool isWalking = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = gameInput.GetMovementDirectonVectorNormalized();
        transform.position += moveDir * speed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

    public bool IsWalking() {
        return isWalking;
    }
}
