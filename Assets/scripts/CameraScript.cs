using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Vector2 rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        rotation.x += Input.GetAxis("Mouse X");
        rotation.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0);
    }
}
