using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class CreateBox : MonoBehaviour {

	public GameObject BoxPrefab;
	public GameObject MoveBoxPrefab;
	public GameObject ClearBoxPrefab;
	public GameObject PlayerPrefab;


	private GameObject Box,MoveBox,ClearBox,DeleteBox;
	//public GameObject MapName;
	private string Name;

	public Transform targetTr;

	public float MAXBox;
	public float Mid;

	public int MAXWidth;
	public int MAXHeight;
	public int movespeed;



	public struct Map
	{
		public float x;
		public float z;
		public int box;
	}

	Map[,] myArray;

	private int whatbox = 0;
	private int plus = 0;
	private Vector3 MousePos; 
	private Vector3 FirstPos;




	// Use this for initialization
	void Start () {



		//tr = GetComponent<Transform>();
		myArray = new Map[MAXWidth+1,MAXHeight+1];	

		float testX = -27, testY = 27;
		whatbox = 1;

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

		Box=GameObject.Find ("CreateBox");
		MoveBox=GameObject.Find ("CreateMoveBox");
		ClearBox=GameObject.Find ("CreateClearBox");
		DeleteBox = GameObject.Find ("DeleteBox");
		Box.SetActive (true);
		MoveBox.SetActive (false);
		ClearBox.SetActive (false);
		DeleteBox.SetActive (false);
		PlayerPrefab.SetActive (false);

	
	}



	// Update is called once per frame
	void Update () {

		if (whatbox == 1) {
			MousePos = Box.transform.position;
		} else if (whatbox == 2) {
			MousePos = MoveBox.transform.position;
		} else if (whatbox == 3) {
			MousePos = ClearBox.transform.position;
		} else if (whatbox == 4) {
			MousePos = PlayerPrefab.transform.position;
		} else if (whatbox == 5) {
			MousePos = DeleteBox.transform.position;
		}


		if (Input.GetKeyDown ("1")) {
			whatbox = 1;
			MousePos.y = 1;
			Box.transform.position = MousePos;
		} else if (Input.GetKeyDown ("2")) {
			whatbox = 2;
			MousePos.y = 1;
			MoveBox.transform.position = MousePos;
		} else if (Input.GetKeyDown ("3")) {
			whatbox = 3;
			MousePos.y = -0.2f;
			ClearBox.transform.position = MousePos;
		} else if (Input.GetKeyDown ("4")) {
			
			whatbox = 4;
			PlayerPrefab.transform.position = MousePos;
		} 
		else if (Input.GetKeyDown ("5")) {
			whatbox = 0;
			DeleteBox.transform.position = MousePos;
		}

		if (Input.GetMouseButtonDown (0)) {
			BoxCreate ();

		}
	

	}


	void BoxLoader()
	{
		int i = 0; 
		int j = 0;

		for ( i = 0; i < MAXWidth; i++) {
			if (myArray [i, j].box == 1) {
				MousePos.x = myArray [i, j].x -Mid;
				MousePos.z = myArray [i, j].z - Mid;
				MousePos.y = 1;
				Instantiate (BoxPrefab, MousePos, Quaternion.identity);
			} else if (myArray [i, j].box == 2) {
				MousePos.x = myArray [i, j].x -Mid;
				MousePos.z = myArray [i, j].z - Mid;
				MousePos.y = 1;
				Instantiate (MoveBoxPrefab, MousePos, Quaternion.identity);
			} else if (myArray [i, j].box == 3) {
				MousePos.x = myArray [i, j].x -Mid;
				MousePos.z = myArray [i, j].z - Mid;
				MousePos.y = - 0.2f;
				Instantiate (ClearBoxPrefab, MousePos, Quaternion.identity);
			}

			for (j = 0; j < MAXHeight; j++) {
				if (myArray [i, j].box == 1) {
					MousePos.x = myArray [i, j].x - Mid;
					MousePos.z = myArray [i, j].z - Mid;
					MousePos.y = 1;
					Instantiate (BoxPrefab, MousePos, Quaternion.identity);
				} else if (myArray [i, j].box == 2) {
					MousePos.x = myArray [i, j].x - Mid;
					MousePos.z = myArray [i, j].z - Mid;
					MousePos.y = 1;
					Instantiate (MoveBoxPrefab, MousePos, Quaternion.identity);
				} else if (myArray [i, j].box == 3) {
					MousePos.x = myArray [i, j].x - Mid;
					MousePos.z = myArray [i, j].z - Mid;
					MousePos.y = -0.2f;
					Instantiate (ClearBoxPrefab, MousePos, Quaternion.identity);
				} else if (myArray [i, j].box == 4) {
					MousePos.x = myArray [i, j].x - Mid;
					MousePos.z = myArray [i, j].z - Mid;
					MousePos.y = -0.2f;
					Instantiate (PlayerPrefab, MousePos, Quaternion.identity);
				}

			}
		}

	}


	public void BoxOutput()
	{
		

		Name = GameObject.Find ("Create UI").GetComponent<CreateName> ().Mapname;



		FileStream  f = new FileStream( Application.dataPath + "\\08.Map\\"+Name+".txt", FileMode.Append, FileAccess.Write);
		StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
		for (int i = 0; i < MAXWidth; i++) {
			writer.WriteLine(myArray [i, plus].box);
			for (plus = 0; plus < MAXHeight; plus++) {
				writer.WriteLine (myArray [i, plus].box);
				if (myArray [i, plus].box != 0) {
					
				}
			}

		}



		//writer.WriteLine(strData);
		writer.Close();
	}



	void BoxInput()
	{
		StreamReader sr = new StreamReader ("Data.txt");
		for (int i = 0; i < MAXWidth; i++) {

			myArray [i, plus].box = Convert.ToInt32 (sr.ReadLine());
			for (plus = 0; plus < MAXHeight; plus++) {
				myArray [i, plus].box = Convert.ToInt32 (sr.ReadLine());
				if (myArray [i, plus].box != 0) {
					
				}
			}

		}

		sr.Close ();


	}

	void BoxCreate()
	{
		int i = 0; 
		int j = 0;


		if (whatbox == 1) {
			MousePos = Box.transform.position;
		} else if (whatbox == 2) {
			MousePos = MoveBox.transform.position;
		} else if (whatbox == 3) {
			MousePos = ClearBox.transform.position;
		} else if (whatbox == 4) {
			MousePos = PlayerPrefab.transform.position;
		} else if (whatbox == 5) {
			MousePos = DeleteBox.transform.position;
		}

		for (i = 0; i < MAXWidth; i++) {
			if ((myArray [i, j].x) -MAXBox < MousePos.x && MousePos.x < myArray [i, j].x &&
				(myArray [i, j].z) -MAXBox < MousePos.z && MousePos.z < myArray [i, j].z) {
				MousePos.x = myArray [i, j].x -Mid;
				MousePos.z = myArray [i, j].z - Mid;
				myArray [i, j].box = whatbox;

			}
			for (j = 0; j < MAXHeight; j++) {
				if ((myArray [i, j].x) -MAXBox < MousePos.x && MousePos.x < myArray [i, j].x &&
					(myArray [i, j].z) -MAXBox < MousePos.z && MousePos.z < myArray [i, j].z) {
					MousePos.x = myArray [i, j].x -Mid;
					MousePos.z = myArray [i, j].z - Mid ;
				
					myArray [i, j].box = whatbox;
				}

			}
		}

		if (whatbox == 1) {
			MousePos.y = 1;
			Instantiate (BoxPrefab, MousePos, Quaternion.identity);
		

		}
		if (whatbox == 2) {
			MousePos.y = 1;
			Instantiate (MoveBoxPrefab, MousePos, Quaternion.identity);
		

		}

		if (whatbox == 3) {
			MousePos.y = - 0.2f;
			Instantiate (ClearBoxPrefab, MousePos, Quaternion.identity);
		
		}

		if (whatbox == 0) {
			
		} 
		else if (whatbox == 4) {
			MousePos.y = 1;
			Instantiate (PlayerPrefab, MousePos, Quaternion.identity);
		}
			

	}





}
