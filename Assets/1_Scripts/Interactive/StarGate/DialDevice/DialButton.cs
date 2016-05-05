using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
/*
    Повесить на кнопку наборной панели(DialPanel)
*/
public class DialButton : MonoBehaviour {

    public void ButtonClick()
    {
        var button = GetComponent<Button>();
        var dialManeger = PoolReference.TableScene["DialPanel"].GetComponent<DialManeger>();
        
        string matchValue =  Regex.Match( button.name, @"\d+" ).Value;
        
        if( dialManeger.IsComleteCode() )
        {
            dialManeger.currentShevronCode += matchValue;
            dialManeger.shevronCounter++;
            dialManeger.CallCancel();
            dialManeger.activeButtons.Add( button );

            button.interactable = false;                                  
            
            
            print( dialManeger.shevronCounter );
        }
        
    }

    public void Button_Enter()
    {
        var dialManeger = PoolReference.TableScene["DialPanel"].GetComponent<DialManeger>();
        dialManeger.Button_Enter();
    }
}
