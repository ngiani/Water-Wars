using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace WaterWars.Core
{
    class BuildCommand : MonoBehaviour, ICommand
    {
        public UnityEvent onExecutionEnd;

        [SerializeField] protected float _buildingTime;
        [SerializeField] protected string _prefabPath;
        private float _startBuildTime;
        private Vector3 _spawnPoint;

        public Vector3 SpawnPoint
        {
            set { _spawnPoint = value; }
        }

        public void Execute()
        {
            StartCoroutine(WaitToSpawn());
        }

        private IEnumerator WaitToSpawn()
        {
            Debug.Log("Starting to build");

            _startBuildTime = Time.time;

            while (Time.time - _startBuildTime < _buildingTime)
            {
                Debug.Log("Complete percentage : " + ((Time.time - _startBuildTime) * 100 ) / _buildingTime + " %");
                yield return null;
            }

            Debug.Log("Build completed!");

            Instantiate(Resources.Load(_prefabPath), _spawnPoint, Quaternion.identity);

            onExecutionEnd.Invoke();

            yield return null;
        }
    }
}