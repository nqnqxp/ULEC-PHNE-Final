using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpatialManager : MonoBehaviour
{
    public AudioSource bgmAudio;     // The audio you want to fade out
    public AudioSource characterAudio;   // The spatial audio that overrides
    public float fadeSpeed = 1.0f;

    private Transform player;
    private float targetOriginalVolume;
    private bool isOverlapping;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        targetOriginalVolume = bgmAudio.volume;
    }

    void Update()
    {
        float distanceToPriority = Vector3.Distance(player.position, characterAudio.transform.position);
        bool inMaxRange = distanceToPriority <= characterAudio.maxDistance;

        if (inMaxRange && !isOverlapping)
        {
            isOverlapping = true;
        }
        else if (!inMaxRange && isOverlapping)
        {
            isOverlapping = false;
        }

        // Smoothly fade target audio based on proximity
        float bgmVolume = isOverlapping ? 0f : targetOriginalVolume;
        bgmAudio.volume = Mathf.MoveTowards(bgmAudio.volume, bgmVolume, fadeSpeed * Time.deltaTime);
    }
}