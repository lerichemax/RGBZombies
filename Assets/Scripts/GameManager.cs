using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private bool _isPaused;
    public bool IsPaused
    {
        get { return _isPaused; }
        set { _isPaused = value; }
    }

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1;

        if (_pauseMenu)
        {
            _pauseMenu.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!_isPaused)
            {
                Time.timeScale = 0;
                _isPaused = true;
                if (_pauseMenu)
                {
                    _pauseMenu.SetActive(true);
                }
            }
            else
            {
                _isPaused = false;
                Time.timeScale = 1;
                if (_pauseMenu)
                {
                    _pauseMenu.SetActive(false);
                }
            }
            
        }
    }
};
