using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ChangeHealthBy(int quantity) {
		if (quantity < 0 && GetComponent<PlayerController> ().getCharacter () == 0) {
			quantity /= 2; // If zombie, reduce damage by half.
		}
        currentHealth += quantity;
		if (currentHealth > 100) {
			currentHealth = 100;
		}
		if (currentHealth <= 0) {
			GetComponent<PlayerController> ().Die ();
		}
		Debug.Log ("Current health: " + currentHealth);
	}
}
