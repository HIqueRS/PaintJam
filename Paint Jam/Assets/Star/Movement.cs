using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Velocity = 1;
    public int Jump = 1;
    Vector2 Jumperu;
    bool CanJump;

    // Start is called before the first frame update
    void Start()
    {
        Jumperu =new Vector2 (0.0f, 1000f);
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {      
        transform.position += new Vector3(Input.GetAxis("Horizontal"),0f,0f)*Time.deltaTime * Velocity;

        if(CanJump)
        {
            if (Input.GetKeyDown("joystick button 0")||Input.GetKeyDown("space"))
            {
                CanJump = false;
                GetComponent<Rigidbody2D>().AddForce(Jumperu * Time.deltaTime * Jump);
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
            }
            
        }
    }
}
