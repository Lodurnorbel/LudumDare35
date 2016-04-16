using UnityEngine;
using System.Collections;

public class InterfaceManagement : MonoBehaviour {

    public GameObject player;
    public GameObject[] sprites;

    private PlayerMovement pm;

	// Use this for initialization
	void Start () {
        pm = player.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1")){
            pm.setCriature(0);
            sprites[0].GetComponent<UnityEngine.UI.Image>().color = Color.black;
            sprites[1].GetComponent<UnityEngine.UI.Image>().color = Color.grey;
            sprites[2].GetComponent<UnityEngine.UI.Image>().color = Color.green;
        }
        else if (Input.GetKeyDown("2")){
            pm.setCriature(1);
            sprites[0].GetComponent<UnityEngine.UI.Image>().color = Color.red;
            sprites[1].GetComponent<UnityEngine.UI.Image>().color = Color.black;
            sprites[2].GetComponent<UnityEngine.UI.Image>().color = Color.green;
        }
        else if (Input.GetKeyDown("3")){
            pm.setCriature(2);
            sprites[0].GetComponent<UnityEngine.UI.Image>().color = Color.red;
            sprites[1].GetComponent<UnityEngine.UI.Image>().color = Color.grey;
            sprites[2].GetComponent<UnityEngine.UI.Image>().color = Color.black;

        }
	}


}
