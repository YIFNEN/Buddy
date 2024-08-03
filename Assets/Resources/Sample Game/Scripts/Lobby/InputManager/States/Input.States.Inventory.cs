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
            //  인벤토리 State 추가

            void OnEnter()
            {
                Debug.Log("enter inventory state");
                
                var viewer = gui.inventoryViewer;
                viewer.Show();

                var back = gui.backButton;
                back.onClick = () => 
                {
                    //  확인되지 않은 장비가 있는지 검사

                    //  팝업 노출

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
            //  아이템 클릭;
            gui.itemButton.onClick = () =>
            {
                stateMachine.Push(States.Item);
            };

        }
    }
}
