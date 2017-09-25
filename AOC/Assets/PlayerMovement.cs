using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float movementSpeed = 10f;

    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;

    void Start () {
		
	}

	void Update () {
        
        if (Input.GetKey(Left))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(Right))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(Up))
        {
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed);
        }
        else if (Input.GetKey(Down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -movementSpeed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
