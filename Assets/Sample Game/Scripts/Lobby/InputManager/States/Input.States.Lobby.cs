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
            //  ���� ���� ��ư Ŭ�� �̺�Ʈ ó��


            //==================================================================
            //  �κ��丮 ��ư Ŭ�� �̺�Ʈ ó��

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
            //  ���� ���� ��ư Ŭ�� �̺�Ʈ ó��
            gui.gameStartButton.onClick = () =>
            {
                onChangeScene("SampleScene");

                //
                //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            };

            //==================================================================
            //  �κ��丮 ��ư Ŭ�� �̺�Ʈ ó��

        }

    }
}
