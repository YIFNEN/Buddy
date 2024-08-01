using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SampleGame.Lobby
{
    public partial class InputManager 
    {

        private void BindLobbyInputEvents()
        {
            var gui = client.GetManager<GUIManager>();

            //==================================================================
            //  게임 시작 버튼 클릭 이벤트 처리


            //==================================================================
            //  인벤토리 버튼 클릭 이벤트 처리

            void OnEnter()
            {
                Debug.Log("enter lobby state");
               //// var viewer = gui.inventoryViewer;
                //viewer.Show();
            }

            var state = new State<States>(States.Lobby);
            state.onEnter = OnEnter;

            stateMachine.Add(state);


            //==================================================================
            //  인벤토리 버튼 클릭 이벤트 처리

            gui.inventoryButton.onClick = () =>
            {
                stateMachine.Push(States.Inventory);

                /*var viewer = stateStack.Pop() as SampleGame.Viewer;
                viewer.Hide();*/


                //stateStack.Push(viewer);
            };

            //==================================================================
            //  게임 시작 버튼 클릭 이벤트 처리
            gui.gameStartButton.onClick = () =>
            {
                onChangeScene("InGame");

                //
                //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            };
        }

    }
}
