using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour {

	void Start() {
		Invoke ("loadMenu", 3.0f);
	}

	void loadMenu() {
		SceneManager.LoadScene ("main menu");
	}
}
