using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrowCollision : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    private GameObject arrow = null;
    private float arrowRotation;
    private int score = 0;
    private int lives = 3;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Update() {
        scoreText.text = score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0){
            if (PlayerPrefs.GetInt("HighScore") < score){
                PlayerPrefs.SetInt("HighScore", score);
            }
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.gameObject.GetComponent<Arrow>().rotation);
        arrow = other.gameObject;
        arrowRotation = arrow.GetComponent<Arrow>().rotation;
    }

    private void OnTriggerExit2D(Collider2D other) {
        other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        lives--;
        arrow = null;
    }

    private void OnEnable() {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe){
        if (arrow != null){
            if (swipe == "Right" && arrowRotation == 0){
                Destroy(arrow);
                score++;
                lives++;
            }
            else if (swipe == "Left" && arrowRotation == 180){
                Destroy(arrow);
                score++;
                lives++;
            }
            else if (swipe == "Up" && arrowRotation == 90){
                Destroy(arrow);
                score++;
                lives++;
            }
            else if (swipe == "Down" && arrowRotation == 270){
                Destroy(arrow);
                score++;
                lives++;
            }
        }
        
    }

    private void OnDisable(){
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
