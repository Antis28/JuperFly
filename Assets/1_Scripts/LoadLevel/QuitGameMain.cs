using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class QuitGameMain : MonoBehaviour
{ //MainMenu

    public void NewGame()
	{
		Application.LoadLevel (1);
	}
	public void QuitGame()
	{
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
