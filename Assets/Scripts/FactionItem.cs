using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{
    public enum Faction{FACTION_1, FACTION_2}

    public class FactionItem : MonoBehaviour
    {
        [SerializeField] Faction _owner;
        ItemEventsManager itemEventsManager;

        public Faction Owner
        {
            get { return _owner; }
        }

        // Use this for initialization
        void Start()
        {
            itemEventsManager = GetComponent<ItemEventsManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            FactionItem collidingItem = other.gameObject.GetComponent<FactionItem>();

            //Enemy is approaching if i am colliding with an item i am not an owner of
            if (collidingItem != null && collidingItem.Owner != _owner)
            {
                itemEventsManager.onEnemyApproach.Invoke(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            FactionItem collidingItem = other.gameObject.GetComponent<FactionItem>();

            //Enemy is going away if i am colliding with an item i am not an owner of
            if (collidingItem != null && collidingItem.Owner != _owner)
            {
                itemEventsManager.onEnemyAway.Invoke();
            }
        }
    }
}

