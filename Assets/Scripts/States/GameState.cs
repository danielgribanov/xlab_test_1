using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public abstract class GameState : MonoBehaviour
    {
        public List<GameObject> views;

        public virtual void Enter()
        {
            gameObject.SetActive(true);
        }

        public void Exit()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            foreach (var items in views)
            {
                items.SetActive(true);

            }
        }

                private void OnDisable()
        {
            foreach (var items in views)
            {
                items.SetActive(false);
                
            }
        }
    }
}