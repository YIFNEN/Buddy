using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SampleGame.Lobby
{
    public partial class InputManager : SampleGame.Manager
    {
        public enum States
        {
            Lobby,

            Inventory,

            Item,
        }


        // ���� ����(������)�� stack�� ����
        Stack stateStack = new Stack();

        [ReadOnly][SerializeField] private StateMachine<States> stateMachine;

        public System.Action<string> onChangeScene;

        private void Awake()
        {
            stateMachine = new StateMachine<States>();
        }

        private void Start()
        {
            //gui = client.GetManager<GUIManager>();

            BindLobbyInputEvents();
            BindInventoryInputEvents();
            BindItemInputEvents();

            //stateStack.Push(gui.lobbyViewer);
        }

        public override void Startup()
        {
            stateMachine.Change(States.Lobby);
        }
    }
}
