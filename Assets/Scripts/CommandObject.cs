using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CommandObject : MonoBehaviour, ICommand
{
    public abstract void Execute();
    public UnityEvent onExecutionEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
