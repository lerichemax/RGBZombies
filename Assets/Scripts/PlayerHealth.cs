using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private float _invulnerabilityTime = 0.25f;

    private float _counter;

    private bool _canTakeDamage;
    protected override void Awake()
    {
        base.Awake();
        _canTakeDamage = true;
    }

    void Update()
    {
        if (!_canTakeDamage)
        {
            _counter += Time.deltaTime;
            if (_counter >= _invulnerabilityTime)
            {
                _counter = 0;
                _canTakeDamage = true;
            }
        }
    }

    protected override void Die()
    {
        if (_gameOverMenu)
        {
            _gameOverMenu.GameOver("Game Over");
        }
        Time.timeScale = 0;
    }

    public void GainHealth(int amount)
    {
        _health += amount;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public override void TakeDamage(float amount)
    {
        if (_canTakeDamage)
        {
            base.TakeDamage(amount);
            _canTakeDamage = false;
        }
        
    }
}
