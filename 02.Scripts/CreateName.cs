using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CreateName : MonoBehaviour {

	public GameObject InputMapN;
	public GameObject NameUI;



	public string Mapname;
		// Use this for initialization
		void Start () {
			//sd = GameObject.Find ("Create UI").GetComponent<GUIText>().text;


		}

		// Update is called once per frame
		void Update () {

			string st;
			st = Application.dataPath + "\\08.Map";
			string[] temp;
			temp = Directory.GetFiles (st);


		}
		
	void OnEnable()
	{
		InputMapN.SetActive (false);
	}

	public void SaveMap()
	{
		InputMapN.SetActive (true);
		NameUI.SetActive(false);

	}

	public void InputName(string name)
	{
			Mapname = name;
			Debug.Log (name);
	}

	public void CancleMap()
	{
		NameUI.SetActive(true);
		InputMapN.SetActive (false);

	}


	}
