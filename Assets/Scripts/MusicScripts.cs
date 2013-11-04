using UnityEngine;
using System.Collections;

public class MusicScripts : MonoBehaviour {

	public static bool MusicPlaying = false;
	public AudioClip bgmusic;
	
	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
	
	void Start () {
		
		if(MusicPlaying == false)
		{
			audio.clip = bgmusic;
			audio.Play();
			MusicPlaying = true;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
