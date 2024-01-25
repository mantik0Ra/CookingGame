using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    [SerializeField] private float speed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask layerMask;
    private float rotationSpeed = 20f;

    private bool isWalking = false;
    private Vector3 lastMoveVector = new Vector3(0, 0, 0);

    private ClearCounter selectedCounter;
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs {
        public ClearCounter selectedCounter;
    }

    // Update is called once per frame

    private void Awake() {
        if(Instance != null) {
            Debug.LogError("There is more than one player instance");
        }
        Instance = this;
    }

    private void Start() {
        gameInput.InteractEvent += GameInputInteractEvent;
    }

    private void GameInputInteractEvent(object sender, System.EventArgs e) {
        if(selectedCounter != null) {
            selectedCounter.Interact();
        }
    }

    void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking() {
        return isWalking;
    }

    private void HandleMovement() {

        Vector3 moveDir = gameInput.GetMovementDirectonVectorNormalized();
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);

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
        Vector3 moveDir = gameInput.GetMovementDirectonVectorNormalized();

        if (moveDir != Vector3.zero) lastMoveVector = moveDir;

        float maxDistance = 1f;
        if (Physics.Raycast(transform.position, lastMoveVector, out RaycastHit raycastHit, maxDistance, layerMask)) {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) {
                SetSelectedCounter(clearCounter);
            }
            else {
                SetSelectedCounter(null);
            }

        } else {
            SetSelectedCounter(null);
        }
        
    }

    private void SetSelectedCounter(ClearCounter clearCounter) {
        selectedCounter = clearCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs {
            selectedCounter = selectedCounter
        });

    }

}
