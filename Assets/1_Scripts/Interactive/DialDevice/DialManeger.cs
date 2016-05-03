using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using DDC = DialDeviceCore.ShevronCode; // ядро для управленя порталом. При совпадении строки с типом
                                        //направляет в разные локации.

public class DialManeger : MonoBehaviour
{
    public GameObject starGate;


    public List<Button> activeButtons = new List<Button>();

    [HideInInspector]
    public int  shevronCounter = 0;
    [HideInInspector]
    public string currentShevronCode ="";
    
    int lengthShevron = 7;


    public AudioClip[] audioClips;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    public void Button_Enter()
    {
        var lockShevron = DDC.Create( currentShevronCode );
        if( lockShevron != null )
        {            
            audioSource.PlayOneShot( audioClips[0] );
            StartCoroutine( "PauseUpdatePanel" );
            lockShevron.SetLocation();
        } else
        {
            audioSource.PlayOneShot( audioClips[1] );
            updatePanel();
        }
        
    }  

    IEnumerator PauseUpdatePanel()
    {
        yield return new WaitForSeconds( 4 );
        updatePanel();
    }

    void updatePanel()
    {
        print( currentShevronCode );
       
        shevronCounter = 0;
        currentShevronCode = "";
        for( int i = 0; i < activeButtons.Count; i++ )
        {

            if( activeButtons[i] != null )
                activeButtons[i].interactable = true;
        }
        activeButtons.Clear();
    }

    public void CallCancel()
    {
        audioSource.PlayOneShot( audioClips[2] );
    }

    public bool IsComleteCode( )
    {
        return shevronCounter < lengthShevron;
    }
   
}
