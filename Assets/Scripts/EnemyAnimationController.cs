using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private NavMeshAgentBehaviour _agent;
    [SerializeField] private Sword _sword;
    [SerializeField] private EnemyAttack _attack;
    private Animator _animator;
    
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!_animator || !_agent)
        {
            return;
        }

        _animator.SetBool("IsIdle", _agent.IsIdle);
        _animator.SetBool("IsRunning", !_agent.IsIdle);
        _animator.SetBool("IsAttacking",_attack.IsAttacking);
    }

    private void AttackStarts()
    {
        _sword.SetColliderActive(true);
    }

    private void AttackEnd()
    {
        _attack.AttackEnd();
    }

}
