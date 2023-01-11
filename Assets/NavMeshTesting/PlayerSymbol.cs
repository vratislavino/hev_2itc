using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSymbol : MonoBehaviour
{
    private Symbol currentSymbol;

    // Start is called before the first frame update
    void Start()
    {
        currentSymbol = GenerateRandomSymbol();
    }

    private Symbol GenerateRandomSymbol() {
        int rand = UnityEngine.Random.Range(0, 3);
        return (Symbol) rand;
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
