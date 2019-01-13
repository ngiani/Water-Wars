using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterWars.Core
{
    public class ShootCommand : CommandObject
    {

        [SerializeField] GameObject beamPrefab;
        [SerializeField] float shootDelayTime;
        [SerializeField] float beamThrust;
        LaserBeamSource[] sources;

        public override void Execute()
        {
            StartCoroutine(ShootBeam());
        }

        // Use this for initialization
        void Start()
        {
            sources = transform.GetComponentsInParent<LaserBeamSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator ShootBeam()
        {
            yield return new WaitForSeconds(shootDelayTime);

            foreach (LaserBeamSource source in sources)
            {
                GameObject beamObj = Instantiate(beamPrefab, source.transform.position, beamPrefab.transform.rotation);
                beamObj.GetComponent<Rigidbody>().AddForce(transform.forward * beamThrust, ForceMode.Impulse);
            }

            onExecutionEnd.Invoke();

            yield return null;
        }
    }
}

