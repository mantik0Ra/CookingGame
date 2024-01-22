using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 7f;
    // Update is called once per frame
    void Update()
    {
        Vector2 inputDir = new Vector2(0, 0);

        if(Input.GetKey(KeyCode.W)) {
            inputDir.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputDir.y = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputDir.x = 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputDir.x = -1;
        }

        Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);
        moveDir.Normalize();
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
