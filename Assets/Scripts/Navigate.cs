using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigate : MonoBehaviour
{
    [SerializeField] private GameObject _currentMenu;
    [SerializeField] private GameObject _target;

    private Button _btn;

    void Awake()
    {
        _btn = GetComponent<Button>();
        if (_btn)
        {
            _btn.onClick.AddListener(NavigateToTarget);
        }
    }

    void NavigateToTarget()
    {
        _target.SetActive(true);
        _currentMenu.SetActive(false);
    }
}
