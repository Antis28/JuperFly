using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManeger : MonoBehaviour {

    public Text coinText;
    public Text flyText;
    public TaskManeger tm;
    public GameObject hero;
    PoolR poolr;

    

    // Use this for initialization
    void Start () {
        //PoolReference.TableScene.Add( this.name, this.gameObject );        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.R ) )
        {
            if( PoolReference.TableScene[EnumInPool.TaskCanvas.ToString()].activeSelf == false )
            {
                SaveStatus();
                //Application.LoadLevel (Application.loadedLevel);
               // SceneManager.LoadScene( "MiniGame_2" );
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            }
        }
        if( Input.GetKeyDown( KeyCode.Escape ) )
        {
            //Application.LoadLevel( 0 );
            SceneManager.LoadScene( 0 );
            SaveStatus();
        }
        if( Input.GetKeyDown( KeyCode.M ) && !PoolReference.TableScene[EnumInPool.TaskCanvas.ToString()].activeSelf )
        {
            Camera go = GameObject.FindGameObjectWithTag( "Map" ).GetComponent<Camera>();
            go.enabled = !go.enabled;
        }

        if( Input.GetKeyDown( KeyCode.P ) && !PoolReference.TableScene[EnumInPool.TaskCanvas.ToString()].activeSelf )
        {
            if( !PoolReference.TableScene[EnumInPool.TaskCanvas.ToString()].activeSelf )//|| PoolReference.TableScene[EnumInPool.TaskCanvas.ToString()].GetComponent<Canvas>().enabled
                PoolReference.TableScene[EnumInPool.SkillManeger.ToString()].GetComponent<SkillManeger>().DoneButton();
        }
        if( Input.GetKeyDown( KeyCode.F10 ) )
        {
            var dc = PoolReference.TableScene[EnumInPool.DialCanvas.ToString()];
            dc.SetActive( !dc.activeSelf );
                      
        }

    }

    public void SaveStatus()
    {
        try
        {
            coinText = PoolReference.TableScene[EnumInPool.CoinText.ToString()].GetComponent<Text>();
            flyText = PoolReference.TableScene[EnumInPool.BonusFlyText.ToString()].GetComponent<Text>();
            tm = PoolReference.TableScene[EnumInPool.TaskCanvas.ToString()].GetComponent<TaskManeger>();
        
        SaveStats ss = new SaveStats();
        ss.SaveStatistik( coinText.text, "Coin" );

        ss.SaveStatistik( flyText.text, "Fly" );
        if( tm.numTask > 1 )
            ss.SaveStatistik( tm.numTask.ToString(), "NumberTask" );

        Debug.Log( "Save Complite" );        
        } catch { }
        PoolReference.TableScene.Clear(); //Очистка ключей
    }
}
