using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

	Canvas canvas;

	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey(KeyCode.Escape))
		{
			Pause();
		}
	}
	public void Pause()
	{
		canvas.enabled = !canvas.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

}
