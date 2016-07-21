using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    public Transform targetTr;
    private Transform tr;
    public float dist = 10.0f;
    public float height = 3.0f;
    public float dampTraace = 20.0f;

	private GameObject Box, MoveBox, ClearBox;


	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
		//int i = GameObject.Find ("GameManager").GetComponent<GameMgr>().GameState;
		//Debug.Log (i);
		//if (i == 10) {
		//	targetTr = GameObject.Find ("Player").GetComponent<Transform> ();
	//	} else if (i == 100) {
	//		targetTr = GameObject.Find ("CreateBox").GetComponent<Transform> ();
	//	}
	
    }

	public void SetCam (int i){
		//int i = GameObject.Find ("GameManager").GetComponent<GameMgr>().GameState;

		if (i == 10) {
			targetTr = GameObject.Find ("Player").GetComponent<Transform> ();
			} else if (i == 100) {
				targetTr = GameObject.Find ("CreateBox").GetComponent<Transform> ();
				height = 35;
			}

	}
	
	// Update is called once per frame
	void Update () {
	    
		if (Input.GetKeyDown ("9")) {
			targetTr = GameObject.Find ("CreateBox").GetComponent<Transform> ();
			//tr = GetComponent<Transform>();

		} else if (Input.GetKeyDown ("4")) {
			targetTr = GameObject.Find ("Player").GetComponent<Transform> ();
			tr = GetComponent<Transform> ();
		
		}
		else if (Input.GetKeyDown ("1")) {
			targetTr = GameObject.Find ("CreateBox").GetComponent<Transform> ();
			tr = GetComponent<Transform> ();
		}
		else if (Input.GetKeyDown ("2")) {
			targetTr = GameObject.Find ("CreateMoveBox").GetComponent<Transform> ();
			tr = GetComponent<Transform> ();
		}

		else if (Input.GetKeyDown ("3")) {
			targetTr = GameObject.Find ("CreateClearBox").GetComponent<Transform> ();
			tr = GetComponent<Transform> ();
		}
		else if (Input.GetKeyDown ("5")) {
			targetTr = GameObject.Find ("DeleteBox").GetComponent<Transform> ();
			tr = GetComponent<Transform> ();
		}


	}

    void LateUpdate()
    {

	
        tr.position = Vector3.Lerp(tr.position, targetTr.position - (targetTr.forward * dist)
            + (Vector3.up * height)
            , Time.deltaTime * dampTraace);
        tr.LookAt(targetTr.position);

    }
}
