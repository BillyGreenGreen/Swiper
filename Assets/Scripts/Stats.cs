using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GG.Infrastructure.Utils.Swipe;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI swipeMe;
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] public TextMeshProUGUI[] statsText;
    float startTime = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        if (PlayerPrefs.GetString("ColourMode") == "Light"){
            Camera.main.backgroundColor = ConvertColorTo01(255, 255, 255);
            int count = 0;
            foreach (var text in statsText){
                Debug.Log(count);
                if (count == 0){
                    text.color = ConvertColorTo01(50, 50, 50, 255);
                }
                else{
                    text.color = ConvertColorTo01(0, 0, 0, 145);
                    if (count == 1){
                        text.text = "TOTAL SWIPES: " + PlayerPrefs.GetInt("TotalSwipes").ToString();
                        Debug.Log(PlayerPrefs.GetInt("TotalSwipes").ToString());
                    }
                    else if(count == 2){
                        text.text = "TOTAL RIGHTS: " + PlayerPrefs.GetInt("TotalSwipesRight").ToString();
                    }
                    else if(count == 3){
                        text.text = "TOTAL LEFTS: " + PlayerPrefs.GetInt("TotalSwipesLeft").ToString();
                    }
                    else if(count == 4){
                        text.text = "TOTAL UPS: " + PlayerPrefs.GetInt("TotalSwipesUp").ToString();
                    }
                    else if(count == 5){
                        text.text = "TOTAL DOWNS: " + PlayerPrefs.GetInt("TotalSwipesDown").ToString();
                    }
                }
                count++;
            }
        }
        else if (PlayerPrefs.GetString("ColourMode") == "Dark"){
            Camera.main.backgroundColor = ConvertColorTo01(14, 14, 14);
            int count = 0;
            foreach (var text in statsText){
                if (count == 0){
                    text.color = ConvertColorTo01(255, 255, 255, 180);
                }
                else{
                    text.color = ConvertColorTo01(111, 111, 111, 255);
                    if (count == 1){
                        text.text = "TOTAL SWIPES: " + PlayerPrefs.GetInt("TotalSwipes").ToString();
                        Debug.Log(PlayerPrefs.GetInt("TotalSwipes").ToString());
                    }
                    else if(count == 2){
                        text.text = "TOTAL RIGHTS: " + PlayerPrefs.GetInt("TotalSwipesRight").ToString();
                    }
                    else if(count == 3){
                        text.text = "TOTAL LEFTS: " + PlayerPrefs.GetInt("TotalSwipesLeft").ToString();
                    }
                    else if(count == 4){
                        text.text = "TOTAL UPS: " + PlayerPrefs.GetInt("TotalSwipesUp").ToString();
                    }
                    else if(count == 5){
                        text.text = "TOTAL DOWNS: " + PlayerPrefs.GetInt("TotalSwipesDown").ToString();
                    }
                }
                count++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float t2 = (Mathf.Cos( ( (Time.time - startTime) + 1 ) * Mathf.PI / 1 ) + 1 ) * 0.5f;
        swipeMe.color = Color.Lerp(startColor, endColor, t2);
    }

    private void OnEnable() {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe){
        if (swipe == "Left"){
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    private void OnDisable(){
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }

    private Color ConvertColorTo01 (int r, int g, int b, int a = 255){
        return new Color(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
    }
}
