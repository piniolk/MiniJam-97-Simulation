using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public GameObject gameManager;

    /*private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Goal");
            gameManager = GameObject.FindGameObjectWithTag("Manager");
            gameManager.GetComponent<GameManager>().SignalUpdate();
        }
    }*/
}
