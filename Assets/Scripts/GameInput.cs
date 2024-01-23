using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    
    private InputActionsController inputActionsController;

    private void Awake() {
        inputActionsController = new InputActionsController();
        inputActionsController.Player.Enable();
    }
    public Vector3 GetMovementDirectonVectorNormalized() {
        Vector2 inputDir = inputActionsController.Player.Move.ReadValue<Vector2>();

        Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);
        moveDir.Normalize();
        return moveDir;
    }

}
