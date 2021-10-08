using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float _timeToSwitchLow;
    [SerializeField] private float _timeToSwitchHigh;

    [SerializeField] private GameObject[] _shields;

    private int _shieldIndex;
    private float _timer;
    private float _timeToSwitch;

    void Awake()
    {
        if (_shields.Length > 0)
        {
            foreach (GameObject shield in _shields)
            {
                shield.SetActive(false);
            }
        }
        
        _shieldIndex = Random.Range(0, _shields.Length);

        _shields[_shieldIndex].SetActive(true);

        if (_timeToSwitchLow > _timeToSwitchHigh)
        {
            float temp = _timeToSwitchLow;
            _timeToSwitchLow = _timeToSwitchHigh;
            _timeToSwitchHigh = temp;
        }

        _timeToSwitch = Random.Range(_timeToSwitchLow, _timeToSwitchHigh);
    }

    void Update()
    {
        if (_timer < _timeToSwitch)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            ChangeShield();
            _timer = 0;
        }
    }

    void ChangeShield()
    {
        _shields[_shieldIndex].SetActive(false);

        _shieldIndex++;
        if (_shieldIndex >= _shields.Length)
        {
            _shieldIndex = 0;
        }

        _shields[_shieldIndex].SetActive(true);

        _timeToSwitch = Random.Range(_timeToSwitchLow, _timeToSwitchHigh);
    }
}
