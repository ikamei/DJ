// NotesController.cs --- 
// Filename: NotesController.cs
// Created: Sat Oct  3 21:13:35 2020 (+0800)
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

// public enum NoteSide
// {
//     NoteSide_Middle,
//     NoteSide_Left,
//     NoteSide_Right,
// }

public class NewNotesController : MonoBehaviour
{
    NotesGenerator m_notes_generator;

    System.DateTime m_start_time;
    System.DateTime m_current_time;
    bool m_is_start = false;

    // 
    public int m_beats_per_second = 1;
    public int m_span_of_disappear_seconds = 2;
    // public int m_span_of_beat_count = 32;
    // public float m_track_length = 6;

    Vector3 m_velocity = new Vector3(0,-2.5f,0);
    public Vector3 Velocity
    {
        get
        {
            return m_velocity;
        }
    }

    public Vector3 m_left_start_position = new Vector3(0,0,0);
    public Vector3 m_right_start_position = new Vector3(0,0,0);

    void Start()
    {
        m_notes_generator = new NotesGenerator( m_beats_per_second, m_span_of_disappear_seconds );
    }

    void Awake()
    {
        set_start( true );
    }

    public void set_start( bool is_start )
    {
        m_is_start = is_start;
        if( is_start )
        {
            m_start_time = System.DateTime.Now;
        }
    }

    void Update()
    {
        if( !m_is_start )
        {
            return;
        }
            
        m_current_time = System.DateTime.Now;
        System.TimeSpan span = m_current_time - m_start_time;

        // int current_beat_index = (int)(span.TotalMilliseconds * m_beats_per_second + 0.5);
        int current_beat_index = (int)(span.TotalSeconds * m_beats_per_second + 0.5);
        // Debug.Log( "current_beat_index = " + current_beat_index);
        if( current_beat_index >= m_notes_generator.m_left_notes.Count )
        {
            set_start( false );
        }
        //Debug.Log( "span.TotalMilliseconds = " + span.TotalMilliseconds + ", current_beat_index = " + current_beat_index );
        bool isok = check_appear_note( current_beat_index, 
                                       ref m_notes_generator.m_left_notes, 
                                       m_notes_generator.m_left_appear_note_indices, 
                                       m_left_start_position, 
                                       m_current_time );
        isok = check_appear_note( current_beat_index, 
                                  ref m_notes_generator.m_right_notes, 
                                  m_notes_generator.m_right_appear_note_indices, 
                                  m_right_start_position, 
                                  m_current_time );
        // if( isok )
        // {
        //     Debug.Log( "====================" );
        //     for( int j=0; j<m_left_notes.Count; ++j )
        //     {
        //         Debug.Log( "j : " + j + " : " + m_left_notes[j].m_gameobject );
        //     }
        // }

        check_disappear_note( current_beat_index, ref m_notes_generator.m_left_notes, m_notes_generator.m_left_disappear_note_indices, m_current_time );
        check_disappear_note( current_beat_index, ref m_notes_generator.m_right_notes, m_notes_generator.m_right_disappear_note_indices, m_current_time );
    }

    bool check_appear_note( int current_beat_index, 
                            ref List<Note> notes, 
                            List<int> appear_note_indices, 
                            Vector3 start_position, 
                            System.DateTime current_time )
    {
        if( current_beat_index<0 || current_beat_index>=appear_note_indices.Count )
        {
            return false;
        }

        int appear_index = appear_note_indices[current_beat_index];
        if( appear_index>=0 && !notes[appear_index].m_visible )
        {
            Note note = notes[appear_index];
            create_note( ref note, start_position, current_time );
            notes[appear_index] = note;
            //Debug.Log( "" + appear_index + ", note.m_visible = " + note.m_visible + ", note.m_gameobject = " + note.m_gameobject );
            return true;
        }

        return false;
    }

    void check_disappear_note( int current_beat_index,
                               ref List<Note> notes, 
                               List<List<int>> disappear_note_indices, 
                               System.DateTime current_time )
    {
        if( current_beat_index<0 || current_beat_index>=disappear_note_indices.Count )
        {
            return;
        }

        List<int> disappear_indices = disappear_note_indices[current_beat_index];
        for( int j=0; j<disappear_indices.Count; ++j )
        {
            int disappear_index = disappear_indices[j];
            // if( disappear_index>=0 )
            // {
            //     Debug.Log( "check_disappear_note : current_beat_index=" + current_beat_index + ", disappear_index=" + disappear_index + ", visible=" + notes[disappear_index].m_visible + ", go : " + notes[disappear_index].m_gameobject);
            // }
            if( disappear_index>=0 && notes[disappear_index].m_visible )
            {
                Note note = notes[disappear_index];
                note.m_visible = false;
                note.m_disappear_time = current_time;
                // if( null!=note.m_gameobject )
                // {
                //     Debug.Log( note.m_gameobject.name );
                // }
                Destroy( note.m_gameobject );
                note.m_gameobject = null;
            }
        }
    }

    void create_note( ref Note note, Vector3 start_position, System.DateTime current_time )
    {
        float T = note.m_appear_beat_index / m_beats_per_second;
        Vector3 x = m_velocity * T;

        System.TimeSpan span = m_current_time - m_start_time;
        GameObject go = new GameObject();
        // go.name = "character";
        // go.tag = "Player";
        // go.layer = MyConsts.LAYER_PLAYER;
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        if( NoteType.NoteTypeKePressed == note.m_note_type )
        {
            renderer.sprite = Resources.Load<Sprite>( "keypressed_note" );
        }
        else if( NoteType.NoteTypePush == note.m_note_type )
        {
            renderer.sprite = Resources.Load<Sprite>( "push_note" );
        }
        else if( NoteType.NoteTypeRelease == note.m_note_type )
        {
            renderer.sprite = Resources.Load<Sprite>( "release_note" );
        }
        else
        {
            renderer.sprite = Resources.Load<Sprite>( "normal_note" );
        }
        // renderer.sortingLayerName = MyConsts.SORTING_LAYER_FOREGROUND_NAME;
        go.transform.localPosition = start_position;
        // go.transform.localPosition = x - m_velocity * span.TotalMilliseconds * 1000;

        // rigid body
        Rigidbody2D rigidbody = go.AddComponent<Rigidbody2D>();
        rigidbody.mass = 0;
        rigidbody.gravityScale = 0;
        rigidbody.freezeRotation = true;
        BoxCollider2D collider = go.AddComponent<BoxCollider2D>();
        //collider.isTrigger = true;

        note.m_visible = true;
        note.m_appear_time = current_time;
        note.m_gameobject = go;

        MyNoteMotor motor = go.AddComponent<MyNoteMotor>();
        motor.set_param( note, start_position, m_velocity);
        motor.index = note.m_appear_beat_index;
    }
}

// public class Note
// {
//     public int m_appear_beat_index = -1;
//     public NoteSide m_side;
 
//     public int m_disappear_beat_index = -1;
//     public System.DateTime m_appear_time;
//     public System.DateTime m_disappear_time;
//     public bool m_visible = false;
//     public GameObject m_gameobject = null;
// }