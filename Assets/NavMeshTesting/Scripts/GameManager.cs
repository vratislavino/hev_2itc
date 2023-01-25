using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance = new GameManager();

    public static GameManager Instance => instance;

    private PlayerSymbol playerReference;
    public PlayerSymbol PlayerReference => playerReference;

    private List<StaticSymbol> enemies;
    public List<StaticSymbol> Enemies => enemies; 

    private GameManager() { }

    public void SetPlayerReference(PlayerSymbol reference) {
        playerReference = reference;
    }

    public void AddEnemyToList(StaticSymbol enemy) {
        enemies.Add(enemy);
    }
}
