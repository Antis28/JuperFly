using UnityEngine;
using System.Collections;

public class CorutineTutor : MonoBehaviour 
{
	public Texture2D texture;
	
	private Vector3 _position;
	
	public void Start()
	{
		// запускаем корутину
		StartCoroutine(Coroutine());
	}
	
	public IEnumerator Coroutine()
	{
		// центр экрана
		Vector3 centerScreen = new Vector3(Screen.width/2f, Screen.height/2f, 0);
		
		float time = Time.realtimeSinceStartup;
		
		// перемещение по "кренделю" :)
		_position = centerScreen +
			new Vector3(500 * Mathf.Sin(time), 500 * Mathf.Cos(time), 0) * Mathf.Sin(time / 3);
		
		// остановка выполнения функции на 10 миллисекунд
		yield return new WaitForSeconds(0.01f);
		
		// запускаем корутину снова
		StartCoroutine(Coroutine());
	}
	
	
	public void OnGUI()
	{
		// рисуем текстуру
		GUI.DrawTexture(
			new Rect(
			_position.x - texture.width / 2f,
			_position.y - texture.height / 2f,
			texture.width,
			texture.height
			), texture);
	}

}
