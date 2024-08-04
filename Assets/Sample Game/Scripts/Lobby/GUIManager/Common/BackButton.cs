using UnityEngine;

namespace SampleGame.Lobby
{
    public class BackButton : SampleGame.Button
    {
        protected override void Start()
        {
            base.Start();
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}