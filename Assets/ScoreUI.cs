// ScoreUI.cs --- 
// Filename: ScoreUI.cs
// Created: Mon Oct  5 14:00:27 2020 (+0800)
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

public class ScoreUI : MonoBehaviour
{
    List<Image> m_number_images = null;
    public Sprite m_number_0 = null;
    public Sprite m_number_1 = null;
    public Sprite m_number_2 = null;
    public Sprite m_number_3 = null;
    public Sprite m_number_4 = null;
    public Sprite m_number_5 = null;
    public Sprite m_number_6 = null;
    public Sprite m_number_7 = null;
    public Sprite m_number_8 = null;
    public Sprite m_number_9 = null;
    Sprite[] m_number_sprites;
    void Start()
    {
        Sprite[] number_sprites = { 
            m_number_0,
            m_number_1,
            m_number_2,
            m_number_3,
            m_number_4,
            m_number_5,
            m_number_6,
            m_number_7,
            m_number_8,
            m_number_9,
        }; 
        m_number_sprites = number_sprites;

        m_number_images = new List<Image>();
        for( int j=0; j<gameObject.transform.childCount; ++j )
        {
            Image image = transform.GetChild(j).gameObject.GetComponent<Image>();
            if( null != image )
            {
                m_number_images.Add( image );
            }
        }

    }

    List<int> split_number( int number )
    {
        List<int> result = new List<int>();
        int t = (int)(number / 1000);
        result.Add( t );
        number = number % 1000;

        t = (int)(number / 100);
        result.Add( t );
        number = number % 100;

        t = (int)(number / 10);
        result.Add( t );
        number = number % 10;

        result.Add( number );
        return result;
    }

    public void set_score( int score )
    {
        List<int> numbers = split_number( score );
        for( int j=0; j<numbers.Count; ++j )
        {
            m_number_images[j].sprite = m_number_sprites[ numbers[j] ];
        }
    }
}
