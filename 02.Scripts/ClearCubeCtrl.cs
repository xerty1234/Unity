using UnityEngine;
using System.Collections;

public class ClearCubeCtrl : MonoBehaviour {


	public AudioSource Clear;
	public int cheackBox;

	// Use this for initialization
	void Start () {
		cheackBox = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision coll)
	{
		if (coll.gameObject.tag == "MOVINGBOX") {
			if (!Clear.isPlaying) {
				Clear.Play();
				GameObject.Find ("GamePlay").GetComponent<GamePlay> ().cheackClearPlus ();
			}
		}

	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.tag == "MOVINGBOX") {
			GameObject.Find ("GamePlay").GetComponent<GamePlay> ().cheackClearMinus ();
		}
	}
		
	public int cheack()
	{
		//Debug.Log (cheackBox);
		return cheackBox;
	}

}


