using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform TR;
    private Rigidbody2D Rigid;
    private Vector3 L_vector = new Vector3(-1, 0, 0);
    private Vector3 R_vector = new Vector3(1, 0, 0);
    private Vector3 P_vector = new Vector3(0, 0, 0);
    private float Move_speed = 4.0f;

    private Vector3 Jump_vector = new Vector3(0, 1, 0);
    private float Jump_force = 8.0f;

    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        TR = GetComponent<Transform>();
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            P_vector = R_vector;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            P_vector = L_vector;
        }
        else
        {
            P_vector = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) &&  !isJumping)
        {
            isJumping = true;
            Rigid.velocity = Jump_vector * Jump_force;
        }
        
    }
    private void FixedUpdate()
    {
        TR.Translate(P_vector * Move_speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FLOOR")) 
        {
            isJumping = false;
        }
    }
}
