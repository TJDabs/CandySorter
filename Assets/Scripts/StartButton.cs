using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
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
		Application.LoadLevel("Instructions");
	}
}
