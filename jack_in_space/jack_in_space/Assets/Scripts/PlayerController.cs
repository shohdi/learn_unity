using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 6.0f;
    private Rigidbody2D rigidBody;


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

    void jump()
    {
        this.rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
