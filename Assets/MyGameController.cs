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
using UnityEngine.UI;

class MyGameController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string m_player_state_event = "";
    public NewNotesController m_notes_controller = null;

    FMOD.Studio.EventInstance m_player_state;
    // FMOD.Studio.EventInstance playerState;

    public GameObject m_return_button = null;
    public SceneSwitcher m_scene_switcher = null;

    public string m_end_scene_name = "";
    void Start()
    {
        m_player_state = FMODUnity.RuntimeManager.CreateInstance(m_player_state_event);
        m_player_state.start();

        m_notes_controller.set_start( true );

        Button btn = m_return_button.GetComponent<Button>();
        btn.onClick.AddListener( on_return_button_click );
    }

    void on_return_button_click()
    {
        if (m_player_state.isValid())
        {
            m_player_state.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            m_player_state.release();
            m_player_state.clearHandle();
        }
        m_scene_switcher.m_scene_name = "StartScene";
        StartCoroutine(m_scene_switcher.LoadYourAsyncScene());
    }

    void Update()
    {
        if (m_player_state.isValid())
        {
            FMOD.Studio.PLAYBACK_STATE playback_state;
            m_player_state.getPlaybackState(out playback_state);
            if (FMOD.Studio.PLAYBACK_STATE.STOPPED == playback_state)
            {
                m_player_state.release();
                m_player_state.clearHandle();

                m_scene_switcher.m_scene_name = m_end_scene_name;//"EndScene";
                StartCoroutine(m_scene_switcher.LoadYourAsyncScene());
            }
        }
    }
}