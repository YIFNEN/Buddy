

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SampleGame
{
    [System.Serializable]
    public class StateMachine<T> where T : struct
    {
        [ReadOnly] [SerializeField] private List<string> debugForStatck = new List<string>();
        [ReadOnly][SerializeField] private string debugForCurrentState;

        private List<State<T>> states = new List<State<T>>();
        private Stack<State<T>> stack = new Stack<State<T>>();

        private State<T> _currentState;
        private State<T> CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                debugForCurrentState = value.ID.ToString();
            }
        }


        public void Push(T id)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }

            State<T> next = states.Find(e => Equals(e.ID, id));
            next.OnEnter();

            CurrentState = next;

            stack.Push(next);

            debugForStatck.Add(id.ToString());    
        }

        public void Pop()
        {
            var state = stack.Pop();
            state.OnExit();

            if (stack.Count > 0)
            {
                var prev = stack.Peek();
                if (prev != null)
                {
                    CurrentState = prev;
                    CurrentState.OnEnter();
                }
            }   

            debugForStatck.RemoveAt(debugForStatck.Count - 1);
        }

        public void PopAll()
        {
            var state = stack.Pop();
            state.OnExit();

            stack.Clear();

            debugForStatck.Clear(); 
        }

        public void Change(T id)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }

            State<T> next = states.Find(e => Equals(e.ID, id));
            next.OnEnter();

            CurrentState = next;
        }

        public void Add(State<T> state)
        {
            states.Add(state);
        }

        public void Remove(State<T> state)
        {
            states.Remove(state);
        }
    }
}