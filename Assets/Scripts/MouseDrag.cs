using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;
	
	Rigidbody myRigidBod;
	//private CandyScript candyScript;
	GameObject gameManager;
	
	public bool Pickedup = false;
	public int Speed = 5;
	
	// Use this for initialization
	void Start () {
		
		gameManager = GameObject.FindGameObjectWithTag("GameManager"); 
		//candyScript = GetComponent<CandyScript>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Pickedup != true)
		{
			transform.Translate(Vector3.right * Time.deltaTime* Speed);
		}
		
		if(transform.position.x >= 27 || transform.position.y <= -16)
		{
			gameManager.GetComponent<GameManagerScript>().CollectCandy(false);
			Destroy(gameObject);
		}
	
	}
	
	void OnMouseDown()
	{
		Pickedup = true;
		rigidbody.velocity = new Vector3(0,0,0);
		
		Vector3 currentPos = new Vector3(0,0,0);
		currentPos = transform.position;
		transform.position = new Vector3(currentPos.x, currentPos.y, -2);
		
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
	}
	
	void OnMouseDrag()
	{
		
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		
		transform.position = curPosition;
		
	}
	
	void OnMouseUp()
	{
		rigidbody.useGravity = true;
		Vector3 currentPos = new Vector3(0,0,0);
			currentPos = transform.position;
			transform.position = new Vector3(currentPos.x, currentPos.y, -1);
		/*if(transform.position.y <= -4.5)
		{
			Vector3 currentPos = new Vector3(0,0,0);
			currentPos = transform.position;
			transform.position = new Vector3(currentPos.x, currentPos.y, 0);
		}
		*/
	}
}
