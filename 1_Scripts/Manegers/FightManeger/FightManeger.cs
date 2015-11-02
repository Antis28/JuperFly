using UnityEngine;
using System.Collections;

public class FightManeger : MonoBehaviour {


    public void DoneButton()
    {
        Canvas canvasEnabled = PoolReference.TableScene["FightCanvas"].GetComponent<Canvas>();

        canvasEnabled.enabled = !canvasEnabled.enabled;
    }
}
