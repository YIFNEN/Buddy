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
            //  블랙스크린 페이드 아웃
            yield return StartCoroutine(base.BlackScreenOut());

            //  플레이어 캐릭터에 대한 정보를 셋

            //  인게임 스테이지 정보?


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

            //  로딩 스크린 아웃
            yield return StartCoroutine(base.LoadingScreenOut());
        }
    }

}