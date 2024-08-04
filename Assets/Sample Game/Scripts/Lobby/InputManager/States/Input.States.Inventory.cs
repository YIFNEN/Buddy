using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;


namespace SampleGame.Lobby
{
    public partial class InputManager 
    {

        private void BindInventoryInputEvents()
        {
            var gui = client.GetManager<GUIManager>();

            //==================================================================
            //  �κ��丮 State �߰�

            void OnEnter()
            {
                Debug.Log("enter inventory state");
                
                var viewer = gui.inventoryViewer;
                viewer.Show();

                var back = gui.backButton;
                back.onClick = () => 
                {
                    //  Ȯ�ε��� ���� ��� �ִ��� �˻�

                    //  �˾� ����

                    bool canPopable = true;
                    if (canPopable)
                    {
                        stateMachine.Pop();
                    }
                };
                back.Show();

                var home = gui.homeButton;
                home.onClick = () =>
                {
                    stateMachine.PopAll();
                };
                home.Show();
            }

            void OnExit()
            {
                Debug.Log("exit inventory state");

                var viewer = gui.inventoryViewer;
                viewer.Hide();

                var back = gui.backButton;
                back.Hide();

                var home = gui.homeButton;
                home.Hide();
            }

            var state = new State<States>(States.Inventory);
            state.onEnter = OnEnter;
            state.onExit = OnExit;

            stateMachine.Add(state);

            //==================================================================
            //  ������ Ŭ��;
            gui.itemButton.onClick = () =>
            {
                stateMachine.Push(States.Item);
            };

        }
    }
}
