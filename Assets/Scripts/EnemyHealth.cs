using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

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
		if(currentHealth+quantity <= 100){
			currentHealth += quantity;
		}
		if (currentHealth <= 0) {
			gameObject.GetComponent<EnemyController> ().Die ();
		}
	}
}
