using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class NoGravityMoves : MonoBehaviour
{
    public float speed = 2f;
	public float mouseSensitivity = 2f;
	public float jumpSpeed = 3f;

	private float rotationLeftRight;
	private float verticalRotation;
	private float forwardspeed;
	private float sideSpeed;
	private float verticalVelocity; 
	private Vector3 speedCombined;
	private CharacterController cc;

	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponentInChildren<Camera> ();
		cc = GetComponent<CharacterController> ();
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		rotationLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotationLeftRight,0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -60f, 60f);
		cam.transform.localRotation = Quaternion.Euler (verticalRotation, 0,0);

		forwardspeed = Input.GetAxis ("Vertical") * speed;
		sideSpeed = Input.GetAxis ("Horizontal") * speed;

		verticalVelocity += (Physics.gravity.y / 3) * Time.deltaTime;

		if (cc.isGrounded && Input.GetButtonDown ("Jump")) {
			verticalVelocity = jumpSpeed;
		}

		speedCombined = new Vector3 (sideSpeed, verticalVelocity, forwardspeed);

		speedCombined = transform.rotation * speedCombined;

		cc.Move (speedCombined * Time.deltaTime);

	}

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            UnityEngine.Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            UnityEngine.Debug.Log(collision.relativeVelocity);
    }
}
