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
}

public enum Symbol
{
    Rock, Paper, Scissors
}
