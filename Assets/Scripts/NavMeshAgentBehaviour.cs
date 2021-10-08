using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentBehaviour : MonoBehaviour
{
    [SerializeField] private GroupIntelligence _group;

    private Transform _target;
    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    private NavMeshAgent _agent;
    private Rigidbody _rb;

    public bool IsIdle
    {
        get { return _agent.velocity.magnitude == 0; }
    }

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_target && _agent)
        {
            _agent.SetDestination(_target.position);
        }
    }

    public void CancelForceAfterTime(float time)
    {
        Invoke("CancelForce", time);
    }

    private void CancelForce()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Target == null && other.tag == "Player")
        {
            _target = other.transform.root;
            if (_group)
            {
                _group.SpotTarget(this);
            }
            
        }
    }

    public void Stop()
    {
        _agent.velocity = Vector3.zero;
        _agent.isStopped = true;
    }

    public void StartAgent()
    {
        _agent.isStopped = false;

    }
}
