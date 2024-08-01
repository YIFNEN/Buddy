using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame.InGame
{
    public class Client : SampleGame.Client
    {
        InputManager inputManager;
        GUIManager guiManager;
        StageManager stageManager;

        private void Awake()
        {
            inputManager = GameObject.FindObjectOfType<InputManager>();
            inputManager.SetClient(this);
            guiManager = GameObject.FindObjectOfType<GUIManager>();
            guiManager.SetClient(this);
            stageManager = GameObject.FindObjectOfType<StageManager>();
            stageManager.SetClient(this);


        }
        // Start is called before the first frame update
        IEnumerator Start()
        {
            //  ����ũ�� ���̵� �ƿ�
            yield return StartCoroutine(base.BlackScreenOut());

            //  �÷��̾� ĳ���Ϳ� ���� ������ ��

            //  �ΰ��� �������� ����?


            {
                var managers = GetManagers();
                foreach (var manager in managers)
                {
                    manager.Preparing();
                }
            }

            {
                var managers = GetManagers();
                foreach (var manager in managers)
                {
                    manager.Startup();
                }
            }

            this.Startup();

            //  �ε� ��ũ�� �ƿ�
            yield return StartCoroutine(base.LoadingScreenOut());
        }
    }

}