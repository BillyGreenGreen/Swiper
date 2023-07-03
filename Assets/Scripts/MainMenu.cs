using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using GG.Infrastructure.Utils.Swipe;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Camera cam;
    private Image colourModeButton;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI play;
    [SerializeField] private TextMeshProUGUI reset;
    [SerializeField] private TextMeshProUGUI stats;
    [SerializeField] private TextMeshProUGUI swipeMe;
    float startTime = 0f;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    private void Start() {
        startTime = Time.time;
        colourModeButton = GameObject.Find("DarkMode").GetComponent<Image>();
        if (!PlayerPrefs.HasKey("HighScore")){
            PlayerPrefs.SetInt("HighScore", 0);
        }
        else{
            highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        }

        if (!PlayerPrefs.HasKey("ColourMode")){
            PlayerPrefs.SetString("ColourMode", "Light");
        }
        else{
            if (PlayerPrefs.GetString("ColourMode") == "Light"){
                cam.backgroundColor = ConvertColorTo01(255, 255, 255);
                colourModeButton.sprite = Resources.Load<Sprite>("moon");
                colourModeButton.color = ConvertColorTo01(14, 14, 14, 100);
                title.color = ConvertColorTo01(50, 50, 50, 255);
                highScoreText.color = ConvertColorTo01(0, 0, 0, 145);
                reset.color = ConvertColorTo01(0, 0, 0, 145);
                stats.color = ConvertColorTo01(0, 0, 0, 145);
                
            }
            else if (PlayerPrefs.GetString("ColourMode") == "Dark"){
                cam.backgroundColor = ConvertColorTo01(14, 14, 14);
                colourModeButton.sprite = Resources.Load<Sprite>("sun");
                colourModeButton.color = ConvertColorTo01(255, 214, 0, 180);
                title.color = ConvertColorTo01(255, 255, 255, 180);
                highScoreText.color = ConvertColorTo01(255, 255, 255, 180);
                reset.color = ConvertColorTo01(111, 111, 111, 255);
                stats.color = ConvertColorTo01(111, 111, 111, 255);
            }
        }

        if (!PlayerPrefs.HasKey("TotalSwipes")){
            PlayerPrefs.SetInt("TotalSwipes", 0);
            PlayerPrefs.SetInt("TotalSwipesUp", 0);
            PlayerPrefs.SetInt("TotalSwipesDown", 0);
            PlayerPrefs.SetInt("TotalSwipesLeft", 0);
            PlayerPrefs.SetInt("TotalSwipesRight", 0);
        }
    }

    private void Update() {
        float t2 = (Mathf.Cos( ( (Time.time - startTime) + 1 ) * Mathf.PI / 1 ) + 1 ) * 0.5f;
        swipeMe.color = Color.Lerp(startColor, endColor, t2);
    }

    public void SwitchToGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void ResetHighScore(){
        PlayerPrefs.SetInt("HighScore", 0);
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
    }

    public void SwitchColourMode(){
        if (colourModeButton.sprite.name == "moon"){
            cam.backgroundColor = ConvertColorTo01(14, 14, 14);
            colourModeButton.sprite = Resources.Load<Sprite>("sun");
            colourModeButton.color = ConvertColorTo01(255, 214, 0, 180);
            PlayerPrefs.SetString("ColourMode", "Dark");
            title.color = ConvertColorTo01(255, 255, 255, 180);
            highScoreText.color = ConvertColorTo01(255, 255, 255, 180);
            reset.color = ConvertColorTo01(111, 111, 111, 255);
            stats.color = ConvertColorTo01(111, 111, 111, 255);
        }
        else{
            cam.backgroundColor = ConvertColorTo01(255, 255, 255);
            colourModeButton.sprite = Resources.Load<Sprite>("moon");
            colourModeButton.color = ConvertColorTo01(14, 14, 14, 100);
            PlayerPrefs.SetString("ColourMode", "Light");
            title.color = ConvertColorTo01(50, 50, 50, 255);
            highScoreText.color = ConvertColorTo01(0, 0, 0, 145);
            reset.color = ConvertColorTo01(0, 0, 0, 145);
            stats.color = ConvertColorTo01(0, 0, 0, 145);
        }
    }

    private void OnEnable() {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe){
        if (swipe == "Right"){
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    private void OnDisable(){
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }

    public void SwitchToStats(){
        SceneManager.LoadScene("Stats");
    }

    private Color ConvertColorTo01 (int r, int g, int b, int a = 255){
        return new Color(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
    }


}
