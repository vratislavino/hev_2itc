using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest2D : MonoBehaviour
{
    private Animator chestAnimator;

    [SerializeField]
    private string levelToLoad;

    bool isOpened = false;

    private void Start() {
        chestAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        chestAnimator.SetBool("Opening", true);
        isOpened = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        chestAnimator.SetBool("Opening", false);
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
