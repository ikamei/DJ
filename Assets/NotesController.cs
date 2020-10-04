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

public enum NoteSide
{
    NoteSide_Middle,
    NoteSide_Left,
    NoteSide_Right,
}

public class NotesController : MonoBehaviour
{
    // generated data
    List<Note> m_left_notes = new List<Note>();
    List<Note> m_right_notes = new List<Note>();
    List<Note> m_middle_notes = new List<Note>();

    List<int> m_left_appear_note_indices = new List<int>();
    List<int> m_middle_appear_note_indices = new List<int>();
    List<int> m_right_appear_note_indices = new List<int>();
    
    List<List<int>> m_left_disappear_note_indices = new List<List<int>>();
    List<List<int>> m_middle_disappear_note_indices = new List<List<int>>();
    List<List<int>> m_right_disappear_note_indices = new List<List<int>>();

    System.DateTime m_start_time;
    System.DateTime m_current_time;
    bool m_is_start = false;

    // 
    public int m_beats_per_second = 1;
    public int m_span_of_beat_count = 32;
    public float m_track_length = 6;
    Vector3 m_velocity = new Vector3(0,-1,0);
    public Vector3 Velocity
    {
        get
        {
            return m_velocity;
        }
    }

    public Vector3 m_left_start_position = new Vector3(0,0,0);
    public Vector3 m_middle_start_position = new Vector3(0,0,0);
    public Vector3 m_right_start_position = new Vector3(0,0,0);
    public Vector3 m_sprite_scale = new Vector3(0.25f, 0.25f, 0.25f);

    void Start()
    {
        generate_notes();
        generate_appear_notes();
        generate_disappear_notes();

        double t = 1000.0 * m_span_of_beat_count / m_beats_per_second;
        //Debug.Log( "generate_notes : " + m_left_notes.Count + ", m_left_appear_note_indices.Count = " + m_left_appear_note_indices.Count + ", t = " + t );
        m_velocity = new Vector3(0, (float)(-m_track_length / t),0);

        // for( int j=0; j<m_left_notes.Count; ++j )
        // {
        //     Debug.Log( "j : " + j + " disappear : " + m_left_notes[j].m_disappear_beat_index );
        // }

        // for( int j=0; j<m_left_appear_note_indices.Count; ++j )
        // {
        //     Debug.Log( "left appear : " + j + "/" + m_left_appear_note_indices.Count + " : "+ m_left_appear_note_indices[j] );
        // }

        // for( int j=0; j<m_left_disappear_note_indices.Count; ++j )
        // {
        //     Debug.Log( "left disappear : " + j + "/" + m_left_disappear_note_indices.Count + " : "+ m_left_disappear_note_indices[j] );
        // }
    }

    void Awake()
    {
        set_start( true );
    }

    void generate_disappear_notes()
    {
        generate_left_disappear_notes();
        generate_middle_disappear_notes();
        generate_right_disappear_notes();
    }

    void generate_left_disappear_notes()
    {
        for( int j=0; j<m_left_notes.Count; ++j )
        {
            m_left_disappear_note_indices.Add( new List<int>() );
        }

        for( int j=0; j<m_left_notes.Count; ++j )
        {
            if( m_left_notes[j].m_disappear_beat_index > 0 )
            {
                m_left_disappear_note_indices[ m_left_notes[j].m_disappear_beat_index ].Add(j);
            }
        }
    }

    void generate_middle_disappear_notes()
    {
        for( int j=0; j<m_middle_notes.Count; ++j )
        {
            m_middle_disappear_note_indices.Add( new List<int>() );
        }
        
        for( int j=0; j<m_middle_notes.Count; ++j )
        {
            if( m_middle_notes[j].m_disappear_beat_index > 0 )
            {
                m_middle_disappear_note_indices[ m_middle_notes[j].m_disappear_beat_index ].Add(j);
            }
        }
    }

    void generate_right_disappear_notes()
    {
        for( int j=0; j<m_right_notes.Count; ++j )
        {
            m_right_disappear_note_indices.Add( new List<int>() );
        }

        for( int j=0; j<m_right_notes.Count; ++j )
        {
            if( m_right_notes[j].m_disappear_beat_index > 0 )
            {
                m_right_disappear_note_indices[ m_right_notes[j].m_disappear_beat_index ].Add(j);
            }
        }
    }

    void generate_appear_notes()
    {
        generate_left_appear_notes();
        generate_middle_appear_notes();
        generate_right_appear_notes();
    }

    void generate_left_appear_notes()
    {
        for( int j=0; j<m_left_notes.Count; ++j )
        {
            m_left_appear_note_indices.Add( m_left_notes[j].m_appear_beat_index );
        }
    }

    void generate_middle_appear_notes()
    {
        for( int j=0; j<m_middle_notes.Count; ++j )
        {
            m_middle_appear_note_indices.Add( m_middle_notes[j].m_appear_beat_index );
        }
    }

    void generate_right_appear_notes()
    {
        for( int j=0; j<m_right_notes.Count; ++j )
        {
            m_middle_appear_note_indices.Add( m_right_notes[j].m_appear_beat_index );
        }
    }

    void generate_notes()
    {
        generate_left_notes();
        generate_middle_notes();
        generate_right_notes();
    }

    void generate_left_notes()
    {
        int[] appear_beat_indices = { 
            -1,
            -1,
            2,
            3,
            -1,
            -1,
            -1,
            7,
            8,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
        };
        for( int j=0; j<appear_beat_indices.Length; ++j )
        {
            Note note = new Note();
            note.m_appear_beat_index = appear_beat_indices[j];
            if( note.m_appear_beat_index < 0 )
            {
                note.m_disappear_beat_index = -1;
            }
            else
            {
                note.m_disappear_beat_index = appear_beat_indices[j] + m_span_of_beat_count;
                if( note.m_disappear_beat_index >= appear_beat_indices.Length )
                {
                    note.m_disappear_beat_index = appear_beat_indices.Length-1;
                }
            }

            note.m_side = NoteSide.NoteSide_Left;
            m_left_notes.Add( note );
        }
    }

    void generate_middle_notes()
    {
        int[] appear_beat_indices = { 
            -1,
            -1,
            2,
            3,
            -1,
            -1,
            -1,
            7,
            8,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
        };
        for( int j=0; j<appear_beat_indices.Length; ++j )
        {
            Note note = new Note();
            note.m_appear_beat_index = appear_beat_indices[j];
            if( note.m_appear_beat_index < 0 )
            {
                note.m_disappear_beat_index = -1;
            }
            else
            {
                note.m_disappear_beat_index = appear_beat_indices[j] + m_span_of_beat_count;
                if( note.m_disappear_beat_index >= appear_beat_indices.Length )
                {
                    note.m_disappear_beat_index = appear_beat_indices.Length-1;
                }
            }
            note.m_side = NoteSide.NoteSide_Middle;
            m_middle_notes.Add( note );
        }
    }

    void generate_right_notes()
    {
        int[] appear_beat_indices = { 
            -1,
            -1,
            2,
            3,
            -1,
            -1,
            -1,
            7,
            8,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
        };
        for( int j=0; j<appear_beat_indices.Length; ++j )
        {
            Note note = new Note();
            note.m_appear_beat_index = appear_beat_indices[j];
            if( note.m_appear_beat_index < 0 )
            {
                note.m_disappear_beat_index = -1;
            }
            else
            {
                note.m_disappear_beat_index = appear_beat_indices[j] + m_span_of_beat_count;
                if( note.m_disappear_beat_index >= appear_beat_indices.Length )
                {
                    note.m_disappear_beat_index = appear_beat_indices.Length-1;
                }
            }
            note.m_side = NoteSide.NoteSide_Right;
            m_right_notes.Add( note );
        }
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
        if( current_beat_index >= m_left_notes.Count )
        {
            set_start( false );
        }
        //Debug.Log( "span.TotalMilliseconds = " + span.TotalMilliseconds + ", current_beat_index = " + current_beat_index );
        bool isok = check_appear_note( current_beat_index, ref m_left_notes, m_left_appear_note_indices, m_left_start_position, m_current_time );
        // if( isok )
        // {
        //     Debug.Log( "====================" );
        //     for( int j=0; j<m_left_notes.Count; ++j )
        //     {
        //         Debug.Log( "j : " + j + " : " + m_left_notes[j].m_gameobject );
        //     }
        // }
        // check_appear_note( current_beat_index, ref m_middle_notes, m_middle_appear_note_indices, m_middle_start_position, m_current_time );
        // check_appear_note( current_beat_index, ref m_right_notes, m_right_appear_note_indices, m_right_start_position, m_current_time );

        check_disappear_note( current_beat_index, ref m_left_notes, m_left_disappear_note_indices, m_current_time );
        // check_disappear_note( current_beat_index, ref m_middle_notes, m_middle_disappear_note_indices, m_current_time );
        // check_disappear_note( current_beat_index, ref m_right_notes, m_right_disappear_note_indices, m_current_time );
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
        GameObject go = new GameObject();
        // go.name = "character";
        // go.tag = "Player";
        // go.layer = MyConsts.LAYER_PLAYER;
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>( "normal_note" );
        // renderer.sortingLayerName = MyConsts.SORTING_LAYER_FOREGROUND_NAME;
        go.transform.localPosition = start_position;
        go.transform.localScale = m_sprite_scale;

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

public enum NoteType
{
    NoteTypeSingle,
    NoteTypePush,
    NoteTypeRelease,
    NoteTypeKePressed,
}

public class Note
{
    public int m_appear_beat_index = -1;
    public NoteSide m_side;
    public NoteType m_note_type;
    public int m_length = 0;

    public int m_disappear_beat_index = -1;
    public System.DateTime m_appear_time;
    public System.DateTime m_disappear_time;
    public bool m_visible = false;
    public GameObject m_gameobject = null;
}