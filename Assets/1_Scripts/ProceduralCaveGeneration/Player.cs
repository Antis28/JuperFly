using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    Rigidbody playerRigidbody;
    Vector3 velosity;

    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        velosity = new Vector3( Input.GetAxisRaw( "Horizontal" ), 0, Input.GetAxisRaw( "Vertical" ) ).normalized * 10;
    }
    void FixedUpdate()
    {
        playerRigidbody.MovePosition( playerRigidbody.position + velosity * Time.fixedDeltaTime );
    }
}
