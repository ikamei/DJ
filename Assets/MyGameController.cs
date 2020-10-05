// MyGameController.cs --- 
// Filename: MyGameController.cs
// Created: Mon Oct  5 00:31:20 2020 (+0800)
// 
// 
// Copyright Weiguo Mao All Rights Reserved.
// 
// 

using System;
using UnityEngine;

class MyGameController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string PlayerStateEvent = "";
    public NewNotesController m_notes_controller = null;

    // FMOD.Studio.EventInstance playerState;
    void Start()
    {
        FMOD.Studio.EventInstance playerState = FMODUnity.RuntimeManager.CreateInstance(PlayerStateEvent);
        playerState.start();
        //Debug.Log( "start");

        m_notes_controller.set_start( true );

    }


}