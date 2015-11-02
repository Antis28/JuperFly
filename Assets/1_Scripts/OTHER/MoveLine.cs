using UnityEngine;
using System.Collections;

public class MoveLine : MonoBehaviour 
{
	public GameObject go;
	
	public Vector3 _position;
	public Vector3 center;
	
	public void Start()
	{
		// центр движения платформы
		center= go.transform.position;

		// запускаем корутину
		StartCoroutine(Coroutine());

	}

	public IEnumerator Coroutine()
	{
		Rigidbody2D rb2d;


		_position = go.transform.position;
		rb2d = go.GetComponent<Rigidbody2D> ();
		rb2d.inertia = 15f;
		
		// перемещение 
		while ( center.x <= _position.x + 11) 
		{
			_position = go.transform.position;
			rb2d.AddForce(new Vector2(-100, 0));
			// остановка выполнения функции на 10 миллисекунд
			yield return new WaitForSeconds (0.01f);
		}

		yield return new WaitForSeconds (3f);

		while (center.x >= _position.x - 10) 
		{
			_position = go.transform.position;
			rb2d.AddForce(new Vector2(100, 0));
			// остановка выполнения функции на 10 миллисекунд
			yield return new WaitForSeconds (0.01f);
			
		}
		yield return new WaitForSeconds (4f);

		
		// запускаем корутину снова
		StartCoroutine(Coroutine());
	}
}
