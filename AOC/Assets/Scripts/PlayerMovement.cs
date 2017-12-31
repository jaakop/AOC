using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private GameObject quitScreen;
    [SerializeField]
    Animator playerAnimator;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    GameObject sword;
    [SerializeField]
    GameObject swordObject;
    [SerializeField]
    float movementSpeed = 10f;
    [SerializeField]
    float attackdelay = 0.2f;
    [SerializeField]
    float damageDelay = 0.5f;
    public float knockback = 5f;
    public float damage = 10;

    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode AttackKey = KeyCode.Space;

    private float attackTime = 0f;
    private float damageTime = 0f;
    public float direction;

    [SerializeField]
    private bool isAttacked = false;
    public bool isAttacking = false;
    public bool dealtDamage = false;

    [Header("Health properties")]
    [SerializeField]
    private float playerSizeX;
    [SerializeField]
    private float playerSizeY;
    [SerializeField]
    private float minBeforeDeath;

    void Start ()
    {
        direction = 270f;

        playerSizeX = transform.localScale.x;
        playerSizeY = transform.localScale.y;
        minBeforeDeath = playerSizeX / 2;
        quitScreen.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        playerAnimator.SetFloat("Direction", direction);
    }
    void FixedUpdate () {

        attackTime -= Time.deltaTime;
        damageTime -= Time.deltaTime;

        if (attackTime < 0)
        {
            isAttacking = false;
            dealtDamage = false;
            sword.SetActive(false);
        }
        UpdateScale();
        CheckControls();
    }

    private void CheckControls()
    {

        if (Input.GetKey(Left))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            swordObject.transform.eulerAngles = new Vector3(0, 0, 180);
            direction = 180;
            //playerAnimator.SetFloat("Direction", direction);
        }
        else if (Input.GetKey(Right))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            swordObject.transform.eulerAngles = new Vector3(0, 0, 0);
            direction = 0;
            //playerAnimator.SetFloat("Direction", direction);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(Up))
        {
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed);
            swordObject.transform.eulerAngles = new Vector3(0, 0, 90);
            direction = 90;
            //playerAnimator.SetFloat("Direction", direction);
        }
        else if (Input.GetKey(Down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -movementSpeed);
            swordObject.transform.eulerAngles = new Vector3(0, 0, 270);
            direction = 270;
            //playerAnimator.SetFloat("Direction", direction);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetKey(AttackKey))
        {
            if (attackTime < 0f && isAttacked == false)
            {
                attackTime = attackdelay;
                sword.SetActive(true);
                isAttacked = true;
                isAttacking = true;
            }
        }
        else
        {
            isAttacked = false;
        }
    }

    public void TakeDamage(float amount)
    {
        float damageDealtX = amount/100;
        float damageDealtY = amount/100;
        if (damageTime < 0)
        {
            playerSizeX -= damageDealtX;
            playerSizeY -= damageDealtY;
            damageTime = damageDelay;
        }
    }

    private void UpdateScale()
    {
        if (transform.localScale.x > playerSizeX)
            transform.localScale -= new Vector3(transform.localScale.x - playerSizeX, 0, 0);

        if (transform.localScale.y > playerSizeY)
            transform.localScale -= new Vector3(0, transform.localScale.y - playerSizeY, 0);

        if(playerSizeX <= minBeforeDeath || playerSizeY <= minBeforeDeath)
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
