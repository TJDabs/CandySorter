using UnityEngine;
using System.Collections;

public class ShowScores : MonoBehaviour {
	
	public tk2dTextMesh txtTotal;
	public tk2dTextMesh[] txtScores = new tk2dTextMesh[10];
	
	// Use this for initialization
	void Start () {
		
		txtTotal.text = string.Format("Total: " + GameManagerScript.TotalScore);
		txtTotal.Commit();
		
		for(int item = 1; item < txtScores.Length; item++)
		{
			txtScores[item].text = string.Format("Level " + item + ": " + GameManagerScript.lvlScores[item]);
			txtScores[item].Commit();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
