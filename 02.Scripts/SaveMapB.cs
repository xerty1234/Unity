using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class SaveMapB : MonoBehaviour {
	private string MapName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RetrunMapName()
	{
		MapName = this.GetComponentInChildren<Text> ().text;
		GameObject.Find ("GamePlay").GetComponent<GamePlay>().MapName(MapName);
	
	}
}
