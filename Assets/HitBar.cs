// HitBar.cs --- 
// Filename: HitBar.cs
// Created: Sun Oct  4 22:55:34 2020 (+0800)
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

public class HitBar : MonoBehaviour
{
    //Dictionary<MyNote,int> m_notes;
    List<MyNote> m_single_notes = new List<MyNote>();
    List<MyNote> m_push_notes = new List<MyNote>();
    List<MyNote> m_release_notes = new List<MyNote>();
    List<MyNote> m_keypressed_notes = new List<MyNote>();

    void OnTriggerEnter2D(Collider2D col)
    {
        if( !col.gameObject.CompareTag("Note") )
        {
            return;
        }
        MyNote mynote = col.gameObject.GetComponent<MyNote>();
        if( NoteType.NoteTypeSingle == mynote.m_note.m_note_type )
        {
            m_single_notes.Add( mynote );
        }
        else if( NoteType.NoteTypePush == mynote.m_note.m_note_type )
        {
            m_push_notes.Add( mynote );
        }
        else if( NoteType.NoteTypeRelease == mynote.m_note.m_note_type )
        {
            m_release_notes.Add( mynote );
        }
        else if( NoteType.NoteTypeKePressed == mynote.m_note.m_note_type )
        {
            m_keypressed_notes.Add( mynote );
        }
        //m_notes[mynote] = 1;
        //Debug.Log(col.gameObject.name );// + " : " + gameObject.name + " : " + Time.time);
    }    

    void OnTriggerExit2D(Collider2D col)
    {
        if( !col.gameObject.CompareTag("Note") )
        {
            return;
        }
        MyNote mynote = col.gameObject.GetComponent<MyNote>();
        bool is_skip = false;
        if( !is_skip )
        {
            is_skip = m_single_notes.Remove( mynote );
        }

        if( !is_skip )
        {
            is_skip = m_push_notes.Remove( mynote );
        }

        if( !is_skip )
        {
            is_skip = m_release_notes.Remove( mynote );
        }

        if( !is_skip )
        {
            is_skip = m_keypressed_notes.Remove( mynote );
        }

        if( mynote.m_is_hit )
        {
            on_hit_note(mynote);
        }
    }    

    int score = 0;
    void on_hit_note( MyNote mynote )
    {
        Debug.Log( "on_hit_note : " + (score++) );
        // animation
        // add score
        // destroy gameobject
        Destroy( mynote.gameObject );
        mynote.m_note.m_gameobject = null;
    }

    void Update()
    {
        if( Input.GetKeyDown("space") )
        {
            on_key_down();
        }
        else if( Input.GetKeyUp("space") )
        {
            on_key_up();
        }
        else if( Input.GetKey("space") )
        {
            on_key_hold_down();
        }
    }

    enum SwitchKey
    {
        None,
        Left,
        Right,
    }

    SwitchKey get_switch_key()
    {
        SwitchKey key = SwitchKey.None;
        if( Input.GetKey(KeyCode.LeftArrow) )
        {
            key = SwitchKey.Left;
        }
        else if( Input.GetKey(KeyCode.RightArrow) )
        {
            key = SwitchKey.Right;
        }
        return key;
    }
    void on_key_down()
    {
        SwitchKey key = get_switch_key();
        for( int j=0; j<m_push_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left == m_push_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_push_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_push_notes[j].m_is_hit = true;
            }
        }

        for( int j=0; j<m_single_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left  == m_single_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_single_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_single_notes[j].m_is_hit = true;
            }
        }


    }

    void on_key_hold_down()
    {
        SwitchKey key = get_switch_key();
        for( int j=0; j<m_keypressed_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left == m_keypressed_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_keypressed_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_keypressed_notes[j].m_is_hit = true;
            }
        }
    }

    void on_key_up()
    {
        SwitchKey key = get_switch_key();
        for( int j=0; j<m_release_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left == m_release_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_release_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_release_notes[j].m_is_hit = true;
            }
        }

        for( int j=0; j<m_single_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left ==  m_single_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_single_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_single_notes[j].m_is_hit = true;
            }
        }

    }

}
