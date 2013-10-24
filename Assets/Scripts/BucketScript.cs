using UnityEngine;
using System.Collections;

public class BucketScript : MonoBehaviour {
	
	public string BucketType;
	public string BucketSubType;
	public GameManagerScript gameScript;
	
	public string[] trashCandy = new string[1];
	
	bool isTrash = false;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		
		if(collision.gameObject.tag == "Candy")
		{
			
			if(BucketType == "Trash")
			{
				for(int i = 0; i < trashCandy.Length; i++)
				{
					if(collision.gameObject.GetComponent<CandyScript>().TrashName == trashCandy[i])
					{
						isTrash = true;
					}
				}
				if(isTrash == true)
				{
					CorrectType();
				}
				else
				{
					IncorrectType();
				}
			}
			else if(BucketSubType == "None") //Only Check Type
			{
				if (BucketType == collision.gameObject.GetComponent<CandyScript>().Type)
				{
					CorrectType();
				}
				else
				{
					IncorrectType();
				}
			}
			else if(BucketType == "None") //Only Check SubType
			{
				if (BucketSubType == collision.gameObject.GetComponent<CandyScript>().SubType)
				{
					CorrectType();
				}
				else
				{
					IncorrectType();
				}
			}
			else //Check Type and SubType
			{
				if (BucketType == collision.gameObject.GetComponent<CandyScript>().Type && BucketSubType == collision.gameObject.GetComponent<CandyScript>().SubType)
				{
					CorrectType();
				}
				else
				{
					IncorrectType();
				}
			}
			
		}
		
		Destroy(collision.gameObject);
	}
	
	void CorrectType()
	{
		gameScript.CollectCandy(true);
		isTrash = false;
	}
	
	void IncorrectType()
	{
		gameScript.CollectCandy(false);
		isTrash = false;
	}
}
