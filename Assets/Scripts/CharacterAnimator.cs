using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
	private NavMeshAgent _agent;
	private Animator _animator;
	
	private const float LocomotionAnimationSmoothTime = .1f;
	
	// Use this for initialization
	void Start ()
	{
		_agent = GetComponent<NavMeshAgent>();
		_animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float speedPercent = _agent.velocity.magnitude /  _agent.speed;
		_animator.SetFloat("speedPercent", speedPercent, LocomotionAnimationSmoothTime, Time.deltaTime);
	}
}
