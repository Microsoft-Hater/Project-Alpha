using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCopy : MonoBehaviour
{
    public float speed;
	public float jumpForce;
	private float horizontalInput;
	private float verticalInput;
	private bool isOnGround = true;
	private int health = 3;

	private float mouseX = 0;
	private float mouseY = 0;
	private float mouseLimit = 18.0f;
	public float mouseSpeed;

	private Rigidbody playerRb;
	private GameObject playerCamera;
	private GameObject playerObject;

	public GameObject bulletPrefab;
	public float fireRate = 1;
	public float untilFire = 0;
	Quaternion playerOrientation;

    // Start is called before the first frame update
    void Start(){
		playerObject = GameObject.Find("Player");
		playerRb = GetComponent<Rigidbody>();
		playerCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");

		mouseX = mouseX + Input.GetAxis("Mouse X");
		mouseY = mouseY + Input.GetAxis("Mouse Y");

		if (mouseY > mouseLimit){
			mouseY = mouseLimit;
		}
		if (mouseY < -mouseLimit){
			mouseY = -mouseLimit;
		}

		float cameraRot = mouseY * mouseSpeed * -1;
		float playerRot = mouseX * mouseSpeed;

		if (Cursor.lockState == CursorLockMode.Locked && health > 0){
			float currentTime = Time.time;
			Vector3 test = new Vector3(horizontalInput, 0, verticalInput);
			playerRb.MovePosition(transform.position + (playerObject.transform.forward * verticalInput * Time.deltaTime * speed) + (playerObject.transform.right * horizontalInput * Time.deltaTime * speed));
			transform.eulerAngles = new Vector3(0, playerRot, 0);
			playerCamera.transform.eulerAngles = new Vector3(cameraRot, transform.eulerAngles.y, 0);

			if (Input.GetMouseButtonDown(0) && currentTime > fireRate + untilFire){
				playerOrientation = Quaternion.Euler(playerCamera.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
				Instantiate(bulletPrefab, transform.position, playerOrientation);
				 untilFire = Time.time;
			}
		}

		if (Input.GetKeyDown(KeyCode.Space) && isOnGround){
			playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isOnGround = false;
		}

		if (Input.GetMouseButtonDown(0)){
			Cursor.lockState = CursorLockMode.Locked;
		}
		else if (Input.GetKeyDown(KeyCode.Escape)){
			Cursor.lockState = CursorLockMode.None;
		}
    }

    private void OnCollisionEnter(Collision collision){
		isOnGround = true;
		if (collision.gameObject.CompareTag("Enemy")){
			health = health - 1;
			if (health <= 0){
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90);
				playerCamera.transform.eulerAngles = new Vector3(playerCamera.transform.eulerAngles.x, transform.eulerAngles.y, -90);
				Cursor.lockState = CursorLockMode.None;
				//Destroy(gameObject);
			}
		}
	}
}
