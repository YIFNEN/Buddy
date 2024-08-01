

using SampleGame.InGame;
using UnityEngine;
using System.Collections;

namespace SampleGame.Lobby
{
    public class Client : SampleGame.Client
    {
        InputManager inputManager;
        GUIManager guiManager;

        private void Awake()
        {
            inputManager = GameObject.FindObjectOfType<InputManager>();
            inputManager.SetClient(this);
            inputManager.onChangeScene = ChangeScene;

            guiManager = GameObject.FindObjectOfType<GUIManager>();
            guiManager.SetClient(this);
        }

        // Start is called before the first frame update
        IEnumerator Start()
        {
            //  ����ũ�� ���̵� �ƿ�
            yield return StartCoroutine(base.BlackScreenOut());
            //  ���ۤ� ����..~

            //  ~~~~

            var managers = GetManagers();
            foreach (var manager in managers)
            {
                manager.Startup();
            }
            //  �ε� ��ũ�� �ƿ�
            yield return StartCoroutine(base.LoadingScreenOut());
        }
    }
}