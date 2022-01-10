using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5f;
    public CharacterController controller;
    public GameObject gameManager;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);

        controller.Move(movement * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Damage") || collision.gameObject.CompareTag("Enemy")) {
            buttons.GetComponent<MainMenu>().EndGame();
        }

        if (collision.gameObject.CompareTag("Goal")) {
            Debug.Log("Goal");
            Time.timeScale = 0;
            gameManager = GameObject.FindGameObjectWithTag("Manager");
            gameManager.GetComponent<GameManager>().SignalUpdate();
        }
    }
}
