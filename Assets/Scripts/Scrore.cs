using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrore : MonoBehaviour {

    public int score = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void IncreaseScore()
    {
        score += 1;
    }
}
