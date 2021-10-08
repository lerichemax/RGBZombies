using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupIntelligence : MonoBehaviour
{
    [SerializeField] private NavMeshAgentBehaviour[] _group;
    [SerializeField] private GameObject _keyToSpawn;

    private bool _targetSpotted;
    public bool TargetSpotted
    {
        get { return _targetSpotted; }
    }

    private void Awake()
    {
        if (_keyToSpawn)
        {
            _keyToSpawn.SetActive(false);
        }
    }
    private void Update()
    {
        if (IsGroupDead())
        {
            if (_keyToSpawn)
            {
                _keyToSpawn.SetActive(true);
            }
            Destroy(gameObject);
        }
    }

    public void SpotTarget(NavMeshAgentBehaviour spotter)
    {
        foreach (NavMeshAgentBehaviour enemy in _group)
        {
            enemy.Target = spotter.Target;
        }
    }

    private bool IsGroupDead()
    {
        for (int i = 0; i < _group.Length; i++)
        {
            if (_group[i] != null)
            {
                return false;
            }
        }

        return true;
    }
}
