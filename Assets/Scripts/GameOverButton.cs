using UnityEngine;
using System.Collections;

public class GameOverButton : MonoBehaviour {

	public tk2dUIItem button;
	public static string GameOverStatus;
	private tk2dTextMesh btnText;
	public GameManagerScript gameScript;

	
	// Use this for initialization
	void Start () {
		btnText = GetComponentInChildren<tk2dTextMesh>();
		
		if(GameOverStatus == "Won")
		{
			btnText.text = string.Format("Next");
		}
		else
		{
			btnText.text = string.Format("Retry");
		}

		btnText.Commit();
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
		if(GameOverStatus == "Won")
		{
			gameScript.setTotalScore();
			//gameScript.Reset();
			GameManagerScript.CurrentLevel ++;
			Debug.Log("Total Score: " + GameManagerScript.TotalScore);
			Debug.Log("Current Lvl: " + GameManagerScript.CurrentLevel);
			if(GameManagerScript.CurrentLevel == 11)
			{
				Application.LoadLevel("GameOver");
			}
			else
			{
				Application.LoadLevel("ShowScore");
				//Application.LoadLevel("Level" + GameManagerScript.CurrentLevel);
			}
		}
		else
		{
			gameScript.Reset();
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
