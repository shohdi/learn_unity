using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10.0f;
    
    private Rigidbody2D rigidBody;

    public LayerMask groundLayer;

    public Animator myAnimator;



    void Awake()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
        this.myAnimator =  this.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.myAnimator.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyUp(KeyCode.Space))
        {

            jump();

        }



    }


    void FixedUpdate()
    {
        this.myAnimator.SetBool("isGrounded", this.isGrounded());
    }



    private void jump()
    {
        if (this.isGrounded())
        {

            this.rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool isGrounded()
    {
        if(Physics2D.Raycast(this.transform.position,Vector2.down,0.2f,groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
