using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class SpawnerStone : MonoBehaviour
    {
        public GameObject[] prefab;

        public void Spawm()
        {
            Debug.Log("Try spawn!");

            var prefab = GetRandomPrefab();
            
            if (prefab == null)
            {
                Debug.LogError("Spawner - prefab == null");
                return;
            } 

            Instantiate(prefab, transform.position, Quaternion.identity);

        }

        private GameObject GetRandomPrefab()
        {
            if (prefab.Length == 0)
            {
                Debug.LogError("Spawner - prefabs is empty"); 
                return null;
            }

            int index = Random.Range(0, prefab.Length);
            return prefab[index];
        }


    }
}
