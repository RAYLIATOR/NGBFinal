using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
    public string subtitle;
    Subtitles subtitles;

    void Start()
    {
        subtitles = FindObjectOfType<Subtitles>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            PlaySubtitle();
            Destroy(gameObject);
        }
    }

    void PlaySubtitle()
    {
        subtitles.PlaySubtitle(subtitle);
    }
}
