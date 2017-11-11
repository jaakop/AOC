using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawns;
    private GameObject currentspawn;
    private int index;

    public GameObject enemy;

    [SerializeField]
    private float spawnRate;

    private float spawntimer = 0f;

	void Start ()
    {
        spawntimer = spawnRate;
	}
	
	void Update ()
    {
        spawntimer -= Time.deltaTime;
        if(spawntimer <= 0)
        {
            index = Random.Range(0, spawns.Length);
            currentspawn = spawns[index];
            Instantiate(enemy, new Vector3(currentspawn.transform.position.x, currentspawn.transform.position.y), Quaternion.identity);
            spawntimer = spawnRate;
        }
	}
}
