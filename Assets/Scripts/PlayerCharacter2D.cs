using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter2D : MonoBehaviour {

    public int speed;
    public SpriteRenderer sr;
    public Animator anim;
    public float jumpForce;
    public Rigidbody2D rig;
    public bool isGrounded;
	// Use this for initialization
	void Start () {
        isGrounded = false;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rig.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            sr.flipX = true;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            sr.flipX = false;
        }
        else
            anim.SetBool("isWalking", false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
