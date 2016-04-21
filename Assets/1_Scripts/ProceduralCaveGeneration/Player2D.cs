using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour
{

    Rigidbody2D rigidbody;
    Vector2 velosity;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        velosity = new Vector2( Input.GetAxisRaw( "Horizontal" ), Input.GetAxisRaw( "Vertical" ) ).normalized * 10;
    }
    void FixedUpdate()
    {
        rigidbody.MovePosition( rigidbody.position + velosity * Time.fixedDeltaTime );
    }
}
