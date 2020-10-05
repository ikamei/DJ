// UIProcesser.cs --- 
// Filename: UIProcesser.cs
// Created: Mon Oct  5 11:22:10 2020 (+0800)
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

public class UIProcesser : MonoBehaviour
{
    HitBar m_hitbar = null;
    public GameObject m_left_shadow = null;
    public GameObject m_right_shadow = null;
    public Animator m_left_disk_animator = null;
    public Animator m_right_disk_animator = null;

    void Start()
    {
        m_hitbar = gameObject.GetComponent<HitBar>();
    }

    void Update()
    {
        if( null==m_hitbar )
        {
            return;
        }
        SwitchKey key = m_hitbar.get_switch_key();

        if( SwitchKey.Left == key )
        { 
            on_left_switch_key_pressed();
        }
        else if( SwitchKey.Right == key )
        {
            on_right_switch_key_pressed();
        }
        else
        {
            on_switch_key_released();
        }
    }

    void on_left_switch_key_pressed()
    {
        if( null!=m_left_shadow )
        {
            m_left_shadow.SetActive(false);
        }
        if( null!=m_right_shadow )
        {
            m_right_shadow.SetActive(true);
        }
        if( null!=m_left_disk_animator)
        {
            if( Input.GetKeyDown("space") )
            {
                m_left_disk_animator.SetInteger( "action_state", MyConst.ACTION_STATE_PUSH );
            }
            // else
            // {
            //     m_left_disk_animator.SetInteger( "action_state", MyConst.ACTION_STATE_NORMAL );
            // }
        }
        
    }

    void on_right_switch_key_pressed()
    {
        if( null!=m_left_shadow )
        {
            m_left_shadow.SetActive(true);
        }
        if( null!=m_right_shadow )
        {
            m_right_shadow.SetActive(false);
        }
        if( null!=m_right_disk_animator)
        {
            if( Input.GetKeyDown("space") )
            {
                m_right_disk_animator.SetInteger( "action_state", MyConst.ACTION_STATE_PUSH );
            }
            // else
            // {
            //     m_right_disk_animator.SetInteger( "action_state", MyConst.ACTION_STATE_NORMAL );                
            // }
        }
    }

    void on_switch_key_released()
    {
        if( null!=m_left_shadow )
        {
            m_left_shadow.SetActive(true);
        }
        if( null!=m_right_shadow )
        {
            m_right_shadow.SetActive(true);
        }
        if( null!=m_right_disk_animator)
        {
            m_right_disk_animator.SetInteger( "action_state", MyConst.ACTION_STATE_NORMAL );
        }
        if( null!=m_left_disk_animator)
        {
            m_left_disk_animator.SetInteger( "action_state", MyConst.ACTION_STATE_NORMAL );
        }
    }
}

