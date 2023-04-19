using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest2D : MonoBehaviour
{
    private SpriteRenderer rend;

    [SerializeField]
    private Sprite openedChest;
    [SerializeField]
    private Sprite closedChest;

    [SerializeField]
    private string levelToLoad;

    bool isOpened = false;

    private void Start() {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        rend.sprite = openedChest;
        isOpened = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        rend.sprite = closedChest;
        isOpened = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isOpened) {
            LoadLevel(levelToLoad);
        }
    }

    private void LoadLevel(string level) {
        SceneManager.LoadScene(level);
    }
}
