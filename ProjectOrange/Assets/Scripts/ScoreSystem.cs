using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    static public ScoreSystem instance;
    public Transform player;
    public TextMeshProUGUI scoreText;

    private int score = 0;

    // Called when an instance awakes in the game
    void Awake() {
        instance = this;
    }


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        scoreText.text = score.ToString("0");
    }

    static public void UpdateScore(int delta) {
        instance.StartCoroutine(instance.UpdateScoreSlowly(delta));
        instance.StartCoroutine(instance.PulseScore());
    }

    private IEnumerator UpdateScoreSlowly(int delta) {
        for (int i = 0; i < delta; i++) {
            score++;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator PulseScore() {
        for (float i = 1f; i <= 1.5f; i += 0.01f) {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }

        for (float i = 1.5f; i >= 1f; i -= 0.01f) {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
