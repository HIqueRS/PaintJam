using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Velocity = 1;
    public int Jump = 1;
    Vector2 Jumperu;
    bool CanJump;
    bool CanDoubleJump;
    public bool DoubleJump;
    public bool Fly;


    // Start is called before the first frame update
    void Start()
    {
        Jumperu =new Vector2 (0.0f, 1000f);
        CanJump = true;
        CanDoubleJump = false;
        DoubleJump = false;
    }

    // Update is called once per frame
    void Update()
    {      
        transform.position += new Vector3(Input.GetAxis("Horizontal"),0f,0f)*Time.deltaTime * Velocity;

        if (Fly)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().AddForce(Jumperu * Time.deltaTime * 0.1f);
        }
        else if (CanJump)
        {
            if (Input.GetKeyDown("joystick button 0")||Input.GetKeyDown("space"))
            {
                if(CanDoubleJump)
                {
                    GetComponent<Rigidbody2D>().AddForce(Jumperu * Time.deltaTime * Jump);
                    CanDoubleJump = false;
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(Jumperu * Time.deltaTime * Jump);
                    CanJump = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            if(transform.position.y > collision.transform.position.y)
            {
                CanJump = true;
                if(DoubleJump)
                {
                    CanDoubleJump = true;
                }
            }
            
        }
    }
}
