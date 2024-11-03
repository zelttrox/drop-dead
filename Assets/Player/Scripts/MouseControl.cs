using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour {

    public Transform Character ;
    float rotationX = 0f ;

    void Start() {

        Game.ctrl.Mse_Sensitivity = 100f;

        Cursor.lockState = CursorLockMode.Locked ;
    }

    void Update() {
        MouseController();
        MouseCursor();
    }

    void MouseController() {

        if (Game.player.isInsideMenu == false) {
            float mouseX = Input.GetAxis("Mouse X") * Game.ctrl.Mse_Sensitivity * Time.deltaTime * 10;
            float mouseY = Input.GetAxis("Mouse Y") * Game.ctrl.Mse_Sensitivity * Time.deltaTime * 10;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            Character.Rotate(Vector3.up * mouseX);
        }
    }
    
    void MouseCursor() {
    
        if (Game.player.isInsideMenu) {
        
            Cursor.lockState = CursorLockMode.None ;
        } else {
            
            Cursor.lockState = CursorLockMode.Locked ;
        }
    }
}
