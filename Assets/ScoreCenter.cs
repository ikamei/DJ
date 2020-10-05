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

public class ScoreCenter : MonoBehaviour
{
    public ScoreUI m_score_ui = null;
    int m_score = 0;
    public int Score
    {
        get
        {
            return m_score;
        }
    }

    int m_combo_hit_count = 0;
    public int ComboHitCount
    {
        get
        {
            return m_combo_hit_count;
        }
    }

    public void add_score( int delta )
    {
        m_score += delta;
        m_score_ui.set_score( m_score );
    }

    public void clear_combo_hit_count()
    {
        m_combo_hit_count = 0;
    }

    public void add_combo_hit_count( int delta )
    {
        m_combo_hit_count += delta;
    }
}
