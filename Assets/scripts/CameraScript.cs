using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{

    public Vector2 rotation;
    public GameObject player;
    private InputActions inputActions;
    private InputAction cam;

    private void Awake()
    {
        inputActions = new InputActions(); //im losing my mind
    }

    private void OnEnable()
    {
        cam = inputActions.Camera.Camera;
        cam.Enable();

    }

    //private void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    void Update()
    {
        //rotation.x += Input.GetAxis("Mouse X");
        //rotation.y += Input.GetAxis("Mouse Y");

        // if a controller is plugged in, override those with controller buttons
        //rotation.x += Input.GetAxis("Joystick X");
        //rotation.y += Input.GetAxis("Joystick Y");

        //Vector2 v2 = cam.ReadValue<Vector2>();
        //var curRotation = transform.localRotation.eulerAngles;
        //curRotation.x += v2.x;
        //curRotation.y += v2.y;

        //transform.localRotation = Quaternion.Euler(curRotation.y, 0, 0);
        //player.transform.rotation = Quaternion.Euler(0, curRotation.x, 0);

        Vector2 v2 = cam.ReadValue<Vector2>(); //extract 2d input data
        Vector3 v3 = new Vector3(v2.x, 0, v2.y); //convert to 3d space
        //Debug.Log("Movement values " + v2);
        transform.Rotate(v3);
    }
}
