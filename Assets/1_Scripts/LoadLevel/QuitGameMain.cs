using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class QuitGameMain : MonoBehaviour
{ //MainMenu

    string pathToSave = "Data/Save";

    public void NewGame()
    {
        int count = 1;
        //Application.LoadLevel (1);        
        if( Directory.Exists( pathToSave ) )
        {
            print( "Delete" );

            string newName = pathToSave + count;

            while( Directory.Exists( newName ) )
            {
                newName = pathToSave + count++;
            }
            Directory.Move( pathToSave, newName );
            Directory.CreateDirectory( pathToSave );
        }
        SceneManager.LoadScene( 1 );

    }

    public void ContinueGame()
    {
        SceneManager.LoadScene( 1 );
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
