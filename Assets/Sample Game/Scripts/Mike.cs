using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MicrophoneInput : MonoBehaviour
{
    public int minRange = 1;
    public int maxRange = 100;
    public int sampleWindow = 128; // ���� ������ ũ��
    [Range(1, 100)]
    public int scaledVolume; // �ν����Ϳ� ǥ�õ� ������ ����

    private AudioClip micClip;
    private string micName;

    void Start()
    {
        // ����ũ ��ġ�� �˻��ϰ� ù ��° ��ġ�� ����մϴ�.
        if (Microphone.devices.Length > 0)
        {
            micName = Microphone.devices[0];
            micClip = Microphone.Start(micName, true, 10, AudioSettings.outputSampleRate);
        }
        else
        {
            Debug.LogWarning("����ũ ��ġ�� �����ϴ�.");
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
        // ����ũ �Է��� 0.0���� 1.0 ������ ���Դϴ�.
        // �̸� �α� �����ϸ��� ���� minRange�� maxRange ������ ������ ��ȯ�մϴ�.
        float scaledVolume = Mathf.Log10(1 + volume * 9) * maxRange; // 0���� 1 ������ ���� �α� �����Ϸ� ��ȯ
        scaledVolume = Mathf.Clamp(scaledVolume, minRange, maxRange);
        return Mathf.RoundToInt(scaledVolume);
    }
}
