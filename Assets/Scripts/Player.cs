using System.Collections;
using System.Collections.Generic;
// using UnityEditor;
// using UnityEditor.Experimental.GraphView;
 using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform stick;
        public Transform helper;
        private Vector3 m_lastPosition;
        private bool m_isDown = false;
        public float range = 40f;
        public float speed = 500f;
        public float power = 20f;

        private void Start()
        {
            // Инициализация последней позиции
            m_lastPosition = helper.position;
            
            // Находим компонент Stick и подписываемся на событие
            Stick stickComponent = stick.GetComponent<Stick>();
            if (stickComponent != null)
            {
                stickComponent.onCollision.AddListener(OnCollisionStick);
            }
            else
            {
                Debug.LogError("Stick component not found!", this);
            }
        }

        public void SetDown(bool value)
        {
            m_isDown = value;
        }

        private void Update()
        {
            // Сохраняем предыдущую позицию перед обновлением
            m_lastPosition = helper.position;

            // Поворачиваем палку
            Quaternion rot = stick.localRotation;
            Quaternion toRot = Quaternion.Euler(0, 0, m_isDown ? -range : range);
            rot = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);
            stick.localRotation = rot;
        }

        public void OnCollisionStick(Collider collider)
        {
            Debug.Log("Stick collided with: " + collider.name); // Лог для проверки
            
            if (collider.TryGetComponent(out Rigidbody body))
            {
                Vector3 dir = (helper.position - m_lastPosition).normalized;
                body.AddForce(dir * power, ForceMode.Impulse);

                if (collider.TryGetComponent(out Stone stone) && !stone.isAffect)
                {
                    Debug.Log("Stone hit! Triggering StickHit event."); // Лог
                    stone.isAffect = true;
                    GameEvents.StickHit(); // Должен вызывать OnStickHit в LevelController
                }
            }
        }
    }
}