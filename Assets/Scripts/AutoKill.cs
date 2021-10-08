using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    [SerializeField] private float _delay;

    private float _timer;

    void Awake()
    {
        _timer = _delay;
    }


    void Update()
    {
        if (_timer >= 0 )
        {
            _timer -= Time.deltaTime;
        }

        if (_timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
