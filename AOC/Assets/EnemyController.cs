using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    PlayerMovement playerscript;


    // Use this for initialization
    void Start () {
        playerscript = player.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            Debug.Log("Enemy is in the attack zone");
            if (playerscript.isAttacking == true)
            {
                Debug.Log(collision.transform.parent.gameObject.name);
                Debug.Log(playerscript.damage);
            }
        }
    }

}
