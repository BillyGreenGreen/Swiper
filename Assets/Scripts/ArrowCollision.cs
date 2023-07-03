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
                Swiped();
                int totalSwipes = PlayerPrefs.GetInt("TotalSwipesRight");
                PlayerPrefs.SetInt("TotalSwipesRight", totalSwipes += 1);
            }
            else if (swipe == "Left" && arrowRotation == 180){
                int totalSwipes = PlayerPrefs.GetInt("TotalSwipesLeft");
                PlayerPrefs.SetInt("TotalSwipesLeft", totalSwipes += 1);
                Swiped();
            }
            else if (swipe == "Up" && arrowRotation == 90){
                int totalSwipes = PlayerPrefs.GetInt("TotalSwipesUp");
                PlayerPrefs.SetInt("TotalSwipesUp", totalSwipes += 1);
                Swiped();
            }
            else if (swipe == "Down" && arrowRotation == 270){
                int totalSwipes = PlayerPrefs.GetInt("TotalSwipesDown");
                PlayerPrefs.SetInt("TotalSwipesDown", totalSwipes += 1);
                Swiped();
            }
        }
        
    }

    private void OnDisable(){
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }

    private void Swiped(){
        int totalSwipes = PlayerPrefs.GetInt("TotalSwipes");
        PlayerPrefs.SetInt("TotalSwipes", totalSwipes += 1);
        GameObject go = Resources.Load<GameObject>("arrowPF_Swiped");
        go.GetComponent<ArrowSwipeAnimation>().rotation = arrowRotation;
        if (PlayerPrefs.GetString("ColourMode") == "Light"){
            go.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else{
            go.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Instantiate(go);
        Destroy(arrow);
        score++;
        lives++;
    }
}
