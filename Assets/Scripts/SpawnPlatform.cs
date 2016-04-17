using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour {

    public GameObject[] obj;
    public GameObject next;
    public float tiempoMin = 1f;
    public float tiempoMax = 2f;
    public GameObject coll;

	// Use this for initialization
	void Start () {
        /*NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeAnda");*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Generar() {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        /*Invoke("Generar", Random.Range(tiempoMin, tiempoMax));*/
    }


    void OnTriggerEnter2D (Collider2D c)
    {
        SpawnPlatform a = (SpawnPlatform)next.GetComponent(typeof(SpawnPlatform));
        a.Generar();
        BoxCollider2D bc = (BoxCollider2D) coll.GetComponent(typeof(BoxCollider2D));
        bc.enabled = false;
    }


}
