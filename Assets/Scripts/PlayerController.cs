using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	private float horizontalInput;
	private float verticalInput;
	private bool isOnGround = true;

	private float mouseX;
	private float mouseY;
	public float mouseSpeed;

	private Rigidbody playerObject;
	private GameObject playerCamera;

    // Start is called before the first frame update
    void Start(){
		playerObject = GetComponent<Rigidbody>();
		playerCamera = GameObject.Find("Main Camera");;
    }

    // Update is called once per frame
    void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");

		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");

		transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
		transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

		transform.Rotate(Vector3.up * mouseX * mouseSpeed);
		playerCamera.transform.Rotate(Vector3.left * mouseY * mouseSpeed);

		if (Input.GetKeyDown(KeyCode.Space) && isOnGround){
			playerObject.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isOnGround = false;
		}

		if (Input.GetKeyDown(KeyCode.C)){
			Cursor.lockState = CursorLockMode.Locked;
		}
		else if (Input.GetKeyDown(KeyCode.Escape)){
			Cursor.lockState = CursorLockMode.None;
		}
    }

    private void OnCollisionEnter(Collision collision){
		isOnGround = true;
	}
}
