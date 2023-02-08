using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSymbol : StaticSymbol
{

    [SerializeField]
    private float symbolDuration = 1f;

    private void Awake() {
        GameManager.Instance.SetPlayerReference(this);
    }

    protected override void Start() {
        base.Start();

        StartCoroutine(SwitchSymbol());
    }

    private IEnumerator SwitchSymbol() {
        while (true) {
            yield return new WaitForSeconds(symbolDuration);
            CurrentSymbol = GenerateNextSymbol();
        }
    }

    private Symbol GenerateNextSymbol() {
        Symbol newSymbol;
        do {
            newSymbol = GenerateRandomSymbol();
        } while (newSymbol == currentSymbol);
        
        return newSymbol;
    }

    public bool WouldEnemyWin(Symbol enemy) {
        if (CurrentSymbol == Symbol.Paper)
            return enemy == Symbol.Scissors;
        if (CurrentSymbol == Symbol.Rock)
            return enemy == Symbol.Paper;
        if (CurrentSymbol == Symbol.Scissors)
            return enemy == Symbol.Rock;

        return false;
    }

    private void OnTriggerEnter(Collider other) {

        var enemy = other.GetComponentInParent<StaticSymbol>();
        if (enemy != null) {
            if (enemy.CurrentSymbol == CurrentSymbol)
                return;

            if(WouldEnemyWin(enemy.CurrentSymbol)) {
                Debug.Log("Prohrál jsi!");
                Time.timeScale = 0;
            } else {
                Destroy(enemy.gameObject);
            }
        }
    }
}

public enum Symbol
{
    Rock, Paper, Scissors
}
