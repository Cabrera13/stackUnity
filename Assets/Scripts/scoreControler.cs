using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreControler : MonoBehaviour {
	//static vars that store information through all the scenes
	public int score = 0;
	public int best = 0;

	// getters and setters
	public void setScore (int sc) {
		score = sc;
	}
	public int getBest () {
		return PlayerPrefs.GetInt ("highscore");
		}
	public void setBest (int b) {
		PlayerPrefs.SetInt ("highscore", b);
	}
	public int getScore () {
		return score;
	}
}