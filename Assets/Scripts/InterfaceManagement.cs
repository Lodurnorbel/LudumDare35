using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InterfaceManagement : MonoBehaviour {

    public GameObject player;
    public GameObject[] sprites;
    private PlayerHealth ph;
    public bool showbar;
    public int blood;

    private PlayerMovement pm;

    public void buttonmenu()
    {
        SceneManager.LoadScene("1");
    }

    // Use this for initialization
    void Start () {
        pm = player.GetComponent<PlayerMovement>();
        ph = player.GetComponent<PlayerHealth>();
        blood = 90;
    }
	
	// Update is called once per frame
	void Update () {
        barDisplay = ph.currentHealth * 0.01f;
        barDisplay2 = blood * 0.01f;

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

        if(blood == 100 & Input.GetKeyDown(KeyCode.K)){
            ph.ChangeHealthBy(10);
            blood = 0;
        }

	}

    public float barDisplay, barDisplay2; //current progress
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(300, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    void OnGUI()
    {
        if (showbar) { 
            //draw the background:
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

            //draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
            GUI.EndGroup();
            GUI.EndGroup();

            //draw the background:
            GUI.BeginGroup(new Rect(pos.x, pos.y+50, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

            //draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay2, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
            GUI.EndGroup();
            GUI.EndGroup();
        }
    }

    public void drink(){
        if(blood < 100) {blood += 10;}
    }

}
