using UnityEngine;
using System.Collections;

public class MoveSpiral : MonoBehaviour 
{
	public GameObject go;
	
	private Vector3 _position;
	
	public void Start()
	{
		// запускаем корутину
		StartCoroutine(Coroutine());
	}
	
	public IEnumerator Coroutine()
	{
		// центр экрана
		Vector3 centerScreen = go.transform.position;
		
		float time = Time.realtimeSinceStartup;
		
		// перемещение по "кренделю" :)
		_position = centerScreen +
			new Vector3(0.1f * Mathf.Sin(time), 0.1f * Mathf.Cos(time), 0) * Mathf.Sin(time / 9);
		
		//
		go.transform.position = _position;
		
		// остановка выполнения функции на 10 миллисекунд
		yield return new WaitForSeconds(0.01f);
		
		// запускаем корутину снова
		StartCoroutine(Coroutine());
	}
	
}
