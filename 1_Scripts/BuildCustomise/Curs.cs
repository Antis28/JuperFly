using UnityEngine;
using System.Collections;

public class Curs : MonoBehaviour {

	public Texture2D Textur;
	public CursorMode cursM = CursorMode.ForceSoftware;
	public Vector2 vec = Vector2.zero;
	
	// Update is called once per frame
	void Update () {
		Cursor.SetCursor (Textur, vec, cursM);
	}
}
