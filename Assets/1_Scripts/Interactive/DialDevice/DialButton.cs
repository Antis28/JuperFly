using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

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
}
