using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
                                         

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
    
    public Animator animatorMainGate;
    public Animator animatorOtherGate;
    AudioSource audioSource;

    DialDeviceCore DDC;// ядро для управленя порталом. При совпадении строки с типом
                       //направляет в разные локации.


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //animator = starGateVortex.GetComponent<Animator>();        
        DDC = PoolReference.TableScene["DialManeger"].GetComponent<DialDeviceCore>();

        
    }

    public void Button_Enter()
    {
        
        var lockShevron = DDC.CreateShevronCode( currentShevronCode );
        if( lockShevron != null )
        {
            lockShevron.CreateWorld();

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
        animatorMainGate.Play( "Launching" );
        animatorOtherGate.Play( "Launching" );

        yield return new WaitForSeconds( 4.336f );
        audioSource.Stop();
        audioSource.PlayOneShot( audioClips[3] );

        yield return new WaitForSeconds( 9 );
        CloseVortex();
        ResetGateSetting();
    }

    IEnumerator ResetVortex()
    {
        bool isIddle = animatorMainGate.GetCurrentAnimatorStateInfo( 0 ).IsName( "Idlle_close" );
        if( !isIddle )
        {
            CloseVortex();
        }

        yield return new WaitForSeconds( 2 );
    }    

    void CloseVortex()
    {
        animatorMainGate.Play( "Close" );
        animatorOtherGate.Play( "Close" );
        audioSource.Stop();
        audioSource.PlayOneShot( audioClips[4] );
    }

    IEnumerator PauseUpdatePanel()
    {
        yield return new WaitForSeconds( 4 );
        updatePanel();
    }
    void ResetGateSetting()
    {
        animatorMainGate.GetComponent<InPortal>().exitPortal = null;
        animatorOtherGate.GetComponent<InPortal>().exitPortal = null;
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

    public void TouchButton( string code, Button btn )
    {
        currentShevronCode += code;
        audioSource.PlayOneShot( audioClips[2] );
        shevronCounter++;
        btn.interactable = false;
        activeButtons.Add( btn );
        
        print( "Набрано символов: " + shevronCounter +"\nКод сивола: " + code );
    }

    public bool IsComleteCode()
    {
        return shevronCounter < lengthShevron;
    }

}
