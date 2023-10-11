using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator Anim;
    private SpriteRenderer SR;
    private bool NoRun = false;
    private bool Run = true;
    private bool NoJump = false;
    private bool Jump = true;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("run", NoRun);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Anim.SetBool("jump", Jump);
                SR.flipX = false;
            }
            else
            {
                Anim.SetBool("run", Run);
                SR.flipX = false;
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Anim.SetBool("jump", Jump);
                SR.flipX = true;
            }
            else
            {
                Anim.SetBool("run", Run);
                SR.flipX = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Anim.SetBool("Jump", Jump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FLOOR"))
        {
            Anim.SetBool("jump",NoJump);
        }
    }
}
