// NotesGeneratorB.cs --- 
// Filename: NotesGeneratorB.cs
// Created: Mon Oct  5 20:18:28 2020 (+0800)
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

public class NotesGeneratorB : NotesGenerator
{
    public NotesGeneratorB( float beats_per_second, float span_of_disappear_seconds ) : base(beats_per_second, span_of_disappear_seconds)
    {
    }

    public override void generate_notes() 
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

        generate_section_10();
        generate_section_11();
        generate_section_12();
        generate_section_13();
        generate_section_14();
        generate_section_15();
        generate_section_16();
        generate_section_17();
        generate_section_18();
        generate_section_19();

        generate_section_20();
        //generate_section_21();
        generate_section_22();
        generate_section_23();
        generate_section_24();
        generate_section_25();
        generate_section_26();
        generate_section_27();
        generate_section_28();
        generate_section_29();

        generate_section_30();
        generate_section_31();
        generate_section_32();
        generate_section_33();
        generate_section_34();
        generate_section_35();
        generate_section_36();
        generate_section_37();
    }

    void generate_section_1()
    {
        int offset = 0+32;
        // index, length, side
        int[] items = { 
            offset+0,  18, (int)(NoteSide.NoteSide_Left),
            offset+18,  2, (int)(NoteSide.NoteSide_Left),
            offset+20,  2, (int)(NoteSide.NoteSide_Left),
            offset+22,  2, (int)(NoteSide.NoteSide_Left),
            offset+24,  3, (int)(NoteSide.NoteSide_Left),
            offset+27,  2, (int)(NoteSide.NoteSide_Left),
            offset+31, 16, (int)(NoteSide.NoteSide_Left),
            offset+47,  2, (int)(NoteSide.NoteSide_Left),
            offset+48, 16, (int)(NoteSide.NoteSide_Left),
            offset+64,  4, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_2()
    {
        int offset = 192+32;
        // index, length, side
        int[] items = { 
            offset+4,  2, (int)(NoteSide.NoteSide_Left),
            offset+8,  2, (int)(NoteSide.NoteSide_Left),
            offset+16, 2, (int)(NoteSide.NoteSide_Left),
            offset+22, 2, (int)(NoteSide.NoteSide_Left),
            offset+26, 2, (int)(NoteSide.NoteSide_Left),
            offset+27, 2, (int)(NoteSide.NoteSide_Left),
            offset+36, 2, (int)(NoteSide.NoteSide_Left),
            offset+40, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_3()
    {
        int offset = 192+32;
        // index, length, side
        int[] items = { 
            offset+44, 2, (int)(NoteSide.NoteSide_Right),
            offset+46, 2, (int)(NoteSide.NoteSide_Right),
            offset+48, 2, (int)(NoteSide.NoteSide_Right),
            offset+50, 2, (int)(NoteSide.NoteSide_Right),
            offset+52, 2, (int)(NoteSide.NoteSide_Right),
            offset+54, 2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_4()
    {
        int offset = 256+32;
        // index, length, side
        int[] items = { 
            offset+4,  2, (int)(NoteSide.NoteSide_Left),
            offset+8,  2, (int)(NoteSide.NoteSide_Left),
            offset+16, 2, (int)(NoteSide.NoteSide_Left),
            offset+22, 2, (int)(NoteSide.NoteSide_Left),
            offset+26, 2, (int)(NoteSide.NoteSide_Left),
            offset+27, 2, (int)(NoteSide.NoteSide_Left),
            offset+36, 2, (int)(NoteSide.NoteSide_Left),
            offset+40, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_5()
    {
        int offset = 256+32;
        // index, length, side
        int[] items = { 
            offset+44, 2, (int)(NoteSide.NoteSide_Right),
            offset+46, 2, (int)(NoteSide.NoteSide_Right),
            offset+48, 2, (int)(NoteSide.NoteSide_Right),
            offset+50, 2, (int)(NoteSide.NoteSide_Right),
            offset+52, 2, (int)(NoteSide.NoteSide_Right),
            offset+54, 2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_6()
    {
        int offset = 320+32;
        // index, length, side
        int[] items = { 
            offset+4,  2, (int)(NoteSide.NoteSide_Left),
            offset+8,  2, (int)(NoteSide.NoteSide_Left),
            offset+16, 2, (int)(NoteSide.NoteSide_Left),
            offset+22, 2, (int)(NoteSide.NoteSide_Left),
            offset+26, 2, (int)(NoteSide.NoteSide_Left),
            offset+27, 2, (int)(NoteSide.NoteSide_Left),
            offset+36, 2, (int)(NoteSide.NoteSide_Left),
            offset+40, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_7()
    {
        int offset = 320+32;
        // index, length, side
        int[] items = { 
            offset+44, 2, (int)(NoteSide.NoteSide_Right),
            offset+46, 2, (int)(NoteSide.NoteSide_Right),
            offset+48, 2, (int)(NoteSide.NoteSide_Right),
            offset+50, 2, (int)(NoteSide.NoteSide_Right),
            offset+52, 2, (int)(NoteSide.NoteSide_Right),
            offset+54, 2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_8()
    {
        int offset = 384+32;
        // index, length, side
        int[] items = { 
            offset+4,  2, (int)(NoteSide.NoteSide_Left),
            offset+8,  2, (int)(NoteSide.NoteSide_Left),
            offset+16, 2, (int)(NoteSide.NoteSide_Left),
            offset+22, 2, (int)(NoteSide.NoteSide_Left),
            offset+26, 2, (int)(NoteSide.NoteSide_Left),
            offset+27, 2, (int)(NoteSide.NoteSide_Left),
            offset+36, 2, (int)(NoteSide.NoteSide_Left),
            offset+40, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_9()
    {
        int offset = 384+32;
        // index, length, side
        int[] items = { 
            offset+44, 2, (int)(NoteSide.NoteSide_Right),
            offset+46, 2, (int)(NoteSide.NoteSide_Right),
            offset+48, 2, (int)(NoteSide.NoteSide_Right),
            offset+50, 2, (int)(NoteSide.NoteSide_Right),
            offset+52, 2, (int)(NoteSide.NoteSide_Right),
            offset+54, 2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_10()
    {
        int offset = 448+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_11()
    {
        int offset = 480+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_12()
    {
        int offset = 512+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_13()
    {
        int offset = 544+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_14()
    {
        int offset = 576+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_15()
    {
        int offset = 608+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_16()
    {
        int offset = 640+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_17()
    {
        int offset = 672+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_18()
    {
        int offset = 704+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_19()
    {
        int offset = 736+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_20()
    {
        int offset = 768+32;
        // index, length, side
        int[] items = { 
            offset+6, 2, (int)(NoteSide.NoteSide_Right),
            offset+8, 2, (int)(NoteSide.NoteSide_Right),
            offset+12,2, (int)(NoteSide.NoteSide_Right),
            offset+14,2, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_22()
    {
        int offset = 576+32;
        // index, length, side
        int[] items = { 
            offset+48, 2, (int)(NoteSide.NoteSide_Left),
            offset+54, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_23()
    {
        int offset = 640+32;
        // index, length, side
        int[] items = { 
            offset+48, 2, (int)(NoteSide.NoteSide_Left),
            offset+54, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_24()
    {
        int offset = 704+32;
        // index, length, side
        int[] items = { 
            offset+48, 2, (int)(NoteSide.NoteSide_Left),
            offset+54, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_25()
    {
        int offset = 768+32;
        // index, length, side
        int[] items = { 
            offset+48, 2, (int)(NoteSide.NoteSide_Left),
            offset+54, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_26()
    {
        int offset = 832+32;
        // index, length, side
        int[] items = { 
            offset+0,  4, (int)(NoteSide.NoteSide_Right),
            offset+8,  4, (int)(NoteSide.NoteSide_Right),
            offset+16, 4, (int)(NoteSide.NoteSide_Right),
            offset+22, 4, (int)(NoteSide.NoteSide_Right),
            offset+28, 4, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_27()
    {
        int offset = 896+32;
        // index, length, side
        int[] items = { 
            offset+0,  4, (int)(NoteSide.NoteSide_Right),
            offset+8,  4, (int)(NoteSide.NoteSide_Right),
            offset+16, 4, (int)(NoteSide.NoteSide_Right),
            offset+22, 4, (int)(NoteSide.NoteSide_Right),
            offset+28, 4, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_28()
    {
        int offset = 960+32;
        // index, length, side
        int[] items = { 
            offset+0,  4, (int)(NoteSide.NoteSide_Right),
            offset+8,  4, (int)(NoteSide.NoteSide_Right),
            offset+16, 4, (int)(NoteSide.NoteSide_Right),
            offset+22, 4, (int)(NoteSide.NoteSide_Right),
            offset+28, 4, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_29()
    {
        int offset = 1024+32;
        // index, length, side
        int[] items = { 
            offset+0,  4, (int)(NoteSide.NoteSide_Right),
            offset+8,  4, (int)(NoteSide.NoteSide_Right),
            offset+16, 4, (int)(NoteSide.NoteSide_Right),
            offset+22, 4, (int)(NoteSide.NoteSide_Right),
            offset+28, 36, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }


    void generate_section_30()
    {
        int offset = 1088+32;
        // index, length, side
        int[] items = { 
            offset+0,  4, (int)(NoteSide.NoteSide_Right),
            offset+8,  4, (int)(NoteSide.NoteSide_Right),
            offset+16, 4, (int)(NoteSide.NoteSide_Right),
            offset+22, 4, (int)(NoteSide.NoteSide_Right),
            offset+28, 4, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_31()
    {
        int offset = 1152+32;
        // index, length, side
        int[] items = { 
            offset+0,  4, (int)(NoteSide.NoteSide_Right),
            offset+8,  4, (int)(NoteSide.NoteSide_Right),
            offset+16, 4, (int)(NoteSide.NoteSide_Right),
            offset+22, 4, (int)(NoteSide.NoteSide_Right),
            offset+28, 4, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_32()
    {
        int offset = 1216+32;
        // index, length, side
        int[] items = { 
            offset+0,  4, (int)(NoteSide.NoteSide_Right),
            offset+8,  4, (int)(NoteSide.NoteSide_Right),
            offset+16, 4, (int)(NoteSide.NoteSide_Right),
            offset+22, 4, (int)(NoteSide.NoteSide_Right),
            offset+28, 4, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_33()
    {
        int offset = 1280+32;
        // index, length, side
        int[] items = { 
            offset+0,  4, (int)(NoteSide.NoteSide_Right),
            offset+8,  4, (int)(NoteSide.NoteSide_Right),
            offset+16, 4, (int)(NoteSide.NoteSide_Right),
            offset+22, 4, (int)(NoteSide.NoteSide_Right),
            offset+28, 36, (int)(NoteSide.NoteSide_Right),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_34()
    {
        int offset = 832+32;
        // index, length, side
        int[] items = { 
            offset+44, 2, (int)(NoteSide.NoteSide_Left),
            offset+46, 2, (int)(NoteSide.NoteSide_Left),
            offset+48, 2, (int)(NoteSide.NoteSide_Left),
            offset+50, 2, (int)(NoteSide.NoteSide_Left),
            offset+52, 2, (int)(NoteSide.NoteSide_Left),
            offset+54, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }
    void generate_section_35()
    {
        int offset = 896+32;
        // index, length, side
        int[] items = { 
            offset+44, 2, (int)(NoteSide.NoteSide_Left),
            offset+46, 2, (int)(NoteSide.NoteSide_Left),
            offset+48, 2, (int)(NoteSide.NoteSide_Left),
            offset+50, 2, (int)(NoteSide.NoteSide_Left),
            offset+52, 2, (int)(NoteSide.NoteSide_Left),
            offset+54, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_36()
    {
        int offset = 960+32;
        // index, length, side
        int[] items = { 
            offset+44, 2, (int)(NoteSide.NoteSide_Left),
            offset+46, 2, (int)(NoteSide.NoteSide_Left),
            offset+48, 2, (int)(NoteSide.NoteSide_Left),
            offset+50, 2, (int)(NoteSide.NoteSide_Left),
            offset+52, 2, (int)(NoteSide.NoteSide_Left),
            offset+54, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }

    void generate_section_37()
    {
        int offset = 1024+32;
        // index, length, side
        int[] items = { 
            offset+44, 2, (int)(NoteSide.NoteSide_Left),
            offset+46, 2, (int)(NoteSide.NoteSide_Left),
            offset+48, 2, (int)(NoteSide.NoteSide_Left),
            offset+50, 2, (int)(NoteSide.NoteSide_Left),
            offset+52, 2, (int)(NoteSide.NoteSide_Left),
            offset+54, 2, (int)(NoteSide.NoteSide_Left),
        };
        resize_cached_notes(items);
        generate_notes( items );
    }
}

