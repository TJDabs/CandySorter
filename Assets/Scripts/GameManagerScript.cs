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
	
	public GameObject gameOverButton;
	public GameObject ChatWindow;
	
	private Vector3 spawnLocation;
	
	private float timer;
	private bool stopGame;
	private bool chatUp;
	private bool startup;
	
	public static int CurrentLevel = 1;
	public static int Score;
	public static int Correct;
	public static int Incorrect;
	public static string btnStatus;
	public int CandyRemaining;
	public int MissesAllowed = 3;
	
	public static int TotalScore;
	
	private int startingAmount;
	
	public AudioClip sfxCorrect;
	public AudioClip sfxIncorrect;
	
	// Use this for initialization
	void Start () {
		startup = true;
		chatUp = true;
		stopGame = false;
		timer = 1.5f;
		startingAmount = CandyRemaining;
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
			
			txtScore.text = string.Format("Score: " + Score);
			txtScore.Commit();
		
			txtCorrect.text = string.Format("Correct: " + Correct);
			txtCorrect.Commit();
		
			txtIncorrect.text = string.Format("Missed: " + Incorrect);
			txtIncorrect.Commit();
		
			txtCandyRemaining.text = string.Format("Candy Remaining: " + CandyRemaining);
			txtCandyRemaining.Commit();
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
			Score += 10;
			Correct ++;
			audio.PlayOneShot(sfxCorrect);
		}
		else
		{
			Score -= 5;
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
			GameOverButton.GameOverStatus = "Won";
			txtGameOverMsg.text = string.Format("Order Completed!");
			txtGameOverMsg.Commit();
		}
		else
		{
			GameOverButton.GameOverStatus = "Lost";
			txtGameOverMsg.text = string.Format("Order Failed");
			txtGameOverMsg.Commit();
		}
	}
	
	public void Reset()
	{
		Time.timeScale = 1.0f;
		Score = 0;
		Correct = 0;
		Incorrect = 0;
	}
	
	public void setTotalScore()
	{
		TotalScore += Score;
	}
}
