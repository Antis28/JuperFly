using UnityEngine;
using System.Collections;

public class DragonFight : MonoBehaviour
{

    //void OnTriggerEnter2D(Collider2D other)
    void OnCollisionEnter2D(Collision2D coll)

    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("CollisionEnter");
        }
    }
}
