using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{

    public static float MicLoudness;
    private string _device;


    void StartMic()
    {
        if (_device == null) _device = Microphone.devices[0];
        _clipRecord = Microphone.Start(_device, true, 999, 44100);
    }
    void StopMicrophone()
    {
        Microphone.End(_device);
    }
    AudioClip _clipRecord = new AudioClip();
    int _sampleWindow = 128;


    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null is first microphone
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);
        // peak 128
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }



    void Update()
    {
        //if (MicrophoneInput.MicLoudness > 0.5)
        //{
        //    print("mic");
        //}
        MicLoudness = LevelMax();
    }

    bool _isInitialized;
    void OnEnable()
    {
        StartMic();
        _isInitialized = true;
    }

    void OnDisable()
    {
        StopMicrophone();
    }

    void OnDestroy()
    {
        StopMicrophone();
    }

    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (!_isInitialized)
            {
                StartMic();
                _isInitialized = true;
            }
        }
        if (!focus)
        {
            StopMicrophone();
            _isInitialized = false;

        }
    }
}


