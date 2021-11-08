using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public GameObject enemy;
    private Quaternion direction;
    public int initial_rotation_timer;
    private int cur_rotation_timer;
    float start_pos_x, start_pos_z;
    // Start is called before the first frame update
    void Start()
    {
        cur_rotation_timer = initial_rotation_timer;
        start_pos_x = enemy.transform.position.x;
        start_pos_z = enemy.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (cur_rotation_timer < 0)
        {
            rotateEnemy();
            cur_rotation_timer = initial_rotation_timer;
        }
        cur_rotation_timer -= 1;
        walk();
    }

    private void rotateEnemy()
    {
        direction = Random.rotation;
        enemy.transform.rotation = new Quaternion(direction.x, 0, direction.z, 0);
    }

    private void walk()
    {
        enemy.transform.position += transform.forward * speed;
    }

    public void resetPOS()
    {
        enemy.transform.position = new Vector3(start_pos_x, 0.5f, start_pos_z);
    }
}
