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

public enum SwitchKey
{
    None,
    Left,
    Right,
}


public class HitBar : MonoBehaviour
{
    //public ScoreCenter m_score_center = null;
    //Dictionary<MyNote,int> m_notes;
    List<MyNote> m_single_notes = new List<MyNote>();
    List<MyNote> m_push_notes = new List<MyNote>();
    List<MyNote> m_release_notes = new List<MyNote>();
    List<MyNote> m_keypressed_notes = new List<MyNote>();

    public ScoreUI m_score_ui = null;
    public ScoreUI m_combo_hit_ui = null;

    Animator m_animator = null;
    SpriteRenderer m_sprite_renderer = null;

    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        m_sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
    }

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

    void remove_mynote( MyNote mynote )
    {
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
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if( !col.gameObject.CompareTag("Note") )
        {
            return;
        }
        MyNote mynote = col.gameObject.GetComponent<MyNote>();
        remove_mynote( mynote );

        if( !mynote.m_is_hit )
        {
            ScoreCenter.instance().clear_combo_hit_count();
            // on_hit_note(mynote);
        }
    }    

    // int score = 0;
    void on_hit_note( MyNote mynote )
    {
        remove_mynote( mynote );
        // Debug.Log( "on_hit_note : " + (score++) );
        // animation
        // add score
        ScoreCenter.instance().add_score(1);
        m_score_ui.set_score( ScoreCenter.instance().Score );

        ScoreCenter.instance().add_combo_hit_count(1);
        m_combo_hit_ui.set_score( ScoreCenter.instance().ComboHitCount );
        // destroy gameobject
        Destroy( mynote.gameObject );
        mynote.m_note.m_gameobject = null;
        m_sprite_index = 0;
        // if( null != m_animator )
        // {
        //     m_animator.SetInteger( "action_state", MyConst.ACTION_STATE_HIT );
        // }
    }

    public Sprite[] m_hit_sprites;
    int m_sprite_index = 0;
    float m_delta_time = 0;

    void check_sprite()
    {
        if( null != m_sprite_renderer )
        {
            m_delta_time += Time.deltaTime;
            if( m_delta_time > 1/15.0f )
            {
                m_delta_time = 0;            
                if( m_sprite_index < m_hit_sprites.Length-1 )
                {
                    m_sprite_index++;
                    // Debug.Log( "" + m_sprite_index + ", " + m_delta_time );
                    m_sprite_renderer.sprite = m_hit_sprites[m_sprite_index];
                    // m_sprite_renderer.sprite = Resources.Load<Sprite>( "bar_25fps/bar2" );
                }
            }
            
        }
    }

    void Update()
    {
        check_sprite();
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

    public SwitchKey get_switch_key()
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
        List<MyNote> temp_notes = new List<MyNote>();
        SwitchKey key = get_switch_key();
        for( int j=0; j<m_push_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left == m_push_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_push_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_push_notes[j].m_is_hit = true;
                temp_notes.Add(m_push_notes[j]);
            }
        }

        for( int j=0; j<m_single_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left  == m_single_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_single_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_single_notes[j].m_is_hit = true;
                temp_notes.Add(m_single_notes[j]);
            }
        }

        for( int j=0; j<temp_notes.Count; ++j )
        {
            on_hit_note( temp_notes[j] );
        }
    }

    void on_key_hold_down()
    {
        List<MyNote> temp_notes = new List<MyNote>();
        SwitchKey key = get_switch_key();
        for( int j=0; j<m_keypressed_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left == m_keypressed_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_keypressed_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_keypressed_notes[j].m_is_hit = true;
                temp_notes.Add(m_keypressed_notes[j]);
            }
        }

        for( int j=0; j<temp_notes.Count; ++j )
        {
            on_hit_note( temp_notes[j] );
        }
    }

    void on_key_up()
    {
        List<MyNote> temp_notes = new List<MyNote>();
        SwitchKey key = get_switch_key();
        for( int j=0; j<m_release_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left == m_release_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_release_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_release_notes[j].m_is_hit = true;
                temp_notes.Add(m_release_notes[j]);
            }
        }

        for( int j=0; j<m_single_notes.Count; ++j )
        {
            if( (NoteSide.NoteSide_Left ==  m_single_notes[j].m_note.m_side && SwitchKey.Left == key) ||
                (NoteSide.NoteSide_Right == m_single_notes[j].m_note.m_side && SwitchKey.Right == key) )
            {
                m_single_notes[j].m_is_hit = true;
                temp_notes.Add(m_single_notes[j]);
            }
        }

        for( int j=0; j<temp_notes.Count; ++j )
        {
            on_hit_note( temp_notes[j] );
        }
    }

    void on_hit_animation_finished()
    {
        // if( null != m_animator )
        // {
        //     m_animator.SetInteger( "action_state", MyConst.ACTION_STATE_NORMAL );
        // }
        // Debug.Log( "hit animation finished!" );
    }
}
