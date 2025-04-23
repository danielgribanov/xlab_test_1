using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public bool isAffect = false;

            private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Stone collision with: " + collision.gameObject.name); // Лог
            
            if (collision.gameObject.TryGetComponent(out Stone otherStone))
            {
                if (!isAffect) // Если этот камень ещё не был задет
                {
                    Debug.Log("Stones collided! Triggering Game Over."); // Лог
                    GameEvents.CollisionStonesInvoke(collision);
                }
            }
        }
    }
}