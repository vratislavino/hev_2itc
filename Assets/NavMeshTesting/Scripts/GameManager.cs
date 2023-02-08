using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance = new GameManager();

    public static GameManager Instance => instance;

    private PlayerSymbol playerReference;
    public PlayerSymbol PlayerReference => playerReference;

    private List<StaticSymbol> enemies = new List<StaticSymbol>();
    public List<StaticSymbol> Enemies => enemies; 

    private GameManager() { }

    public void SetPlayerReference(PlayerSymbol reference) {
        playerReference = reference;
    }

    public void AddEnemyToList(StaticSymbol enemy) {
        enemies.Add(enemy);
    }

    public void RemoveEnemyFromList(StaticSymbol enemy) {
        if (enemies.Contains(enemy)) {
            enemies.Remove(enemy);

            if(enemies.Count == 0) {
                Debug.Log("Hr·Ë vyhr·l! :)");
                Time.timeScale = 0;
            }
        }
    }
}
