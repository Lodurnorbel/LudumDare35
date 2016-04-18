using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int initialCharacter = 0;
	public AudioClip[] spawnAudios;
    public Animation[] animations;

	private int currentCharacter;
	private AudioSource audioSource;
    private Animator animator; 

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		changeCharacter (initialCharacter);

		/*currentCharacter = initialCharacter;

		audioSource.clip = spawnAudios [initialCharacter];
		audioSource.Play ();*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getCharacter() {
		return currentCharacter;
	}

	public void changeCharacter(int character) {
		currentCharacter = character;
		audioSource.clip = spawnAudios [character];
		audioSource.Play ();
	}

	public void Die() {
		foreach (Collider2D coll in GetComponentsInChildren<Collider2D>()) {
			coll.enabled = false;
		}
		GetComponent<PlayerMovement> ().enabled = false;
        GameObject.FindGameObjectWithTag("gameover").SetActive(true);
        Destroy (this, 3.0f);
	}
}
