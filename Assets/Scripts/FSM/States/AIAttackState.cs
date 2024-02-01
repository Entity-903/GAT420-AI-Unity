using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIState
{
	public AIAttackState(AIStateAgent agent) : base(agent)
	{ 
		//
	}
	public override void OnEnter()
	{
		Debug.Log("Attack Enter");
	}

	public override void OnExit()
	{
		Debug.Log("Attack Exit");
	}

	public override void OnUpdate()
	{
		Debug.Log("Attack Update");
	}
}
