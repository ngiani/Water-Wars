using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{
    /// <summary>
    /// Class representing an item who builds other items
    /// </summary>
    public class BuildingItem : MonoBehaviour
    {
        [SerializeField] BuildCommand buildCommandPrefab;
        [SerializeField] int buildQueueCapacity;
        Queue<BuildCommand> commandsQueue;

	    // Use this for initialization
	    void Start ()
        {
            commandsQueue = new Queue<BuildCommand>();

        }
	
	    // Update is called once per frame
	    void Update ()
        {

	    }

        public void Build()
        {
            if (commandsQueue.Count < buildQueueCapacity)
            {
                BuildCommand newCommand = Instantiate<BuildCommand>(buildCommandPrefab, transform);
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).tag == "SpawnPoint")
                    {
                        newCommand.SpawnPoint = transform.GetChild(i).position;
                        break;
                    }
                }

                newCommand.onExecutionEnd.AddListener(BuildNext);

                Debug.Log("Put in build queue");

                commandsQueue.Enqueue(newCommand);

                if (commandsQueue.Count == 1)
                {
                    commandsQueue.Peek().Execute();
                }
            }
            
        }

        void BuildNext()
        {
            BuildCommand currentCommand = commandsQueue.Dequeue();
            Destroy(currentCommand.gameObject);

            if (commandsQueue.Count > 0)
            {
                commandsQueue.Peek().Execute();
            }

        }



    }
}
