using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour
{

    public Text shopText;
    private GameObject shopTextGO;
    private Canvas TaskCanvas;
    private Canvas GameCanvas;
    public SimplePlatformContoroler simplePC;
    private bool isActive = false;

    void Start()
    {
        if( simplePC == null )
            simplePC = PoolReference.TableScene[EnumInPool.hero.ToString()].GetComponent<SimplePlatformContoroler>();
        GameCanvas = PoolReference.TableScene[EnumInPool.GameCanvas.ToString()].GetComponent<Canvas>();
        TaskCanvas = PoolReference.TableScene[EnumInPool.TaskCanvas.ToString()].GetComponent<Canvas>();
        shopTextGO = shopText.gameObject;
        shopTextGO.SetActive( false );


    }


    void OnTriggerStay2D( Collider2D other )
    {
        if( other.gameObject.CompareTag( "Player" ) )
        {
            if( Input.GetKeyDown( KeyCode.Return ) )
            {
                simplePC.enabled = false;
                GameCanvas.gameObject.SetActive( isActive );
                TaskCanvas.gameObject.SetActive( !isActive );
                //				Debug.Log ("if(Input.GetKey(KeyCode.E))");
            }
        }

    }

    void OnTriggerEnter2D( Collider2D other )
    {
        if( other.gameObject.CompareTag( "Player" ) )
        {
            shopTextGO.SetActive( true );
            shopText.text = "Enter to shop \n Press key \" Enter \"";
        }
    }

    void OnTriggerExit2D( Collider2D other )
    {

        if( other.gameObject.CompareTag( "Player" ) )
        {
            shopTextGO.SetActive( false );
        }
    }

}
