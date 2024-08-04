

using UnityEngine;

namespace SampleGame
{
    public class Manager : MonoBehaviour
    {
        protected Client client;

        public void SetClient(Client client)
        {
            this.client = client;
            this.client.Add(this);
        }

        public virtual void Preparing()
        {

        }

        public virtual void Startup()
        {

        }

        public virtual void OnUpdate()
        {

        }
    }
}