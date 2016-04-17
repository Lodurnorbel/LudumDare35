using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}

	public int getScore() {
		return score;
	}

	public void changeScoreBy(int quantity) {
		score += quantity;
		Debug.Log ("Score: " + score);
	}

}
