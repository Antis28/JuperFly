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
    Animator animator;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = starGateVortex.GetComponent<Animator>();
    }

    public void Button_Enter()
    {
        var lockShevron = DDC.Create( currentShevronCode );
        if( lockShevron != null )
        {
            lockShevron.SetLocation();

            StartCoroutine( EgengeVortex() );
            StartCoroutine( PauseUpdatePanel() );


        } else
        {
            audioSource.PlayOneShot( audioClips[1] );
            updatePanel();
            StartCoroutine( ResetVortex() );
        }
    }

    IEnumerator EgengeVortex()
    {
        audioSource.PlayOneShot( audioClips[0] );

        yield return new WaitForSeconds( 3.5f );
        animator.Play( "Launching" );       
         
        yield return new WaitForSeconds( 4.336f);
        audioSource.Stop();
        audioSource.PlayOneShot( audioClips[3] );
        
        yield return new WaitForSeconds( 9 );
        CloseVortex();
    }

    IEnumerator ResetVortex()
    {
        bool isIddle = animator.GetCurrentAnimatorStateInfo( 0 ).IsName( "Idlle_close" );
        if( !isIddle )
        {
            CloseVortex();
        }
        
        yield return new WaitForSeconds( 2 );
    }

    void CloseVortex()
    {
        animator.Play( "Close" );
        audioSource.Stop();
        audioSource.PlayOneShot( audioClips[4] );
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
