using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 15;
    public Vector3? Target { get; set; }
    public Vector3 startPosition;

    void Start() {
        Target = null;
        startPosition = transform.position;
        Debug.Log(startPosition);
    }

    void Update() {
        if (Target.HasValue) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Target.Value, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<CharacterController>().GiveBall(this);
            ScoreSystem.UpdateScore(10);
        }
    }

    //Reset position of ball
    public void reset() {
        // Make object top level component
        transform.SetParent(null);

        transform.position = startPosition;
        Target = null;

    }
}
