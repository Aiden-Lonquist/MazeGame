using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    public CharacterController controller;
    public CapsuleCollider collider;
    public GameObject player;
    public float speed;
    public bool noclipEnabled;
    float start_pos_x, start_pos_z;
    private InputActions inputActions;
    private InputAction movement;


    private void Awake()
    {
        inputActions = new InputActions(); //create new InputActions
    }

    private void OnEnable()
    {
        movement = inputActions.Player.Movement;
        movement.Enable();
    }


        // Start is called before the first frame update
        void Start()
    {
        start_pos_x = -3.5f;
        start_pos_z = -3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //move();

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            noclipEnabled = !noclipEnabled;
            noclip();
        }

        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.JoystickButton0)) 
        {
            resetPOS();
        }
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

    private void resetPOS()
    {
        player.transform.position = new Vector3(start_pos_x, 0.5f, start_pos_z);
        GameObject enemy = GameObject.Find("Enemy"); 
        enemy.GetComponent<EnemyScript>().resetPOS();
    }

    private void FixedUpdate()
    {
        Vector2 v2 = movement.ReadValue<Vector2>();
        Vector3 v3 = new Vector3(v2.x / 50, 0, v2.y / 50);

        transform.Translate(v3);
    }
}
