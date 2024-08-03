using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SampleGame.Lobby
{
    public partial class InputManager
    {

        private void BindItemInputEvents()
        {
            var gui = client.GetManager<GUIManager>();

            //==================================================================
            //  인벤토리 State 추가

            void OnEnter()
            {
                Debug.Log("enter item state");

                var viewer = gui.itemViewer;
                viewer.Show();

                var back = gui.backButton;
                back.onClick = () =>
                {
                    stateMachine.Pop();
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
                Debug.Log("exit item state");

                var viewer = gui.itemViewer;
                viewer.Hide();

                var back = gui.backButton;
                back.Hide();

                var home = gui.homeButton;
                home.Hide();
            }

            var state = new State<States>(States.Item);
            state.onEnter = OnEnter;
            state.onExit = OnExit;

            stateMachine.Add(state);

        }
    }
}
