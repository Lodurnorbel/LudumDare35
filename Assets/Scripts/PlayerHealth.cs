using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;

	private bool isDamaged;
	public int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDamaged) {
			ChangeHealthBy (-10);
			isDamaged = false;
		}
	}

	void ChangeHealthBy(int quantity) {
		currentHealth += quantity;
		Debug.Log ("Current health: " + currentHealth);
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag ("Enemy")) {
			isDamaged = true;
		}
	}


}
