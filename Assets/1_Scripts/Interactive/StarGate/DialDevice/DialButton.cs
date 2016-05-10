using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
/*
    Повесить на кнопку наборной панели(DialPanel)
*/
public class DialButton : MonoBehaviour {

    DialManeger dialManeger;

    void Start()
    {
        dialManeger = PoolReference.TableScene["DialManeger"].GetComponent<DialManeger>();
    }

    public void ButtonClick()
    {
        var button = GetComponent<Button>();
        //var dialManeger = PoolReference.TableScene["DialManeger"].GetComponent<DialManeger>();

        string currentShevronCode =  Regex.Match( button.name, @"\d+" ).Value;
        
        if( dialManeger.IsComleteCode() )
        {
            dialManeger.TouchButton( currentShevronCode, button );
                         
        }
        
    }

    public void Button_Enter()
    {
        //var dialManeger = PoolReference.TableScene["DialManeger"].GetComponent<DialManeger>();
        dialManeger.Button_Enter();
    }
}
