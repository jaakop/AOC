using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private GameObject quitScreen;

    [SerializeField]
    GameObject enemy;

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

    private float attackTime = 0f;

    [SerializeField]
    private bool isAttacked = false;
    public bool isAttacking = false;
    public bool dealtDamage = false;

    [Header("Health properties")]
    [SerializeField]
    private float startingHealth;
    [SerializeField]
    private float currenHealth;
    [SerializeField]
    private float playerSizeX;
    [SerializeField]
    private float playerSizeY;
    [SerializeField]
    private float minBeforeDeath = 0.1f;

    void Start ()
    {
        playerSizeX = transform.localScale.x;
        playerSizeY = transform.localScale.y;
        currenHealth = startingHealth;
	}

	void FixedUpdate () {

        attackTime -= Time.deltaTime;
        CheckControls();
        UpdateScale();
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

    public void TakeDamage(float amount)
    {
        float damageDealtX = transform.localScale.x / amount;
        float damageDealtY = transform.localScale.y / amount;
        playerSizeX -= damageDealtX;
        playerSizeY -= damageDealtY;
    }

    private void UpdateScale()
    {
        if (transform.localScale.x > playerSizeX)
            transform.localScale -= new Vector3(transform.localScale.x - playerSizeX, 0, 0);

        if (transform.localScale.y > playerSizeY)
            transform.localScale -= new Vector3(0, transform.localScale.y - playerSizeY, 0);

        if(playerSizeX <= minBeforeDeath|| playerSizeY <= minBeforeDeath)
        {
            Death();
        }

    }

    private void Death()
    {
        quitScreen.SetActive(true);
        Time.timeScale = 0;
    }

}
