// MyNoteMotor.cs --- 
// Filename: MyNoteMotor.cs
// Created: Sat Oct  3 22:51:57 2020 (+0800)
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

public class MyNoteMotor : MonoBehaviour
{
    public int index = -1;
    public Note m_note = null;
    //NotesController m_notes_controller = null;
    Vector3 m_start_position = new Vector3(0,0,0);
    Vector3 m_velocity;

    public void set_param(Note note, Vector3 start_position, Vector3 velocity)
    {
        m_note = note;
        m_start_position = start_position;
        //m_notes_controller = notes_controller;
        m_velocity = velocity;
    }

    void Update()
    {
        if( null!=m_note )
        {
            float deltaT = (float)((System.DateTime.Now - m_note.m_appear_time).TotalMilliseconds) / 1000.0f;
            gameObject.transform.localPosition = m_start_position + m_velocity * deltaT;
            //Debug.Log( "deltaT = " + deltaT + ", v = " + m_notes_controller.Velocity + ", m_start_position = " + m_start_position);
        }
    }
}
