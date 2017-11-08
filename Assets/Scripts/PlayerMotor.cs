using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
	private NavMeshAgent _agent;
	private Transform _target;

	public float RotationSpeed = 5f;

	// Use this for initialization
	void Start ()
	{
		_agent = GetComponent<NavMeshAgent>();
	}

	public void MoveToPoint(Vector3 point)
	{
		_agent.SetDestination(point);
	}

	public void FollowTarget(Interactable newTarget)
	{
		_agent.stoppingDistance = newTarget.radius * .8f;
		_agent.updateRotation = false;
		
		_target = newTarget.InteractionTransform;
	}

	public void StopFollowingTarget()
	{
		_target = null;
		_agent.updateRotation = true;
	}

	private void Update()
	{
		if (_target != null)
		{
			_agent.SetDestination(_target.position);
			FaceTarget();
		}
	}

	void FaceTarget()
	{
		Vector3 direction = (_target.position - transform.position).normalized;
		Quaternion lookRoation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRoation, Time.deltaTime * RotationSpeed);
	}
}
