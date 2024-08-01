using UnityEngine;
using System.Collections;

namespace SampleGame
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Screen : MonoBehaviour
    {
        CanvasGroup canvasGrooup;

        private void Awake()
        {
            canvasGrooup = GetComponent<CanvasGroup>();
        }

        public IEnumerator In()
        {            
            gameObject.SetActive(true);

            canvasGrooup.alpha = 0;

            while (true)
            {
                if (canvasGrooup.alpha >= 1f)
                {
                    break;
                }

                canvasGrooup.alpha += 0.001f;

                yield return null;
            }
        }

        public IEnumerator Out()
        {
            yield return new WaitForSeconds(1f);

            while (true)
            {
                if (0 >= canvasGrooup.alpha)
                {
                    break;
                }

                canvasGrooup.alpha += -0.001f;

                yield return null;
            }

            gameObject.SetActive(false);
        }

        //  ø¯¡ÿ¿Ã - 
        private void Update()
        {
            
        }
    }
}