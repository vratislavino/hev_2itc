using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSymbol : MonoBehaviour
{
    private Symbol currentSymbol;

    public Symbol CurrentSymbol {
        get { return currentSymbol; }
        set {
            currentSymbol = value;
            quadRenderer.material = materials[(int)currentSymbol];
        }
    }

    [SerializeField]
    private float symbolDuration = 1f;

    [SerializeField]
    private List<Material> materials;

    [SerializeField]
    private MeshRenderer quadRenderer;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSymbol = GenerateRandomSymbol();

        StartCoroutine(SwitchSymbol());
    }

    private IEnumerator SwitchSymbol() {
        while (true) {
            yield return new WaitForSeconds(symbolDuration);
            CurrentSymbol = GenerateNextSymbol();
        }
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
