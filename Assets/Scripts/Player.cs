using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask layerMask;
    private float rotationSpeed = 20f;

    private bool isWalking = false;
    private Vector3 moveDir = new Vector3 (0, 0, 0);
    private Vector3 lastMoveVector = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleInteractions();
    }

    public bool IsWalking() {
        return isWalking;
    }

    private void HandleMovement() {

        moveDir = gameInput.GetMovementDirectonVectorNormalized();

        float playerSize = .1f;
        float playerRadius = .7f;
        float playerHeight = 2f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, playerSize);
        if (!canMove) {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            moveDirX.Normalize();
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, playerSize);

            if (canMove) {
                moveDir = moveDirX;
            }
            else {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                moveDirZ.Normalize();
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, playerSize);

                if (canMove) {
                    moveDir = moveDirZ;
                }
            }
        }
        if (canMove) {
            transform.position += moveDir * speed * Time.deltaTime;
        }


        isWalking = moveDir != Vector3.zero;

    }

    private void HandleInteractions() {

        if(moveDir != Vector3.zero) lastMoveVector = moveDir;

        float maxDistance = 1f;
        if(Physics.Raycast(transform.position, lastMoveVector, out RaycastHit raycastHit, maxDistance, layerMask)) {
            Debug.Log("Interact!");
        }
    }

    private void HandleRotation() {
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }
}
