using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class MobileTouch : MonoBehaviour
{
    [Header("Debug Test")]
    [SerializeField]
    private TextMeshProUGUI textTouch;

    [Header("Camera Zoom Mode")]
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float zoomSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnMultiTouch();

    }
    private void OnMultiTouch()
    {
        if (Input.touchCount > 0)
        {
            textTouch.text = "";

            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);//i��° ��ġ ����,ID��,��ġ,����
                int index = touch.fingerId;
                Vector2 position = touch.position;
                TouchPhase phase = touch.phase;

                if (phase == TouchPhase.Began)//���⼭���� �и� ���?
                { }
                else if (phase == TouchPhase.Moved)
                { }
                else if (phase == TouchPhase.Stationary)
                { }
                else if (phase == TouchPhase.Ended)
                { }
                else if (phase == TouchPhase.Canceled)
                { }
                textTouch.text += "Index :" + index + ",Status : " + phase + ", Position(" + position + ")\n";
            }
        }
    }
    private void OncameraZoommode()
    { }

     private void OnSingleTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                textTouch.text = "Touch Begin";
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                textTouch.text = "Touch End";
            }
        }
    }
}