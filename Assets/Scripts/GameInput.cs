using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    
    private InputActionsController inputActionsController;
    public event EventHandler InteractEvent;
    public event EventHandler AlternateInteractEvent;

    private void Awake() {
        inputActionsController = new InputActionsController();
        inputActionsController.Player.Enable();
        inputActionsController.Player.Interact.performed += Interact_performed;
        inputActionsController.Player.AlternateInteract.performed += AlternateInteract_performed; ;
    }

    private void AlternateInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        AlternateInteractEvent.Invoke(obj, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        InteractEvent?.Invoke(obj, EventArgs.Empty);
    }



    public Vector3 GetMovementDirectonVectorNormalized() {
        Vector2 inputDir = inputActionsController.Player.Move.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);
        Debug.Log(moveDir);
        moveDir.Normalize();
        return moveDir;
    }

}
