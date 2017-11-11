using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    EnemyController enemyScript;
    PlayerMovement playermoverscript;
    void Start()
    {
        playermoverscript = transform.GetComponent<PlayerMovement>();
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("you hit: " + collision.name);
        if (collision.tag == "Enemy")
        {
            enemyScript = collision.GetComponent<EnemyController>();
            Debug.Log("enemy script founded");
            if (playermoverscript.isAttacking == true)
            {
                if (playermoverscript.dealtDamage == false)
                {
                    playermoverscript.dealtDamage = true;
                    enemyScript.TakeDamage(playermoverscript.damage);
                    Debug.Log("Damage has been dealt");
                }
            }
        }

    }
}
