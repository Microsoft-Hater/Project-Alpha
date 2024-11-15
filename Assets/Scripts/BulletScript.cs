// B00164190
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour{
	// Variables Needed For The Bullet
	public float speed;
	private GameObject playerObject;

    // Start is called before the first frame update
    void Start(){
		// Setting playerObject To The Player
		playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){
		// Moving The Bullet Every Frame
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

		// Until It Is 40 Units Away From The Player
		// I Ended Up Comming Across Vector3.Distance While Making The Player Controller Script
		// And Thought I Can Use It Here.
		// Gotta Love Unity Documentation
		if (Vector3.Distance(playerObject.transform.position, transform.position) > 40){
			Destroy(gameObject);
		}
    }

    private void OnTriggerEnter(Collider other){
		// If Statement That Runs If The Bullet Collides With An Object With The Enemy Tag
		// It Destroys The Bullet And Enemy
		if (other.gameObject.CompareTag("Enemy")){
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
	}
}
