using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {
	
	public tk2dUIItem button;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable()
	{
		button.OnClick += Clicked;
	}
	
	void OnDisable()
	{
		button.OnClick -= Clicked;
	}
	
	void Clicked()
	{
		GameManagerScript.TotalScore = 0;
		GameManagerScript.CurrentLevel = 1;
		Application.LoadLevel("Title");
	}
}
