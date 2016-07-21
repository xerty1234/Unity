using UnityEngine;
using System.Collections;

public class MoveCreateBox : MonoBehaviour {

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



	}
}
