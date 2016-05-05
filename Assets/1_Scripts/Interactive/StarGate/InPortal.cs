using UnityEngine;
using System.Collections;

public class InPortal : MonoBehaviour {

    public Vector3 vec3 = new Vector3 (211f, 87f, 0f);
    public Transform exitPortal;
    public GameObject destroyCave;

    

    void Start()
    {
        
        
    }

    void OnTriggerStay2D( Collider2D other )
    {

        if( (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown( KeyCode.Return ) ) && other.gameObject.CompareTag( "Player" ) || other.name == "hero" )
        {
            if( exitPortal != null )
            {
                other.gameObject.GetComponent<RectTransform>().position = exitPortal.position;
                //Destroy( destroyCave );
                return;
            }
            //other.gameObject.GetComponent<RectTransform>().position = vec3;
        }
    }

    
}
