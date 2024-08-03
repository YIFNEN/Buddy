using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


namespace SampleGame.Lobby
{
    public class GUIManager : SampleGame.Manager
    {

        // ============================================================
        [ReadOnly] public BackButton backButton;
        [ReadOnly] public HomeButton homeButton;

        // ============================================================
        [ReadOnly] public LobbyViewer lobbyViewer;
        [ReadOnly] public GameStartButton gameStartButton;
        [ReadOnly] public InventoryButton inventoryButton;

        // ============================================================
        [ReadOnly] public InventoryViewer inventoryViewer;
        [ReadOnly] public ItemButton itemButton;

        // ============================================================
        [ReadOnly] public ItemViewer itemViewer;


        private void Awake()
        {
            backButton = gameObject.GetComponentInChildren<BackButton>();
            homeButton = gameObject.GetComponentInChildren<HomeButton>();

            // ============================================================

            lobbyViewer = gameObject.GetComponentInChildren<LobbyViewer>();
            gameStartButton = gameObject.GetComponentInChildren<GameStartButton>();
            inventoryButton = gameObject.GetComponentInChildren<InventoryButton>();

            // ============================================================
            inventoryViewer = gameObject.GetComponentInChildren<InventoryViewer>();
            itemButton = gameObject.GetComponentInChildren<ItemButton>();

            // ============================================================
            itemViewer = gameObject.GetComponentInChildren<ItemViewer>();
        }

        public T GetWidget<T>() where T : UnityEngine.Component
        {
            return gameObject.GetComponentInChildren<T>();
        }
    }
}
