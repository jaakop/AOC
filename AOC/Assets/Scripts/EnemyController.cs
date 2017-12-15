using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    private float curHealth = 100;

    [Header("Health bar properties")]
    [SerializeField]
    private float startHealth = 100;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image healthBarBG;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float distance = 0.5f;

    [SerializeField]
    float damage = 10;

    [SerializeField]
    private Rigidbody2D rb;

    private GameObject player;

    private PlayerMovement playerScript;

    public float worthInPoints = 10;

    private bool isAttacking = false;
    private float attackWait;
    [SerializeField]
    private float attackRate;

    void Start ()
    {
        curHealth = startHealth;
        healthBar.enabled = false;
        healthBarBG.enabled = false;
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();

    }

	void FixedUpdate ()
    {
        UpdateHealthBar();
        Move();

        attackWait -= Time.deltaTime;
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        }
        else
        {
            if (attackWait <= 0)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed/4f);
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = curHealth / startHealth;

        if (curHealth >= startHealth)
        {
            healthBar.enabled = false;
            healthBarBG.enabled = false;
            Debug.Log("fals");
        }
        else
        {
            healthBar.enabled = true;
            healthBarBG.enabled = true;
            Debug.Log("tru");
        }

        if (curHealth <= 0)
            Die();
        else if(curHealth > startHealth)
        {
            curHealth = startHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
    }

    public void Heal(float amount)
    {
        curHealth += amount;
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            attackWait = attackRate;
            playerScript.TakeDamage(damage);

        }
    }

    public void TakeKnockBack(float direction, float amount)
    {
        if(direction == 0)
        {
            rb.velocity = new Vector2(amount, 0);
        }
        else if (direction == 90)
        {
            rb.velocity = new Vector2(0, amount);
        }
        else if (direction == 180)
        {
            rb.velocity = new Vector2(-amount, 0);
        }
        else if (direction == 270)
        {
            rb.velocity = new Vector2(0, -amount);
        }
    }


}
