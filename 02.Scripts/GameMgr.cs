using UnityEngine;
using System.Collections;
using System.IO;

public class GameMgr : MonoBehaviour {


	public GameObject BoxPrefab;
	public GameObject PlyerPrefab;

	public GameObject Box,MoveBox,ClearBox,DeleteBox;


	public GameObject CreteMap;
	public GameObject StartScene;
	public GameObject ClearMapScene;

	public GameObject GamePlay;
	public GameObject CreateMap;



	public int GameState;
	private FollowCam script;

	// Use this for initialization
	void Start () {

		GamePlay.SetActive (false);
		CreateMap.SetActive (false);


	}


	
	public void OnClickStartBtn()
	{
		GamePlay.SetActive (true);
		CreateMap.SetActive (false);
		StartScene.SetActive(false);


		GameState = 10;
		GameObject.Find("Main Camera").GetComponent<FollowCam>().SetCam(GameState);
		GameObject.Find ("GamePlay").GetComponent<GamePlay> ().setGameStart (GameState);

	}

	public void OnClickCreateBtn()
	{
		GamePlay.SetActive (false);
		CreateMap.SetActive (true);
		StartScene.SetActive(false);
	
		GameState = 100;
		GameObject.Find("Main Camera").GetComponent<FollowCam>().SetCam(GameState);
	}

	public void OnClickMenu()
	{
		GamePlay.SetActive (false);
		CreateMap.SetActive (false);
		StartScene.SetActive(true);
		ClearMapScene.SetActive (false);
	}


	// Update is called once per frame
	void Update () {



			if (Input.GetKeyDown ("1")) {
				Box.SetActive (true);
				MoveBox.SetActive (false);
				ClearBox.SetActive (false);
				DeleteBox.SetActive (false);

			} else if (Input.GetKeyDown ("2")) {
				Box.SetActive (false);
				MoveBox.SetActive (true);
				ClearBox.SetActive (false);
				DeleteBox.SetActive (false);
		
			} else if (Input.GetKeyDown ("3")) {
				Box.SetActive (false);
				MoveBox.SetActive (false);
				ClearBox.SetActive (true);
				DeleteBox.SetActive (false);

			} else if (Input.GetKeyDown ("5")) {
				DeleteBox.SetActive (true);
				Box.SetActive (false);
				MoveBox.SetActive (false);
				ClearBox.SetActive (false);

			}
		}
	

    
}
