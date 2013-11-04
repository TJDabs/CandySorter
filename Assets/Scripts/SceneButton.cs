using UnityEngine;
using System.Collections;

public class SceneButton : MonoBehaviour {
	
	public tk2dUIItem button;
	public string Scene;
	
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
		if(Scene == "NextLevel")
		{
			Application.LoadLevel("Level" + GameManagerScript.CurrentLevel);
		}
		else
		{
			Application.LoadLevel(Scene);
		}
	}
}
