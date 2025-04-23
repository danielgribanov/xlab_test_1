using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
    {
    public class LevelController : MonoBehaviour
        {
        public SpawnerStone spawner;
        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;
        private float m_delay = 0.5f;
        public int score = 0;
        public int highscore = 0;

        private float m_lastSpawnedTime = 0;
        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnStickHit()
        {
            score++;
            highscore = Mathf.Max(highscore, score);
            
            Debug.Log($"score: {score} - highscore: {highscore}");
        }

        private void OnEnable()
        {
            GameEvents.onCollisionStone += GameOver;
            GameEvents.onStickHit += OnStickHit;
        }

        private void OnDisable()
        {
            GameEvents.onCollisionStone -= GameOver;
            GameEvents.onStickHit -= OnStickHit;
        }

        private void GameOver()
        {
            Debug.Log("Ты проиграл. Увы.");
            enabled = false;
        }

        private void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }

            private void Update()
            {
                if (Time.time >= m_lastSpawnedTime + m_delay)
                {
                    spawner.Spawn();
                    m_lastSpawnedTime = Time.time;

                    RefreshDelay();
                }
            }
        }
    }
