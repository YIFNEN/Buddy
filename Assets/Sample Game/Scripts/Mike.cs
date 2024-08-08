using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MicrophoneInput : MonoBehaviour
{
    public int minRange = 1;
    public int maxRange = 100;
    public int sampleWindow = 128; // 샘플 윈도우 크기
    [Range(1, 100)]
    public int scaledVolume; // 인스펙터에 표시될 스케일 볼륨

    private AudioClip micClip;
    private string micName;

    void Start()
    {
        // 마이크 장치를 검색하고 첫 번째 장치를 사용합니다.
        if (Microphone.devices.Length > 0)
        {
            micName = Microphone.devices[0];
            micClip = Microphone.Start(micName, true, 10, AudioSettings.outputSampleRate);
        }
        else
        {
            Debug.LogWarning("마이크 장치가 없습니다.");
        }
    }

    void Update()
    {
        if (Microphone.IsRecording(micName))
        {
            float volume = GetMaxVolume();
            scaledVolume = ScaleVolume(volume);
        }
    }

    float GetMaxVolume()
    {
        float maxVolume = 0f;
        float[] samples = new float[sampleWindow];
        int micPosition = Microphone.GetPosition(micName) - sampleWindow + 1;
        if (micPosition < 0) return 0;

        micClip.GetData(samples, micPosition);

        for (int i = 0; i < sampleWindow; i++)
        {
            float currentSample = Mathf.Abs(samples[i]);
            if (maxVolume < currentSample)
            {
                maxVolume = currentSample;
            }
        }

        return maxVolume;
    }

    int ScaleVolume(float volume)
    {
        // 마이크 입력은 0.0에서 1.0 사이의 값입니다.
        // 이를 로그 스케일링을 통해 minRange와 maxRange 사이의 값으로 변환합니다.
        float scaledVolume = Mathf.Log10(1 + volume * 9) * maxRange; // 0에서 1 사이의 값을 로그 스케일로 변환
        scaledVolume = Mathf.Clamp(scaledVolume, minRange, maxRange);
        return Mathf.RoundToInt(scaledVolume);
    }
}
