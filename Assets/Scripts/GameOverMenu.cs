using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _quitBtn;
    [SerializeField] private Text _text;

    void Awake()
    {
        _restartBtn.onClick.AddListener(Restart);
        _quitBtn.onClick.AddListener(Quit);
    }

    void Restart()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    void Quit()
    {
        Application.Quit(0);
    }

    public void GameOver(string txt)
    {
        Time.timeScale = 0;
        if (_text)
        {
            _text.text = txt;
        }
        
        gameObject.SetActive(true);
        Cursor.visible = true;
    }
}
