using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFire : MonoBehaviour {
    public GameObject fire;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Vector3 groundPos = transform.position;
            Instantiate(fire, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
