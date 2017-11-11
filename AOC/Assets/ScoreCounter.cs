using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    [SerializeField]
    private Text scoreText;

    public float score = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "" + score;
	}

    public void AddScore(float amount)
    {
        score += amount;
    }
}
