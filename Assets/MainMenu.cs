using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    private void Start() {
        if (!PlayerPrefs.HasKey("HighScore")){
            PlayerPrefs.SetInt("HighScore", 0);
        }
        else{
            highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        }
    }
    public void SwitchToGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void ResetHighScore(){
        PlayerPrefs.SetInt("HighScore", 0);
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
    }
}
