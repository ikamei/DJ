// NotesGenerator.cs --- 
// Filename: NotesGenerator.cs
// Created: Sun Oct  4 18:03:48 2020 (+0800)
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

public class NotesGenerator// : MonoBehaviour
{
    public float m_beats_per_second = 1;
    public float m_span_of_disappear_seconds = 2;
    int m_span_of_disappear_beat_count;

    public List<Note> m_left_notes = new List<Note>();
    public List<Note> m_right_notes = new List<Note>();

    public List<int> m_left_appear_note_indices = new List<int>();
    public List<int> m_right_appear_note_indices = new List<int>();

    public List<List<int>> m_left_disappear_note_indices = new List<List<int>>();
    public List<List<int>> m_right_disappear_note_indices = new List<List<int>>();

    public NotesGenerator( float beats_per_second, float span_of_disappear_seconds )
    {
        m_beats_per_second = beats_per_second;
        m_span_of_disappear_seconds = span_of_disappear_seconds;

        m_span_of_disappear_beat_count = (int)(m_beats_per_second * m_span_of_disappear_seconds + 0.5);
        // Debug.Log( "m_span_of_disappear_beat_count = " + m_span_of_disappear_beat_count );
        generate_notes();
        fix_disappear_index();
        // dump_notes(m_left_notes);
        generate_appear_notes();
        // dump_note_indices( m_left_appear_note_indices );
        generate_disappear_notes();
        // dump_note_indices( m_left_disappear_note_indices );
    }

    void dump_notes(List<Note> notes)
    {
        for( int j=0; j<notes.Count; ++j )
        {
            Note note = notes[j];
            Debug.Log( "" + j + "/" + notes.Count + ": appear:" + note.m_appear_beat_index + ": disappear:" + note.m_disappear_beat_index + ", type:" + note.m_note_type + ", length:" + note.m_length );
        }
    }
    void dump_note( Note note)
    {
        Debug.Log( "appear:" + note.m_appear_beat_index + ": disappear:" + note.m_disappear_beat_index + ", type:" + note.m_note_type + ", length:" + note.m_length );        
    }
    void dump_note_indices(List<int> appear_note_indices)
    {
        for( int j=0; j<appear_note_indices.Count; ++j )
        {
            int index = appear_note_indices[j];
            Debug.Log( "" + j + "/" + appear_note_indices.Count + " : " + index );
        }
    }

    void dump_note_indices(List<List<int>> disappear_note_indices)
    {
        for( int j=0; j<disappear_note_indices.Count; ++j )
        {
            List<int> indices = disappear_note_indices[j];
            string str = "" + j + "/" + disappear_note_indices.Count + " : ";
            for( int k=0; k<indices.Count; ++k )
            {
                str += "" + indices[k] + ", ";
            }
            Debug.Log( str );
        }
    }

    void generate_appear_notes()
    {
        generate_left_appear_notes();
        generate_right_appear_notes();
    }

    void generate_left_appear_notes()
    {
        int offset = (int)(m_beats_per_second * 1.9 + 0.5);
        //offset = 0;
        Debug.Log( "offset = " + offset );
        for( int j=0; j<m_left_notes.Count-offset; ++j )
        {
            m_left_appear_note_indices.Add( m_left_notes[j + offset].m_appear_beat_index  );
        }
    }

    void generate_right_appear_notes()
    {
        int offset = (int)(m_beats_per_second * 1.9 + 0.5);
        for( int j=0; j<m_right_notes.Count-offset; ++j )
        {
            m_right_appear_note_indices.Add( m_right_notes[j + offset].m_appear_beat_index );
        }
    }

    public virtual void generate_notes()
    {
        generate_section_1();
        generate_section_2();
        generate_section_3();
        generate_section_4();
        generate_section_5();
        generate_section_6();
        generate_section_7();
        generate_section_8();
        generate_section_9();
    }

    void fix_disappear_index()
    {
        for( int j=0; j<m_left_notes.Count; ++j )
        {
            if( m_left_notes[j].m_disappear_beat_index >= m_left_notes.Count )
            {
                m_left_notes[j].m_disappear_beat_index = m_left_notes.Count-1;
            }
        }

        for( int j=0; j<m_right_notes.Count; ++j )
        {
            if( m_right_notes[j].m_disappear_beat_index >= m_right_notes.Count )
            {
                m_right_notes[j].m_disappear_beat_index = m_right_notes.Count-1;
            }
        }

    }

    void generate_section_1()
    {
        int offset = 64+32;
        // index, length, side
        int[] items = { 
            offset+0,   2, (int)(NoteSide.NoteSide_Left),
            offset+28,  2, (int)(NoteSide.NoteSide_Left),
            offset+32,  2, (int)(NoteSide.NoteSide_Left),
            offset+60,  2, (int)(NoteSide.NoteSide_Left),
            offset+64,  2, (int)(NoteSide.NoteSide_Left),
            offset+92,  2, (int)(NoteSide.NoteSide_Left),
            offset+96,  2, (int)(NoteSide.NoteSide_Left),
            offset+102, 2, (int)(NoteSide.NoteSide_Left),
            offset+108, 2, (int)(NoteSide.NoteSide_Left),
            offset+128, 2, (int)(NoteSide.NoteSide_Left),
            offset+136, 2, (int)(NoteSide.NoteSide_Left),
            offset+144, 6, (int)(NoteSide.NoteSide_Left),
            offset+158, 2, (int)(NoteSide.NoteSide_Left),
            offset+192, 6, (int)(NoteSide.NoteSide_Left),
            offset+198, 2, (int)(NoteSide.NoteSide_Left),
            offset+220, 2, (int)(NoteSide.NoteSide_Left),
            offset+224, 6, (int)(NoteSide.NoteSide_Left),
            offset+230, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_2()
    {
        int offset = 320+32;
        // index, length, side
        int[] items = { 
            offset+0,  2,  (int)(NoteSide.NoteSide_Right),
            offset+8,  2,  (int)(NoteSide.NoteSide_Right),
            offset+16 ,2,  (int)(NoteSide.NoteSide_Right),
            offset+18, 2,  (int)(NoteSide.NoteSide_Right),
            offset+20, 2,  (int)(NoteSide.NoteSide_Right),
            offset+22, 6,  (int)(NoteSide.NoteSide_Right),
            offset+28, 2,  (int)(NoteSide.NoteSide_Right),
            offset+30, 2,  (int)(NoteSide.NoteSide_Right),
            offset+54, 2,  (int)(NoteSide.NoteSide_Right),
            offset+56, 2,  (int)(NoteSide.NoteSide_Right),
            offset+60, 2,  (int)(NoteSide.NoteSide_Right),
            offset+64, 6,  (int)(NoteSide.NoteSide_Right),
            offset+70, 2,  (int)(NoteSide.NoteSide_Right),
            offset+92, 2,  (int)(NoteSide.NoteSide_Right),
            offset+96, 6,  (int)(NoteSide.NoteSide_Right),
            offset+102, 2, (int)(NoteSide.NoteSide_Right),
            offset+108, 2, (int)(NoteSide.NoteSide_Right),
            offset+124, 2, (int)(NoteSide.NoteSide_Right),
            offset+126, 2, (int)(NoteSide.NoteSide_Right),
            offset+128, 2, (int)(NoteSide.NoteSide_Right),
            offset+136, 2, (int)(NoteSide.NoteSide_Right),
            offset+144, 2, (int)(NoteSide.NoteSide_Right),
            offset+146, 2, (int)(NoteSide.NoteSide_Right),
            offset+148, 2, (int)(NoteSide.NoteSide_Right),
            offset+150, 6, (int)(NoteSide.NoteSide_Right),
            offset+156, 2, (int)(NoteSide.NoteSide_Right),
            offset+158, 2, (int)(NoteSide.NoteSide_Right),
            offset+182, 2, (int)(NoteSide.NoteSide_Right),
            offset+184, 2, (int)(NoteSide.NoteSide_Right),
            offset+188, 2, (int)(NoteSide.NoteSide_Right),
            offset+192, 6, (int)(NoteSide.NoteSide_Right),
            offset+220, 2, (int)(NoteSide.NoteSide_Right),
            offset+222, 2, (int)(NoteSide.NoteSide_Right),
            offset+224, 6, (int)(NoteSide.NoteSide_Right),
            offset+230, 2, (int)(NoteSide.NoteSide_Right),
            offset+236, 10,(int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_3()
    {
        int offset = 576+32;
        // index, length, side
        int[] items = { 
            offset+0,   2, (int)(NoteSide.NoteSide_Left),
            offset+4,   2, (int)(NoteSide.NoteSide_Left),
            offset+8,   2, (int)(NoteSide.NoteSide_Left),
            offset+12,  2, (int)(NoteSide.NoteSide_Left),
            offset+14,  2, (int)(NoteSide.NoteSide_Left),
            offset+20,  2, (int)(NoteSide.NoteSide_Left),
            offset+24,  2, (int)(NoteSide.NoteSide_Left),
            offset+28,  2, (int)(NoteSide.NoteSide_Left),
            offset+32,  2, (int)(NoteSide.NoteSide_Left),
            offset+36,  2, (int)(NoteSide.NoteSide_Left),
            offset+40,  2, (int)(NoteSide.NoteSide_Left),
            offset+44,  2, (int)(NoteSide.NoteSide_Left),
            offset+46,  2, (int)(NoteSide.NoteSide_Left),
            offset+52,  2, (int)(NoteSide.NoteSide_Left),
            offset+56,  2, (int)(NoteSide.NoteSide_Left),
            offset+60,  2, (int)(NoteSide.NoteSide_Left),
            offset+62,  2, (int)(NoteSide.NoteSide_Left),
            offset+92,  2, (int)(NoteSide.NoteSide_Left),
            offset+96,  2, (int)(NoteSide.NoteSide_Left),
            offset+102, 2, (int)(NoteSide.NoteSide_Left),
            offset+108, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_4()
    {
        int offset = 704+32;
        // index, length, side
        int[] items = { 
            offset+0,   2,  (int)(NoteSide.NoteSide_Right),
            offset+4,   2,  (int)(NoteSide.NoteSide_Right),
            offset+8,   2,  (int)(NoteSide.NoteSide_Right),
            offset+12,  2,  (int)(NoteSide.NoteSide_Right),
            offset+14,  2,  (int)(NoteSide.NoteSide_Right),
            offset+20,  2,  (int)(NoteSide.NoteSide_Right),
            offset+24,  2,  (int)(NoteSide.NoteSide_Right),
            offset+28,  2,  (int)(NoteSide.NoteSide_Right),
            offset+32,  2,  (int)(NoteSide.NoteSide_Right),
            offset+36,  2,  (int)(NoteSide.NoteSide_Right),
            offset+40,  2,  (int)(NoteSide.NoteSide_Right),
            offset+44,  2,  (int)(NoteSide.NoteSide_Right),
            offset+46,  2,  (int)(NoteSide.NoteSide_Right),
            offset+52,  2,  (int)(NoteSide.NoteSide_Right),
            offset+56,  2,  (int)(NoteSide.NoteSide_Right),
            offset+60,  2,  (int)(NoteSide.NoteSide_Right),
            offset+62,  2,  (int)(NoteSide.NoteSide_Right),
            offset+76,  2,  (int)(NoteSide.NoteSide_Right),
            offset+92,  2,  (int)(NoteSide.NoteSide_Right),
            offset+94,  2,  (int)(NoteSide.NoteSide_Right),
            offset+96,  2,  (int)(NoteSide.NoteSide_Right),
            offset+102, 2,  (int)(NoteSide.NoteSide_Right),
            offset+108, 2,  (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_5()
    {
        int offset = 832+32;
        // index, length, side
        int[] items = { 
            offset+0,  2, (int)(NoteSide.NoteSide_Left),
            offset+8,  2, (int)(NoteSide.NoteSide_Left),
            offset+16, 6, (int)(NoteSide.NoteSide_Left),
            offset+22, 2, (int)(NoteSide.NoteSide_Left),
            offset+28, 30, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_6()
    {
        int offset = 896+32;
        // index, length, side
        int[] items = { 
            offset+0,  2, (int)(NoteSide.NoteSide_Left),
            offset+8,  2, (int)(NoteSide.NoteSide_Left),
            offset+16, 6, (int)(NoteSide.NoteSide_Left),
            offset+22, 2, (int)(NoteSide.NoteSide_Left),
            offset+28, 30, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_7()
    {
        int offset = 960+32;
        // index, length, side
        int[] items = { 
            offset+0,  2, (int)(NoteSide.NoteSide_Left),
            offset+8,  2, (int)(NoteSide.NoteSide_Left),
            offset+16, 6, (int)(NoteSide.NoteSide_Left),
            offset+22, 2, (int)(NoteSide.NoteSide_Left),
            offset+28, 30, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_8()
    {
        int offset = 1024+32;
        // index, length, side
        int[] items = { 
            offset+0,  2, (int)(NoteSide.NoteSide_Left),
            offset+8,  2, (int)(NoteSide.NoteSide_Left),
            offset+16, 6, (int)(NoteSide.NoteSide_Left),
            offset+22, 2, (int)(NoteSide.NoteSide_Left),
            offset+28, 30, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_9()
    {
        int offset = 1088+32;
        // index, length, side
        int[] items = { 
            offset+0,   2,  (int)(NoteSide.NoteSide_Right),
            offset+14,  2,  (int)(NoteSide.NoteSide_Right),
            offset+16,  2,  (int)(NoteSide.NoteSide_Right),
            offset+18,  2,  (int)(NoteSide.NoteSide_Right),
            offset+20,  2,  (int)(NoteSide.NoteSide_Right),
            offset+22,  2,  (int)(NoteSide.NoteSide_Right),
            offset+26,  2,  (int)(NoteSide.NoteSide_Right),
            offset+32,  2,  (int)(NoteSide.NoteSide_Right),
            offset+40,  2,  (int)(NoteSide.NoteSide_Right),
            offset+46,  2,  (int)(NoteSide.NoteSide_Right),
            offset+48,  2,  (int)(NoteSide.NoteSide_Right),
            offset+50,  2,  (int)(NoteSide.NoteSide_Right),
            offset+52,  2,  (int)(NoteSide.NoteSide_Right),
            offset+54,  2,  (int)(NoteSide.NoteSide_Right),
            offset+58,  2,  (int)(NoteSide.NoteSide_Right),
            offset+62,  2,  (int)(NoteSide.NoteSide_Right),
            offset+68,  2,  (int)(NoteSide.NoteSide_Right),
            offset+74,  2,  (int)(NoteSide.NoteSide_Right),
            offset+82,  2,  (int)(NoteSide.NoteSide_Right),
            offset+84,  2,  (int)(NoteSide.NoteSide_Right),
            offset+88,  2,  (int)(NoteSide.NoteSide_Right),
            offset+92,  2,  (int)(NoteSide.NoteSide_Right),
            offset+96,  2,  (int)(NoteSide.NoteSide_Right),
            offset+98,  2,  (int)(NoteSide.NoteSide_Right),
            offset+102, 2,  (int)(NoteSide.NoteSide_Right),
            offset+106, 2,  (int)(NoteSide.NoteSide_Right),
            offset+112, 2,  (int)(NoteSide.NoteSide_Right),
            offset+114, 2,  (int)(NoteSide.NoteSide_Right),
            offset+118, 2,  (int)(NoteSide.NoteSide_Right),
            offset+122, 2,  (int)(NoteSide.NoteSide_Right),
            offset+124, 2,  (int)(NoteSide.NoteSide_Right),
            offset+126, 2,  (int)(NoteSide.NoteSide_Right),
            offset+128, 2,  (int)(NoteSide.NoteSide_Right),
            offset+132, 2,  (int)(NoteSide.NoteSide_Right),
            offset+136, 2,  (int)(NoteSide.NoteSide_Right),
            offset+140, 2,  (int)(NoteSide.NoteSide_Right),
            offset+142, 2,  (int)(NoteSide.NoteSide_Right),
            offset+146, 2,  (int)(NoteSide.NoteSide_Right),
            offset+156, 2,  (int)(NoteSide.NoteSide_Right),
            offset+162, 2,  (int)(NoteSide.NoteSide_Right),
            offset+164, 2,  (int)(NoteSide.NoteSide_Right),
            offset+166, 2,  (int)(NoteSide.NoteSide_Right),
            offset+170, 2,  (int)(NoteSide.NoteSide_Right),
            offset+174, 2,  (int)(NoteSide.NoteSide_Right),
            offset+178, 2,  (int)(NoteSide.NoteSide_Right),
            offset+182, 2,  (int)(NoteSide.NoteSide_Right),
            offset+186, 2,  (int)(NoteSide.NoteSide_Right),
            offset+188, 2,  (int)(NoteSide.NoteSide_Right),
            offset+192, 2,  (int)(NoteSide.NoteSide_Right),
            offset+194, 2,  (int)(NoteSide.NoteSide_Right),
            offset+198, 2,  (int)(NoteSide.NoteSide_Right),
            offset+202, 2,  (int)(NoteSide.NoteSide_Right),
            offset+208, 2,  (int)(NoteSide.NoteSide_Right),
            offset+210, 2,  (int)(NoteSide.NoteSide_Right),
            offset+226, 2,  (int)(NoteSide.NoteSide_Right),
            offset+228, 2,  (int)(NoteSide.NoteSide_Right),
            offset+232, 2,  (int)(NoteSide.NoteSide_Right),
            offset+234, 2,  (int)(NoteSide.NoteSide_Right),
            offset+238, 2,  (int)(NoteSide.NoteSide_Right),
            offset+242, 2,  (int)(NoteSide.NoteSide_Right),
            offset+246, 2,  (int)(NoteSide.NoteSide_Right),
            offset+248, 2,  (int)(NoteSide.NoteSide_Right),
            offset+252, 2,  (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    protected void resize_cached_notes(int[] items)
    {
        int new_size = items[items.Length-3] + items[items.Length-2] + m_span_of_disappear_beat_count;
        for( int j=m_left_notes.Count; j<new_size; ++j )
        {
            Note note = new Note();
            note.m_appear_beat_index = -1;
            m_left_notes.Add(note);
        }

        for( int j=m_right_notes.Count; j<new_size; ++j )
        {
            Note note = new Note();
            note.m_appear_beat_index = -1;
            m_right_notes.Add(note);
        }
    }

    void cache_note( int index, NoteSide side, Note note )
    {
        if( NoteSide.NoteSide_Left==side )
        {
            m_left_notes[index] = note;
        }
        else if( NoteSide.NoteSide_Right==side )
        {
            m_right_notes[index] = note;
        }
        
    }


    protected void generate_notes( int[] items )
    {
        for( int j=0; j<items.Length; j+=3 )
        {
            int index = items[j];
            int length = items[j+1];
            NoteSide side = (NoteSide)(items[j+2]);

            if( 2==length )
            {
                Note note = create_single_note(index, length, side );
                cache_note( index, side, note );
            }
            else
            {
                List<Note> notes = create_complex_notes(index, length, side);
                for( int k=0; k<notes.Count; ++k )
                {
                    //dump_note( notes[k] );
                    cache_note( index+k, side, notes[k] );
                }
            }
        }
    }

    Note create_single_note( int index, int length, NoteSide side )
    {
        Note note = new Note();
        note.m_appear_beat_index = index;// - m_span_of_disappear_beat_count;
        if( index < 0 )
        {
            note.m_disappear_beat_index = -1;
        }
        else
        {
            // note.m_disappear_beat_index = index + m_span_of_disappear_beat_count;
            note.m_disappear_beat_index = index + m_span_of_disappear_beat_count / 5;
            // Debug.Log( "create_single_note : index : " + index + ", m_span_of_disappear_beat_count : " + m_span_of_disappear_beat_count + ", note.m_disappear_beat_index : " + note.m_disappear_beat_index );
            // if( note.m_disappear_beat_index >= m_left_appear_note_indices.Count )
            // {
            //     note.m_disappear_beat_index = m_left_appear_note_indices.Count-1;
            // }
        }

        note.m_side = side;
        note.m_length = length;
        note.m_note_type = NoteType.NoteTypeSingle;
        return note;
    }

    List<Note> create_complex_notes( int index, int length, NoteSide side )
    {
        List<Note> notes = new List<Note>();
        for( int j=0; j<length; ++j )
        {
            Note note = create_single_note( j+index, 1, side );
            // Debug.Log( "appear : " + note.m_appear_beat_index + ", disappear : " + note.m_disappear_beat_index );

            if( 0==j )
            {
                note.m_note_type = NoteType.NoteTypePush;
            }
            else if( length-1==j )
            {
                note.m_note_type = NoteType.NoteTypeRelease;
            }
            else
            {
                note.m_note_type = NoteType.NoteTypeKePressed;
            }
            notes.Add( note );
        }
        return notes;
    }

    void generate_disappear_notes()
    {
        generate_left_disappear_notes();
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
}



// public class NewNote
// {
//     public NoteSide m_side;
//     public NoteType m_note_type;
//     public int m_length = 0;

//     public int m_appear_beat_index = -1;
//     public int m_disappear_beat_index = -1;
//     public System.DateTime m_appear_time;
//     public System.DateTime m_disappear_time;
//     public bool m_visible = false;
//     public GameObject m_gameobject = null;
// }