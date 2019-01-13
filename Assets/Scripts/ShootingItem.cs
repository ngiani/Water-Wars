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
        private bool _canShoot;

        public bool CanShoot
        {
            get { return _canShoot; }
            set { _canShoot = value; }
        }

        [SerializeField] ShootCommand shootCommandPrefab;
        [SerializeField] float rotationToTargetSpeed;

        // Use this for initialization
        void Start()
        {
            itemEventsManager = GetComponent<ItemEventsManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_inRange && _canShoot && _shootingTarget != null)
            {
                var step = rotationToTargetSpeed * Time.deltaTime;
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_shootingTarget.transform.position - transform.position), step);

                ShootCommand shootCommand = Instantiate<ShootCommand>(shootCommandPrefab, transform);
                shootCommand.Execute();
                shootCommand.onExecutionEnd.AddListener(() => { Destroy(shootCommand.gameObject);});
            }
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
    }
}

