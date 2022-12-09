using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairCollector : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    [SerializeField]
    private GameObject deathScreen;

    int score = 0;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.enabled = false;

        Debug.Log(collision.collider.name);
        var pointsScr = collision.collider.GetComponentInParent<HairPoints>();
        
        if (pointsScr != null)
        {
            score += pointsScr.Points;
            ScoreChanged?.Invoke(score);
        } else
        {
            GameOver();
        }

            
        Destroy(collision.gameObject);
    }

    private void GameOver()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
