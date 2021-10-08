using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour
{
    private Button _btn;

    void Awake()
    {
        _btn = GetComponent<Button>();
        if (_btn)
        {
            _btn.onClick.AddListener(StartGame);
        }
    }


    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
