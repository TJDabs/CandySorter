using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {
	
	public Transform[] CandiePrefabs = new Transform[8];
	public tk2dTextMesh txtScore;
	public tk2dTextMesh txtCorrect;
	public tk2dTextMesh txtIncorrect;
	public tk2dTextMesh txtCandyRemaining;
	public tk2dTextMesh txtGameOverMsg;
	public tk2dFontData myFont;
	
	public GameObject gameOverButton;
	public GameObject ChatWindow;
	
	private Vector3 spawnLocation;
	
	private float timer;
	private bool stopGame;
	public static bool chatUp;
	public AudioClip btnSound;
	private bool startup;
	
	public static int CurrentLevel = 1;
	public static int[] lvlScores = new int[11];
	
	public static int Score;
	public static int TotalScore;
	
	public static int Correct;
	public static int Incorrect;
	public static string btnStatus;
	public int CandyRemaining;
	public int MissesAllowed = 3;
	
	private int startingAmount;
	
	public AudioClip sfxCorrect;
	public AudioClip sfxIncorrect;
	public AudioClip sfxLevelUp;
	public AudioClip sfxGameOver;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Current Level: " + CurrentLevel);
		Debug.Log("Total: " + TotalScore);
		Debug.Log("1: " + lvlScores[1]);
		Debug.Log("2: " + lvlScores[2]);
		Debug.Log("3: " + lvlScores[3]);
		Debug.Log("4: " + lvlScores[4]);
		Debug.Log("5: " + lvlScores[5]);
		Debug.Log("6: " + lvlScores[6]);
		Debug.Log("7: " + lvlScores[7]);
		Debug.Log("8: " + lvlScores[8]);
		Debug.Log("9: " + lvlScores[9]);
		Debug.Log("10: " + lvlScores[10]);
		
		startup = true;
		chatUp = true;
		stopGame = false;
		timer = 1.5f;
		startingAmount = CandyRemaining;
		//txtGameOverMsg.font = myFont;
		//txtGameOverMsg.scale = new Vector3(1,1,1);
		
		spawnLocation = new Vector3(-30, 0, 0);
		spawnCandie();
	}
	
	// Update is called once per frame
	void Update () {
		if(startup)
		{
			ChatWindow.SetActive(true);
			Startup();
		}
		
		if(stopGame == false)
		{
		
			if(Incorrect >= MissesAllowed)
			{
				GameOver(false);
			}
			
			if((Correct + Incorrect) == startingAmount && Incorrect != MissesAllowed)
			{
				stopGame = true;
				GameOver(true);
			}
		

			if(CandyRemaining > 0)
			{
				timer -= Time.deltaTime;
		
				if(timer <= 0)
				{
					spawnCandie();
					timer = 1.5f;
				}
			}
			
			txtScore.text = string.Format("" + lvlScores[CurrentLevel]);
			txtScore.Commit();
		
			txtCorrect.text = string.Format("" + Correct);
			txtCorrect.Commit();
		
			txtIncorrect.text = string.Format("" + Incorrect);
			txtIncorrect.Commit();
		
			txtCandyRemaining.text = string.Format("" + CandyRemaining);
			txtCandyRemaining.Commit();
		}
		//Backdoor
		if(Input.GetButtonDown("Jump"))
		{
			GameOver(true);
		}
	}
	
	void Startup()
	{
		if(chatUp == true)
		{
			Time.timeScale = 0;
			if(Input.GetMouseButtonUp(0))
			{
				chatUp = false;
			}
		}
		else
		{
			startup = false;
			ChatWindow.SetActive(false);
			audio.PlayOneShot(btnSound);
			Time.timeScale = 1.0f;
		}
	}
	
	void spawnCandie()
	{
		int randNum = Random.Range(0,CandiePrefabs.Length);
		//Debug.Log(randNum);
		
		Instantiate(CandiePrefabs[randNum], spawnLocation, Quaternion.identity);
		CandyRemaining --;
	}
	
	public void CollectCandy(bool CorrectCandy)
	{
		if(CorrectCandy == true)
		{
			lvlScores[CurrentLevel] += 10;
			Correct ++;
			audio.PlayOneShot(sfxCorrect);
		}
		else
		{
			lvlScores[CurrentLevel] -= 5;
			Incorrect ++;
			audio.PlayOneShot(sfxIncorrect);
		}
	}
	
	void GameOver(bool Won)
	{
		Time.timeScale = 0;
		stopGame = true;
		gameOverButton.SetActive(true);
		
		if(Won == true)
		{
			audio.PlayOneShot(sfxLevelUp);
			GameOverButton.GameOverStatus = "Won";
			txtGameOverMsg.text = string.Format("Order Completed!");
			txtGameOverMsg.Commit();
		}
		else
		{
			audio.PlayOneShot(sfxGameOver);
			GameOverButton.GameOverStatus = "Lost";
			txtGameOverMsg.text = string.Format("Order Failed");
			txtGameOverMsg.Commit();
		}
	}
	
	public void Reset()
	{
		Time.timeScale = 1.0f;
		lvlScores[CurrentLevel] = 0;
		Correct = 0;
		Incorrect = 0;
	}
	
	public void setTotalScore()
	{
		Time.timeScale = 1.0f;
		TotalScore += lvlScores[CurrentLevel];
		Correct = 0;
		Incorrect = 0;
	}
	
}
