// CreditsPageUI.cs --- 
// Filename: CreditsPageUI.cs
// Created: Mon Oct  5 16:03:59 2020 (+0800)
// 
// 
// Copyright Weiguo Mao All Rights Reserved.
// 
// 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsPageUI : MonoBehaviour
{
    public GameObject m_return_button = null;
    public SceneSwitcher m_scene_switcher = null;

    void Start()
    {
        Button btn = m_return_button.GetComponent<Button>();
        btn.onClick.AddListener( onReturnButtonClick );
    }

    void onReturnButtonClick()
    {
        m_scene_switcher.m_scene_name = "StartScene";
        StartCoroutine(m_scene_switcher.LoadYourAsyncScene());
    }

}
