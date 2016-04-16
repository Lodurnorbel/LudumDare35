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
		currentHealth += quantity;
		Debug.Log ("Current health: " + currentHealth);
	}

}
