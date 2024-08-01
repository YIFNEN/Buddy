

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
            //  블랙스크린 페이드 아웃
            yield return StartCoroutine(base.BlackScreenOut());
            //  구글ㄹ 인증..~

            //  ~~~~

            var managers = GetManagers();
            foreach (var manager in managers)
            {
                manager.Startup();
            }
            //  로딩 스크린 아웃
            yield return StartCoroutine(base.LoadingScreenOut());
        }
    }
}