using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{

    public Text coinText;
    public Text flyText;
    public TaskManeger tm;
    public GameObject hero;
    PoolR poolr;

    bool isSave = true;

    void Start()
    {
        poolr = GameObject.Find( "PoolReference" ).GetComponent<PoolR>();
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.R ) )
        {
            if( poolr.TaskCanvas.gameObject.activeSelf == false )
            {
                SaveStatus();
                //Application.LoadLevel (Application.loadedLevel);
                SceneManager.LoadScene( "MiniGame_2" );
            }
        }
        if( Input.GetKeyDown( KeyCode.Escape ) )
        {
            //Application.LoadLevel( 0 );
            SceneManager.LoadScene( 0 );
            SaveStatus();
        }
        if( Input.GetKeyDown( KeyCode.M ) )
        {
            Camera go = GameObject.FindGameObjectWithTag( "Map" ).GetComponent<Camera>();
            go.enabled = !go.enabled;
        }

        if( Input.GetKeyDown( KeyCode.P ) )
            PoolReference.TableScene["SkilsCanvas"].GetComponent<SkillManeger>().DoneButton();

    }

    void OnTriggerEnter2D( Collider2D other )
    {

        if( other.gameObject.CompareTag( "Player" ) || other.name == "hero" )
        {
            if( isSave )
            {
                SaveStatus();
                Application.LoadLevel( Application.loadedLevel );
            }
        }
        if( other.gameObject.CompareTag( "Ground" ) )
        {
            GameObject.Destroy( other.gameObject );
        }

    }
    void SaveStatus()
    {
        PoolReference.TableScene.Clear(); //Очистка ключей

        SaveStats ss = new SaveStats();
        ss.SaveStatistik( coinText.text, "Coin" );

        ss.SaveStatistik( flyText.text, "Fly" );
        if( tm.numTask > 1 )
            ss.SaveStatistik( tm.numTask.ToString(), "NumberTask" );

        Debug.Log( "Save Complite" );
        isSave = false;

    }
}
