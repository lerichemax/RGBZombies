using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameBtn : MonoBehaviour
{
    private Button _btn;

    void Awake()
    {
        _btn = GetComponent<Button>();
        if (_btn)
        {
            _btn.onClick.AddListener(Quit);
        }
    }


    void Quit()
    {
        Application.Quit(0);
    }
}
