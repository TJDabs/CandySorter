using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {
	
	public tk2dUIItem button;
	public GameObject CheatSheet;
	
	// Use this for initialization
	void Start () {
		CheatSheet.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManagerScript.chatUp == false)
		{
			gameObject.GetComponent<tk2dUIItem>().enabled = true;
		}
	}
	
	void OnEnable()
	{
		button.OnDown += ButtonDown;
		button.OnUp += ButtonUp;

	}
	
	void OnDisable()
	{
		button.OnDown -= ButtonDown;
		button.OnUp -= ButtonUp;
	}
	
	void ButtonDown()
	{
		Time.timeScale = 0;
		CheatSheet.SetActive(true);
	}
	
	void ButtonUp()
	{
		Time.timeScale = 1.0f;
		CheatSheet.SetActive(false);
	}
}
