

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{
    public class Client : MonoBehaviour
    {
        [SerializeField] private Screen blackScreen;
        [SerializeField] private Screen loadingScreen;

        [ReadOnly][SerializeField] private List<Manager> managers = new List<Manager>();
        [ReadOnly][SerializeField] private bool isStartup;


        private void Update()
        {
            if (isStartup == false) { return; }

            foreach (var manager in managers)
            {
                manager.OnUpdate();
            }
        }


        public T GetManager<T>() where T : Manager
        {
            var item = managers.Find(e=>e.GetType() == typeof(T)); 
            if (item != null)
            {
                return item as T;
            }

            throw new System.Exception();
        }

        public List<Manager> GetManagers()
        {
            return managers;
        }

        public void Startup()
        {
            isStartup = true;
        }
        public void Add(Manager manager)
        {
            managers.Add(manager);
        }
        protected void ChangeScene(string sceneName)
        {
            IEnumerator Process()
            {
                yield return StartCoroutine(BlackScreenIn());

                var ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

                while(true)
                {
                    yield return null;

                    if (ao.isDone)
                    {
                        break;
                    }
                }
            }

            StartCoroutine(Process());
        }

        protected IEnumerator BlackScreenOut()
        {
            yield return StartCoroutine(blackScreen.Out());        
        }
        protected IEnumerator BlackScreenIn()
        {
            yield return StartCoroutine(blackScreen.In());
        }


        public IEnumerator LoadingScreenOut()
        {
            yield return StartCoroutine(loadingScreen.Out());
        }
    }
}