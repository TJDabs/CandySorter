using UnityEngine;
using System.Collections;

public class InstructionsBtnScript : MonoBehaviour {

	public tk2dUIItem button;
	public static int InstructionScreen =1;
	public tk2dSpriteAnimator animation;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
	
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
		if(InstructionScreen == 4)
		{
			InstructionScreen = 1;
			Application.LoadLevel("Menu");
		}
		else
		{
			InstructionScreen++;
			animation.Play("Screen" + InstructionScreen);
			
		}
	}
}
