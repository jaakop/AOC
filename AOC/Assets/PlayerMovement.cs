using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    GameObject sword;

    [SerializeField]
    float movementSpeed = 10f;

    public float damage = 10;

    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode AttackKey = KeyCode.Space;

    [SerializeField]
    private bool isAttacked = false;

    private float attackTime = 0f;

    public bool isAttacking = false;

    public bool dealtDamage = false;

    void Start () {
		
	}

	void FixedUpdate () {

        attackTime -= Time.deltaTime;
        CheckControls();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("you hit: " + collision.name);
    }

    private void CheckControls()
    {
        if (Input.GetKey(Left))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (Input.GetKey(Right))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(Up))
        {
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Input.GetKey(Down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -movementSpeed);
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetKey(AttackKey))
        {
            if (attackTime < 0f && isAttacked == false)
            {
                attackTime = 0.1f;
                sword.SetActive(true);
                isAttacked = true;
                isAttacking = true;
            }
        }
        else
        {
            isAttacked = false;
        }
        if (attackTime < 0)
        {
            isAttacking = false;
            dealtDamage = false;
            sword.SetActive(false);
        }
    }

}
