using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10.0f;
    
    private Rigidbody2D rigidBody;

    public LayerMask groundLayer;


    void Awake()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         
        if(Input.GetKeyUp(KeyCode.Space))
        {
            jump();
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
