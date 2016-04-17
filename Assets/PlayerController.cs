using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int initialCharacter = 0;

	private int currentCharacter;

	// Use this for initialization
	void Start () {
		currentCharacter = initialCharacter;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getCharacter() {
		return currentCharacter;
	}

	public void changeCharacter(int character) {
		currentCharacter = character;
		GetComponent<PlayerMovement> ().setCriature (character);
	}
}
