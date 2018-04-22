using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoSingleton<Sound> {

    AudioSource m_Bg;
    AudioSource m_effect;
    public string ResourceDir = "";

    protected override void Awake()
    {
        base.Awake();
        m_Bg = gameObject.AddComponent<AudioSource>();
        m_Bg.playOnAwake = false;
        m_Bg.loop = false;

        m_effect = gameObject.AddComponent<AudioSource>();
        //m_effect.playOnAwake = false;
        //m_effect.loop = false;
    }

    public void PlayBG(string audioName)
    {
        string oldName;
        if (m_Bg.clip == null)
        {
            oldName = "";
        }
        else {
            oldName = m_Bg.clip.name;
        }

        if (oldName != audioName) {

            string path = ResourceDir + "/" + audioName;

            AudioClip clip = Resources.Load<AudioClip>(path);

            if (clip != null) {
                m_Bg.clip = null;
                m_Bg.Play();
            }
        }
    }

    //播放音效
    public void PlayEffect(string audioName) {

        string path = ResourceDir + "/" + audioName;
        AudioClip clip = Resources.Load<AudioClip>(path);
        m_effect.PlayOneShot(clip);
    }

}
