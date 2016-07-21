using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;

public class GamePlay : MonoBehaviour {

	public GameObject Player;
	public GameObject MovingCube;
	public GameObject ClearCube;
	public GameObject Cube;
	public GameObject GameClearSence;
	public GameObject GameUI;

	public GameObject MapIcon;
	public RectTransform ParentPanel;

	public float MAXBox;
	public float Mid;

	public int MAXWidth;
	public int MAXHeight;
	 GameObject[] MapObject;

	public int testNum;


	public struct Map
	{
		public float x;
		public float z;
		public int box;
	}

	Map[,] myArray;


	private int plus = 0;
	private Vector3 MousePos; 
	private Vector3 FirstPos;
	private int GameStart;
	private int Gamecheak;
	private int GameClearNum;
	private int WhatNumBox;

	private int delayClear;
	public string StartMapName;



	// Use this for initialization
	void Start () {
		
		myArray = new Map[MAXWidth + 1, MAXHeight + 1];	
		float testX = -27, testY = 27;
		for (int i = 0; i < MAXWidth; i++) {
			myArray [i, plus].x = testX + MAXBox ;
			testX = myArray [i, plus].x;
			myArray [i, plus].box = 0;


			for (plus = 0; plus < MAXHeight; plus++) {
				myArray [i, plus].x = testX;
				myArray [i,plus].z = testY - MAXBox;
				testY = myArray [i, plus].z;

				myArray [i, plus].box = 0;
			}
			testY = 27;
		}

		Gamecheak = 0;
		GameClearNum = 0;
		GameClearSence.SetActive (false);

	

	}

	public void setGameStart(int i)
	{
		GameStart = i;
	}

	void OnEnable(){

		WhatNumBox = 0;
	}

	void OnDisable()
	{
			for (int i = 0; i < WhatNumBox; i++) {
				Destroy (MapObject [i]);
			}

	}


	// Update is called once per frame
	void Update () {
			
		if (GameStart == 10) {
			delayClear = 0;
			OnDisable ();
			MovingCube.SetActive (true);
			ClearCube.SetActive (true);
			Cube.SetActive (true);
			GameClearSence.SetActive (false);
			GameUI.SetActive (true);
			TestMapSelect ();
			GameStart = 11;

		} 
		else if (GameStart == 12) {
			BoxInput ();
			BoxLoder ();
			GameStart = 13;
		}

		else if (GameStart == 13) {
			playing ();

		}

	}



	void playing()
	{
		if (delayClear > 220) {
			if (Gamecheak == GameClearNum) {
				Debug.Log ("GameClear");
				GameClearSence.SetActive (true);
				this.gameObject.SetActive (false);
			}
		}
		else {
			delayClear++;
		}
	}

	public void cheackClearPlus()
	{
		Gamecheak++;
		Debug.Log (Gamecheak);
	}


	public void cheackClearMinus()
	{
		Gamecheak--;
		Debug.Log (Gamecheak);
	}


	void TestMapSelect()
	{
		
		System.IO.DirectoryInfo di = new System.IO.DirectoryInfo (Application.dataPath+"\\08.Map");
		int a = 0;


		GameObject Panel;


		Panel = GameObject.Find ("Panel");

		foreach (var fi in di.GetFiles()) {

			if (a % 2 == 0) {
				Debug.Log (fi.Name);
				MapIcon = Instantiate(MapIcon)as GameObject;
				//MapIcon.transform.SetParent (ParentPanel, false);

				//string sd = fi.Name;

				Button tempButton = MapIcon.GetComponent<Button> ();
				tempButton.transform.localScale = new Vector3 (1, 1, 1);
				tempButton.transform.position = new Vector3 (902, 440-(a * 30), 0);

				Text tempText = MapIcon.GetComponentInChildren<Text> ();
				tempText.text = fi.Name;

				MapIcon.transform.parent  = Panel.transform; 
			}
			a++;

	
		}

		Debug.Log (a);

	}

	void BoxLoder()
	{
		int i = 0; 
		int j = 0;
		WhatNumBox = 0;
		MapObject = new GameObject[MAXWidth * MAXHeight];

		for ( i = 0; i < MAXWidth; i++) {
			if (myArray [i, j].box == 1) {
				MousePos.x = myArray [i, j].x - Mid;
				MousePos.z = myArray [i, j].z - Mid;
				MousePos.y = 1;
				MapObject [WhatNumBox] = Instantiate (Cube, MousePos, Quaternion.identity)as GameObject;
				WhatNumBox++;
	
			} else if (myArray [i, j].box == 2) {
				MousePos.x = myArray [i, j].x - Mid;
				MousePos.z = myArray [i, j].z - Mid;
				MousePos.y = 1;
				MapObject [WhatNumBox] = Instantiate (MovingCube, MousePos, Quaternion.identity)as GameObject;
				WhatNumBox++;
		
			} else if (myArray [i, j].box == 3) {
				MousePos.x = myArray [i, j].x - Mid;
				MousePos.z = myArray [i, j].z - Mid;
				MousePos.y = -0.2f;
				MapObject [WhatNumBox] = Instantiate (ClearCube, MousePos, Quaternion.identity)as GameObject;
				WhatNumBox++;
				GameClearNum++;
		
			} else if (myArray [i, j].box == 4) {
				Player.transform.position = MousePos;
			}

			for (j = 0; j < MAXHeight; j++) {
				if (myArray [i, j].box == 1) {
					MousePos.x = myArray [i, j].x -Mid;
					MousePos.z = myArray [i, j].z - Mid;
					MousePos.y = 1;
					MapObject[WhatNumBox] =Instantiate (Cube, MousePos, Quaternion.identity)as GameObject;
					WhatNumBox++;
			
				} else if (myArray [i, j].box == 2) {
					MousePos.x = myArray [i, j].x -Mid;
					MousePos.z = myArray [i, j].z - Mid;
					MousePos.y = 1;
					MapObject[WhatNumBox] =Instantiate (MovingCube, MousePos, Quaternion.identity)as GameObject;
					WhatNumBox++;
				} else if (myArray [i, j].box == 3) {
					MousePos.x = myArray [i, j].x -Mid;
					MousePos.z = myArray [i, j].z - Mid;
					MousePos.y = - 0.2f;
					MapObject[WhatNumBox] =Instantiate (ClearCube, MousePos, Quaternion.identity)as GameObject;
					GameClearNum++;
					WhatNumBox++;
				
				}


			}
		}
	}



	void BoxInput()
	{
		StreamReader sr = new StreamReader (Application.dataPath +"\\08.Map\\"+StartMapName);
		for (int i = 0; i < MAXWidth; i++) {
				myArray [i, plus].box = Convert.ToInt32 (sr.ReadLine ());	
			for (plus = 0; plus < MAXHeight; plus++) {				
					myArray [i, plus].box = Convert.ToInt32 (sr.ReadLine());
			
			}

		}

		sr.Close ();
	}
		
	public void MapName(string Name)
	{
		StartMapName = Name;
		Debug.Log (StartMapName);
		GameStart = 12;
		//OnDisable ();
		GameUI.SetActive (false);
	}




}
