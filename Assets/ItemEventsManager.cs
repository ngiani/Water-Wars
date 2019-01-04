using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WaterWars.Core
{

    [System.Serializable]
    public class ObjectEvent : UnityEvent<GameObject>
    {
        
    }

    /// <summary>
    /// Handles events related to item.
    /// It enables communication between item components, without the need to know each others.
    /// </summary>
    public class ItemEventsManager : MonoBehaviour
    {

        public ObjectEvent onEnemyApproach;
        //public ObjectEvent onEnemy
        public UnityEvent onEnemyAway;
        public UnityEvent onStopMoving;

        //public UnityEvent onStartShooting;

        // Use this for initialization
        void Start()
        {
            ShootingItem shooter = GetComponent<ShootingItem>();

            if (shooter != null)
            {
                onEnemyApproach.AddListener(shooter.InRange);
                onEnemyAway.AddListener(shooter.OutOfRange);
                onStopMoving.AddListener(shooter.Shoot);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

