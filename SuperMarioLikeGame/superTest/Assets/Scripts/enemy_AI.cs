using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_AI : MonoBehaviour
{
    public int EnemySpeed = 1;
    public int XMoveDirection;

	// Update is called once per frame
	void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.5f)
        {
            Flip();
            if (hit.collider.tag == "Player")
            {
                //Destroy(hit.collider.gameObject);
                Die();
            }

        }

    }
    void Die()
    {
        SceneManager.LoadScene("Prototype_1");

    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
