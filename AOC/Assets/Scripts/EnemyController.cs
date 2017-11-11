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

    private GameObject player;
    private GameObject ui;

    private PlayerMovement playerScript;
    private ScoreCounter scoreScript;

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
        ui = GameObject.Find("UI");
        scoreScript = ui.GetComponent<ScoreCounter>();

    }

	void FixedUpdate ()
    {
        UpdateHealthBar();
        Move();
    }

    private void Move()
    {
        attackWait -= Time.deltaTime;
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
        scoreScript.AddScore(worthInPoints);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            attackWait = attackRate;
            playerScript.TakeDamage(damage);

        }
    }

}
