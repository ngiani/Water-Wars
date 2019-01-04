using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{
    public class MovableItem : MonoBehaviour
    {
        [SerializeField] float speed;
        ItemEventsManager itemEventsManager;
        Vector3 currentTarget;
        bool moving;

        // Use this for initialization
        void Start()
        {
            itemEventsManager = GetComponent<ItemEventsManager>();
        }

        // Update is called once per frame
        void Update()
        {

            if (moving)
            {
                if (Vector3.Distance(transform.position, currentTarget) >= 0.05f)
                {
                    transform.Translate((currentTarget - transform.position).normalized * speed * Time.deltaTime, Space.World);
                }
                else
                {
                    moving = false;
                    itemEventsManager.onStopMoving.Invoke();
                }
            }
        }

        public void MoveTo(Vector3 target)
        {
            currentTarget = new Vector3(target.x, transform.position.y, target.z);
            transform.DOLookAt(currentTarget, 0.1f);
            moving = true;
        }

        public void Stop()
        {
            moving = false;
            itemEventsManager.onStopMoving.Invoke();
        }
    }
}

