using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move_prototype : MonoBehaviour
{

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int jumpPower = 10;
    private float moveX;
    public bool isGrounded;

    
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.acceleration.x * 1;
        //moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        //Animations
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);

        }
        //Direction_Player
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //Jump method
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        isGrounded = false;
    }


    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 0.9f && hit.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<enemy_AI>().enabled = false;
        }

        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "Enemy")
        {
            isGrounded = true;
        }
    }
}
