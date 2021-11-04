using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public CharacterController controller;
    public CapsuleCollider collider;
    public GameObject player;
    public float speed;
    public bool noclipEnabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            noclipEnabled = !noclipEnabled;
            noclip();
        }
    }

    private void movement()
    {
        float x_movement = Input.GetAxis("Horizontal");
        float z_movement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x_movement + transform.forward * z_movement;

        controller.Move(movement * speed * Time.deltaTime);
    }

    private void noclip()
    {
        if (noclipEnabled)
        {
            collider.enabled = false;
            player.layer = 7;
        } else
        {
            collider.enabled = true;
            player.layer = 0;
        }
    }
}
