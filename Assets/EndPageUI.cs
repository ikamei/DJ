// EndPageUI.cs --- 
// Filename: EndPageUI.cs
// Created: Mon Oct  5 16:25:06 2020 (+0800)
// 
// 
// Copyright Weiguo Mao All Rights Reserved.
// 
// 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndPageUI : MonoBehaviour
{
    public GameObject m_replay_button = null;
    public GameObject m_quit_button = null;
    public GameObject m_next_level_button = null;

    public SceneSwitcher m_scene_switcher = null;
    public ScoreUI m_highest_score = null;
    public ScoreUI m_highest_combo_hits = null;

    void Start()
    {
        Button btn = m_next_level_button.GetComponent<Button>();
        btn.onClick.AddListener( on_next_level_button_click );

        btn = m_replay_button.GetComponent<Button>();
        btn.onClick.AddListener( on_replay_button_click );

        btn = m_quit_button.GetComponent<Button>();
        btn.onClick.AddListener( on_quit_button_click );

        // GameObject score_center_go = GameObject.Find("ScoreCenter");
        // ScoreCenter score_center = score_center_go.AddComponent<ScoreCenter>();
        m_highest_score.set_score( ScoreCenter.instance().HighestScore );
        m_highest_combo_hits.set_score( ScoreCenter.instance().HighestComboHits );
    }

    void on_next_level_button_click()
    {
        m_scene_switcher.m_scene_name = "Level2Scene";
        StartCoroutine(m_scene_switcher.LoadYourAsyncScene());
    }

    void on_replay_button_click()
    {
        ScoreCenter.instance().clear_score();
        ScoreCenter.instance().clear_combo_hit_count();

        m_scene_switcher.m_scene_name = "SampleScene";
        StartCoroutine(m_scene_switcher.LoadYourAsyncScene());
    }

    void on_quit_button_click()
    {
        Application.Quit();
    }
}
