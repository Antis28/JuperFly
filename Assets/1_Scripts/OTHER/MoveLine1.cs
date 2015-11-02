using UnityEngine;
using System.Collections;

public class MoveLine1 : MonoBehaviour 
{
	public GameObject go;
	
	public Vector3 _position;
	public Vector3 center;
	
	public void Start()
	{
		// центр движения платформы
		center= go.transform.position;

		// запускаем корутину
		StartCoroutine(MoveLeft());

	}
	IEnumerator Counter(string move)
	{
		int count = 0;
		count++;
		if(count == 10 && move == "MoveLeft"){
			count = 0;
			StopCoroutine (move);
			StartCoroutine("MoveRight");
			StopCoroutine ("Counter");
		}
		if(count == 10 && move == "MoveRight"){
			count = 0;
			StopCoroutine (move);
			StartCoroutine("MoveLeft");
			StopCoroutine ("Counter");
		}
		yield return new WaitForSeconds (0.01f);
	}

	public IEnumerator MoveRight()
	{
		Rigidbody2D rb2d;		
		
		_position = go.transform.position;
		rb2d = go.GetComponent<Rigidbody2D> ();
		rb2d.inertia = 15f;

		while ( center.x <= _position.x + 11) 
		{
			_position = go.transform.position;
			rb2d.AddForce(new Vector2(-100, 0));
			// остановка выполнения функции на 10 миллисекунд
			yield return new WaitForSeconds (0.01f);
			StartCoroutine(Counter("MoveRight"));
		}
		yield return new WaitForSeconds (4f);
		StartCoroutine(MoveLeft());
	}

	public IEnumerator MoveLeft()
	{
		Rigidbody2D rb2d;


		_position = go.transform.position;
		rb2d = go.GetComponent<Rigidbody2D> ();
		rb2d.inertia = 15f;
		
		// перемещение 

		while (center.x >= _position.x - 10) 
		{
			_position = go.transform.position;
			rb2d.AddForce(new Vector2(100, 0));
			// остановка выполнения функции на 10 миллисекунд
			yield return new WaitForSeconds (0.01f);
			StartCoroutine(Counter("MoveLeft"));
			
		}
		yield return new WaitForSeconds (3f);		
		// запускаем корутину снова
		StartCoroutine(MoveRight());
	}
}
