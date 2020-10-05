// SceneSwitcher.cs --- 
// Filename: SceneSwitcher.cs
// Created: Mon Oct  5 15:49:50 2020 (+0800)
// 
// 
// Copyright Weiguo Mao All Rights Reserved.
// 
// 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Image m_blackimage = null;
    public string m_scene_name = "";

    public IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync( m_scene_name );
        asyncLoad.allowSceneActivation = false;

        float tick = 0;
        int count = 0;

        m_blackimage.gameObject.SetActive(true);
        while(asyncLoad.progress < 0.9f)
        {
            update_black_image( ref tick, ref count );
            yield return null;
        }

        while( count < 10 )
        {
            update_black_image( ref tick, ref count );
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
    }

    void update_black_image( ref float tick, ref int count )
    {
        tick += Time.deltaTime;
        if( tick > 1/10.0f )
        {
            m_blackimage.color = new Color(m_blackimage.color.r, m_blackimage.color.g, m_blackimage.color.b, count / 10.0f );
            tick = 0;
            count ++;
        }
    }
    
}
