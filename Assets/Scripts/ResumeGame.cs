using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour
{
    private Button _btn;
    private GameManager _manager;
    void Awake()
    {
        _btn = GetComponent<Button>();
        if (_btn)
        {
            _btn.onClick.AddListener(Resume);
        }
        _manager = FindObjectOfType<GameManager>();
    }

    void Resume()
    {
        Time.timeScale = 1;
        _manager.IsPaused = false;

        transform.parent.gameObject.SetActive(false);
    }
}
