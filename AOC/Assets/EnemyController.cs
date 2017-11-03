using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    
    [SerializeField]
    private GameObject player;

    PlayerMovement playerscript;

    private float curHealth = 100;

    [Header("Health bar properties")]
    [SerializeField]
    private float startHealth = 100;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image healthBarBG;

    void Start ()
    {
        playerscript = player.GetComponent<PlayerMovement>();
        curHealth = startHealth;
        healthBar.enabled = false;
        healthBarBG.enabled = false;
    }

	void Update ()
    {
        UpdateHealthBar();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            Debug.Log("Enemy is in the attack zone");
            if (playerscript.isAttacking == true)
            {
                if (playerscript.dealtDamage == false)
                {
                    TakeDamage(playerscript.damage);
                    playerscript.dealtDamage = true;
                }
            }
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


}
