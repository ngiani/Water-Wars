using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{
    public class ShootingItem : MonoBehaviour
    {
        ItemEventsManager itemEventsManager;
        GameObject _shootingTarget;

        private bool _inRange;

        // Use this for initialization
        void Start()
        {
            itemEventsManager = GetComponent<ItemEventsManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InRange(GameObject target)
        {
            _inRange = true;
            _shootingTarget = target;
        }

        public void OutOfRange()
        {
            _inRange = false;
            _shootingTarget = null;
        }

        public void Shoot()
        {
            if (_inRange && _shootingTarget != null)
            {
                transform.DOLookAt(_shootingTarget.transform.position, 1.0f);
                Debug.Log("Shoot!");
            }
        }
    }
}

