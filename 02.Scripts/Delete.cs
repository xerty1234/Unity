using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour {
	bool delete;
	private float h = 0.00f;
	private float v = 0.00f;
	private Transform tr;
	public float movespeed;

	// Use this for initialization
	void Start () {
		tr = tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");


		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
		tr.Translate(moveDir.normalized * Time.deltaTime * movespeed, Space.Self);


		if (Input.GetMouseButtonDown (0)) {
			delete = true;
		}
	}

	void OnCollisionStay(Collision coll)
	{

		Debug.Log ("Trugger on");
		if (delete == true) {
			Destroy (coll.gameObject);
			delete = false;
		}
	}
}
