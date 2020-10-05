// ScoreCenter.cs --- 
// Filename: ScoreCenter.cs
// Created: Mon Oct  5 13:00:40 2020 (+0800)
// 
// 
// Copyright Weiguo Mao All Rights Reserved.
// 
// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScoreCenter
{
    static ScoreCenter m_instance = null;
    public static ScoreCenter instance()
    {
        if( null == m_instance )
        {
            m_instance = new ScoreCenter();
        }
        return m_instance;
    }

    ScoreCenter()
    {
    }
    // public ScoreUI m_score_ui = null;
    // public ScoreUI m_combo_hit_ui = null;
    public int m_score = 0;
    public int Score
    {
        get { return m_score; }
    }

    public int m_combo_hit_count = 0;
    public int ComboHitCount
    {
        get { return m_combo_hit_count; }
    }

    public int m_hightest_score = 0;
    public int HighestScore
    {
        get { return m_hightest_score; }
    }

    public int m_hightest_combo_hits = 0;
    public int HighestComboHits
    {
        get { return m_hightest_combo_hits; }
    }

    // void Awake() 
    // {
    //     DontDestroyOnLoad(transform.gameObject);
    // }


    public void clear_score()
    {
        m_score = 0;        
    }

    public void add_score( int delta )
    {
        m_score += delta;
        // m_score_ui.set_score( m_score );
        if( m_score > m_hightest_score )
        {
            m_hightest_score = m_score;
        }
    }

    public void clear_combo_hit_count()
    {
        m_combo_hit_count = 0;
        // m_combo_hit_ui.set_score( m_combo_hit_count );
    }

    public void add_combo_hit_count( int delta )
    {
        m_combo_hit_count += delta;
        // m_combo_hit_ui.set_score( m_combo_hit_count );
        if( m_combo_hit_count > m_hightest_combo_hits )
        {
            m_hightest_combo_hits = m_combo_hit_count;
        }
    }
}
