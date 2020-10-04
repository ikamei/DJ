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
    Note m_note;
    NotesController m_notes_controller = null;
    Vector3 m_start_position = new Vector3(0,0,0);

    public void set_param(Note note, Vector3 start_position, NotesController notes_controller)
    {
        m_note = note;
        m_start_position = start_position;
        m_notes_controller = notes_controller;
    }

    void Update()
    {
        if( null!=m_notes_controller )
        {
            float deltaT = (float)((System.DateTime.Now - m_note.m_appear_time).TotalMilliseconds);
            gameObject.transform.localPosition = m_start_position + m_notes_controller.Velocity * deltaT;
            //Debug.Log( "deltaT = " + deltaT + ", v = " + m_notes_controller.Velocity + ", m_start_position = " + m_start_position);
        }
    }
}
