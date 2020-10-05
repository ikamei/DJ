// StartPageUI.cs --- 
// Filename: StartPageUI.cs
// Created: Mon Oct  5 15:31:25 2020 (+0800)
// 
// 
// Copyright Weiguo Mao All Rights Reserved.
// 
// 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartPageUI : MonoBehaviour
{
    public GameObject m_start_button = null;
    public GameObject m_credits_button = null;
    public GameObject m_exit_button = null;

    public SceneSwitcher m_scene_switcher = null;
    void Start()
    {
        Button btn = m_start_button.GetComponent<Button>();
        btn.onClick.AddListener( onStartButtonClick );

        btn = m_credits_button.GetComponent<Button>();
        btn.onClick.AddListener( onCreditsButtonClick );

        btn = m_exit_button.GetComponent<Button>();
        btn.onClick.AddListener( onExitButtonClick );
    }

    void onStartButtonClick()
    {
        m_scene_switcher.m_scene_name = "SampleScene";
        StartCoroutine(m_scene_switcher.LoadYourAsyncScene());
    }

    void onCreditsButtonClick()
    {
        m_scene_switcher.m_scene_name = "CreditsScene";
        StartCoroutine(m_scene_switcher.LoadYourAsyncScene());
    }

    void onExitButtonClick()
    {
        Application.Quit();
    }
}
