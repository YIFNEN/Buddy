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
            //  �κ��丮 ��ư Ŭ�� �̺�Ʈ ó��

            gui.inventoryButton.onClick = () =>
            {
                stateMachine.Push(States.Inventory);

                /*var viewer = stateStack.Pop() as SampleGame.Viewer;
                viewer.Hide();*/


                //stateStack.Push(viewer);
            };

            //==================================================================
            //  ���� ���� ��ư Ŭ�� �̺�Ʈ ó��
            gui.gameStartButton.onClick = () =>
            {
                onChangeScene("InGame");

                //
                //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            };
        }

    }
}
