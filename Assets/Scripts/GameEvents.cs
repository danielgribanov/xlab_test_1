using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public static class GameEvents
    {
        public static System.Action onCollisionStone;
        public static System.Action onStickHit;

        public static void CollisionStonesInvoke(Collision collision)
        {
            Debug.Log("Invoking onCollisionStone"); // Лог
            onCollisionStone?.Invoke();
        }

        public static void StickHit()
        {
            Debug.Log("Invoking onStickHit"); // Лог
            onStickHit?.Invoke();
        }
    }
}
