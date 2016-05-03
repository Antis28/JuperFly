using UnityEngine;
using System.Collections;

public class MusicManeger : MonoBehaviour {

	public GameObject Music;
	// Use this for initialization
	void Awake () {

        var musicPrefab = Resources.Load( "MainMusicInScene" ) as GameObject; // Загружаю музыку из Assets\Resources\Music.prefab
        Music = GameObject.FindGameObjectWithTag ("Music");
		if(Music == null)
		{
            //Music = (GameObject)Instantiate(musicPrefab, new Vector3(0,0,0), Quaternion.identity);
            //Music.transform.parent = gameObject.transform; //начинает музыку сначала

            Music = (GameObject)Instantiate(musicPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Music.transform.parent = gameObject.transform; //присоеденил к объекту в сцене

            DontDestroyOnLoad(this);            
			AudioSource AS = Music.GetComponent<AudioSource> ();
			AS.Play();

		}
		//AudioSource AS = gameObject.GetComponentInChildren<AudioSource> ();
		//AS.Play();
		//AS.loop = true;

	}
}
