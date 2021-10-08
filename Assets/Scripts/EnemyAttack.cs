using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Sword _sword;
    [SerializeField] private NavMeshAgentBehaviour _agent;
    [SerializeField] private Transform _rootTransform;

    private Transform _target;

    private float _attackInterval = 1.35f;
    private float _rotationSpeed = 50f;

    private bool _isAttacking;
    private bool _isInterpingToEnemy;

    public bool IsAttacking
    {
        get { return _isAttacking; }
        set { _isAttacking = value; }
    }

    void Update()
    {
        if (_isInterpingToEnemy && _target && _rootTransform)
        {
            Vector3 forward = _target.position - transform.position;
            forward.Normalize();
            Quaternion targetRot = Quaternion.LookRotation(forward, Vector3.up);
            _rootTransform.rotation = Quaternion.Slerp(_rootTransform.rotation, targetRot, Time.deltaTime * _rotationSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.transform.root;
            Attack();
            if (_agent)
            {
                _agent.Stop();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isAttacking = false;
            _isInterpingToEnemy = false;
            _sword.SetColliderActive(false);
            _target = null;
            if (_agent)
            {
                _agent.StartAgent();
            }
        }
    }

    private void Attack()
    {
        _isAttacking = true;
    }

    public void AttackEnd()
    {
        _isAttacking = false;
        _sword.SetColliderActive(false);
        if (_target)
        {
            _isInterpingToEnemy = true;
            Invoke("Attack", _attackInterval);
        }
        else
        {
            _agent.StartAgent();
        }
    }
}
