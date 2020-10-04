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
    public NewNotesController m_notes_controller;

    // FMOD.Studio.EventInstance playerState;
    void Start()
    {
        //--------------------------------------------------------------------
        // 4: This shows how to create an instance of an Event and manually 
        //    start it.
        //--------------------------------------------------------------------
        FMOD.Studio.EventInstance playerState = FMODUnity.RuntimeManager.CreateInstance(PlayerStateEvent);
        playerState.start();
        Debug.Log( "start");

        m_notes_controller.set_start( true );

    }


}