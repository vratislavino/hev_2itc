using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    HairCollector collector;

    // Start is called before the first frame update
    void Start()
    {
        collector.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        text.text = score.ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("VlasyProKubinaGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
