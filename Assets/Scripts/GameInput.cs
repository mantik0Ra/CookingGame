using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    
    private InputActionsController inputActionsController;
    public event EventHandler InteractEvent;

    private void Awake() {
        inputActionsController = new InputActionsController();
        inputActionsController.Player.Enable();
        inputActionsController.Player.Interact.performed += Interact_performed; 
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        InteractEvent?.Invoke(obj, EventArgs.Empty);
    }

    public Vector3 GetMovementDirectonVectorNormalized() {
        Vector2 inputDir = inputActionsController.Player.Move.ReadValue<Vector2>();

        Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);
        moveDir.Normalize();
        return moveDir;
    }

}
