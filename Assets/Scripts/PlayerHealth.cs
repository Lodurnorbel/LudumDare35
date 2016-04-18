using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;

	public Slider healthSlider;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		healthSlider.value = currentHealth;
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
		healthSlider.value = currentHealth;
		if (currentHealth <= 0) {
			foreach (Image image in healthSlider.GetComponentsInChildren<Image>()) {
				if (image.CompareTag ("FillArea")) {
					image.enabled = false;
				}
			}
			GetComponent<PlayerController> ().Die ();
		}
		Debug.Log ("Current health: " + currentHealth);
	}
}
