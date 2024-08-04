using UnityEngine;

namespace SampleGame
{
    public class Button : MonoBehaviour
    {
        //public GameObject viewer;

        public System.Action onClick;

        protected virtual void Start()
        {
            var button = gameObject.GetComponent<UnityEngine.UI.Button>();
            button.onClick.AddListener(OnButtonClicked);
        }

        //  함수 오버로딩

        private void OnButtonClicked()
        {
            onClick();
        }
    }
}