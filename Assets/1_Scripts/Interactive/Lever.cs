using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour
{

    public GameObject ObjectForOpen;

    private Animator animator;
    private bool isStart;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D( Collider2D other )
    {

        if( other.tag == "Player" )
        {
            isStart = !isStart;
            animator.SetBool( "isLock", !animator.GetBool( "isLock" ) );
            Destroy( ObjectForOpen );
        }
    }
}
