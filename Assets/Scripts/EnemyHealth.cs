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
		
		if(currentHealth > 0){
			currentHealth += quantity;
			Debug.Log ("Enemy #" + GetInstanceID () + " changed health by " + quantity);
			if (currentHealth <= 0) {
				gameObject.GetComponent<EnemyController> ().Die ();
			}
			if (currentHealth > 100) {
				currentHealth = 100;
			}
		}

	}
}
