using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AIStateAgent : MonoBehaviour
{
	[SerializeField] AIPerception enemyPerception;

	AIStateMachine stateMachine = new AIStateMachine();

	private void Start()
	{
		// Add states to state machine
		stateMachine.AddState(nameof(AIAttackState), new AIAttackState(this));
		stateMachine.AddState(nameof(AIDeathState), new AIDeathState(this));
		stateMachine.AddState(nameof(AIIdleState), new AIIdleState(this));
		stateMachine.AddState(nameof(AIPatrolState), new AIPatrolState(this));

		stateMachine.SetState(nameof(AIIdleState));
	}

	private void Update()
	{
		var enemies = enemyPerception.GetGameObjects();
		if (enemies.Length > 0) 
		{
			stateMachine.SetState(nameof(AIAttackState));
		}
		else
		{
			stateMachine.SetState(nameof(AIIdleState));
		}
		stateMachine.Update();
	}
}
