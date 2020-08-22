using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float runSpeed = 4f;
    public Vector3 startingAngle;
    
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
        this.startingAngle = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {

            jump();

        }
        this.myAnimator.SetBool("isGrounded", this.isGrounded());
        //Debug.Log(this.isGrounded());
        //Debug.Log( string.Format("{0},{1}", this.transform.position.x, this.transform.position.y));

    }


    void FixedUpdate()
    {
        if(this.rigidBody.velocity.x < runSpeed)
        {

            this.rigidBody.velocity = new Vector2(runSpeed, this.rigidBody.velocity.y);
            this.rigidBody.angularVelocity = 0f;
            this.transform.eulerAngles = this.startingAngle;

        }
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
        if(Physics2D.Raycast(this.transform.position,Vector2.down,0.2f,groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
