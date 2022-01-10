using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int round = 1;
    public static int size = 20;
    public int[,] squares = new int[size, size];
    public GameObject fire;
    public GameObject hole;
    public GameObject ground;
    public GameObject start;
    public GameObject goal;
    public GameObject player;
    public GameObject enemy;
    public Text roundNum;
    public Text roundDeathNum;

    private int roundFinish;

    // Start is called before the first frame update
    void Start() {
        roundNum.text = round.ToString();
        SpawnSquares();
    }

    // Update is called once per frame
    void LateUpdate() {
        if(roundFinish == 1) {
            roundFinish = 0;
            UpdateRound();
        }
    }

    private void SpawnSquares() {
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                if (((i > size / 2 - 3) && (i < size / 2 + 1)) && ((j > size / 2 - 3) && (j < size / 2 + 1))) {
                    squares[i, j] = -2;
                } else if ((i == 0 || i == size - 1) || (j == 0 || j == size - 1)) {
                    squares[i, j] = -3;  // change goal
                } else {
                    squares[i, j] = 0;
                }
            }
        }

        for (int i = 0; i < round; i++) {
            int[,] temp = RandomSquares();
            int first = temp[0, 0];
            int sec = temp[0, 1];
            squares[first, sec] = -1;
            temp = EnemyCoords();
            first = temp[0, 0];
            sec = temp[0, 1];
            Instantiate(enemy, new Vector3(first, 0.5f, sec), Quaternion.identity);
        }

        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                if (squares[i, j] == -3) {
                    Instantiate(goal, new Vector3(2 * (i + 1), 0, 2 * (j + 1)), Quaternion.identity);
                } else if (squares[i, j] == -2) {
                    Instantiate(start, new Vector3(2 * (i + 1), 0, 2 * (j + 1)), Quaternion.identity);
                } else if (squares[i, j] == -1) {
                    Instantiate(hole, new Vector3(2 * (i + 1), 0, 2 * (j + 1)), Quaternion.identity);
                } else if (squares[i, j] == 0) {
                    Instantiate(ground, new Vector3(2 * (i + 1), 0, 2 * (j + 1)), Quaternion.identity);
                } else {
                    Instantiate(fire, new Vector3(2 * (i + 1), 0, 2 * (j + 1)), Quaternion.identity);
                }
            }
        }
        //Instantiate(goal, new Vector3(20, -0.5f, 20), Quaternion.identity);
    }

    int[,] RandomSquares() {
        int[,] x = new int[1, 2] { { Random.Range(1, size - 1), Random.Range(1, size - 1) } };
        int i = x[0, 0];
        int j = x[0, 1];
        if (((i > size / 2 - 3) && (i < size / 2 + 1)) && ((j > size / 2 - 3) && (j < size / 2 + 1))) {
            x = RandomSquares();
        } else if (squares[i, j] != 0) {
            x = RandomSquares();
        }
        return x;
    }

    public void SignalUpdate() {
        roundFinish = 1;
    }

    private void UpdateRound() {
        Debug.Log("1");
        player.transform.SetPositionAndRotation(new Vector3(20, 0.5f, 20), Quaternion.identity);
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject go in gos) {
            Destroy(go);
        }
        gos = GameObject.FindGameObjectsWithTag("Damage");
        foreach (GameObject go in gos) {
            Destroy(go);
        }
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in gos) {
            Destroy(go);
        }
        round++;
        SpawnSquares();
        roundNum.text = round.ToString();
        roundDeathNum.text = round.ToString();
        Time.timeScale = 1;
        Debug.Log("2");
    }

    public int[,] EnemyCoords() {
        int[,] x = new int[1, 2] { { Random.Range(3, size * 2 - 2), Random.Range(3, size * 2 - 2) } };
        int i = x[0, 0];
        int j = x[0, 1];
        if (((i > 2*size / 2 - 3) && (i < 2*size / 2 + 3)) && ((j > 2*size / 2 - 3) && (j < 2*size / 2 + 3))) {
            x = EnemyCoords();
        }

        return x;
    }
}
