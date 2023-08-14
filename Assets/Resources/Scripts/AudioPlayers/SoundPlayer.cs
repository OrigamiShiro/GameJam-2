using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _clips = new List<AudioClip>();
        private int _currentClipIndex = 0;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            if (_currentClipIndex >= _clips.Count)
                _currentClipIndex = 0;

            _audioSource.clip = _clips[_currentClipIndex];
            _audioSource.Play();
            _currentClipIndex++;
        }
    }
}