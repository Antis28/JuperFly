using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using DDC = DialDeviceCore.ShevronCode; // ядро для управленя порталом. При совпадении строки с типом
                                        //направляет в разные локации.

[RequireComponent( typeof( AudioSource ) )]

public class DialManeger : MonoBehaviour
{
    public GameObject starGateVortex;
    public AudioClip[] audioClips;
    public List<Button> activeButtons = new List<Button>(); // Используется что бы разблокировать кнопки.

    [HideInInspector]
    public int  shevronCounter = 0;
    [HideInInspector]
    public string currentShevronCode ="";

    int lengthShevron = 7;
    
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
            lockShevron.SetLocation();
            
            StartCoroutine( "EgengeVortex" );
            StartCoroutine( "PauseUpdatePanel" );
            
            
        } else
        {
            audioSource.PlayOneShot( audioClips[1] );
            updatePanel();
        }
    }

    IEnumerator EgengeVortex()
    {
        audioSource.PlayOneShot( audioClips[0] );
        yield return new WaitForSeconds( 3.3f);
        audioSource.PlayOneShot( audioClips[4] );
        var animator = starGateVortex.GetComponent<Animator>();
        animator.SetBool( "IsCalling", true );
        animator.SetBool( "IsReset", false );
        yield return new WaitForSeconds( 2 );
        animator.SetBool( "IsCalling", false );
    }

    IEnumerator ResetVortex()
    {
        var animator = starGateVortex.GetComponent<Animator>();
        animator.SetBool( "IsCalling", false );
        animator.SetBool( "IsReset", true );
        yield return new WaitForSeconds( 2 );
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

    public bool IsComleteCode()
    {
        return shevronCounter < lengthShevron;
    }

}
