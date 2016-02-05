using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillManeger : MonoBehaviour {

    public PlayerSkills _playerSkills;
    Canvas SkillsCanvasEnabled;

    // Use this for initialization
    void Start () {
        SkillsCanvasEnabled = PoolReference.TableScene[EnumInPool.SkillManeger.ToString()].GetComponent<Canvas>();
        _playerSkills = new PlayerSkills();
    }


    public void addIntellect()  { _playerSkills.addIntellect(); }
    public void addSpeed()      { _playerSkills.addSpeed(); }
    public void addStrength()   { _playerSkills.addStrength(); }

    public void removeIntellect()   { _playerSkills.removeIntellect(); }
    public void removeSpeed()       { _playerSkills.removeSpeed(); }
    public void removeStrength()    { _playerSkills.removeStrength(); }


    public void DoneButton()
    {
        if( !SkillsCanvasEnabled.gameObject.activeSelf)
            SkillsCanvasEnabled.gameObject.SetActive( true );
        SkillsCanvasEnabled.enabled = !SkillsCanvasEnabled.enabled;
        
    }
}
