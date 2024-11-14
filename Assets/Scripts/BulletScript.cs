using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	public float speed;
	private GameObject playerObject;
	private GameObject playerCamera;

    // Start is called before the first frame update
    void Start(){
		playerObject = GameObject.Find("Player");
		playerCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update(){
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

		if (Vector3.Distance(playerObject.transform.position, transform.position) > 40){
			Destroy(gameObject);
		}
    }

    private void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Enemy")){
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
	}
}
