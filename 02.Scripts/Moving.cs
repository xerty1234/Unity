using UnityEngine;
using System.Collections;



public class Moving : MonoBehaviour {


	private Transform tr;
	//private bool Collision = false;

	public AudioSource Puch;
	private MeshRenderer re;
	Material mat;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
		re = GetComponent<MeshRenderer> ();
		mat = re.material;
		float emission = 0.5f;
		Color baseColor = Color.red;
		Color finalColro = baseColor * Mathf.LinearToGammaSpace (emission);
		mat.SetColor ("_EmissionColor", finalColro);
	
	}

	void OnCollisionEnter (Collision coll)
	{
		

	}

	void OnCollisionStay (Collision coll)
	{
		if (coll.gameObject.tag == "Player") {
			if (!Puch.isPlaying) {
				Puch.Play ();
			}
				
		}
	

	}

	void OnCollisionExit()
	{
		
	}

}
