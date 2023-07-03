using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private Image swipeBar;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    Color arrowColour;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if (PlayerPrefs.GetString("ColourMode") == "Light"){
            arrowColour = Color.black;
            Camera.main.backgroundColor = ConvertColorTo01(255, 255, 255);
            swipeBar.color = Color.black;
            scoreText.color = ConvertColorTo01(0, 0, 0, 83);
            livesText.color = ConvertColorTo01(0, 0, 0, 83);
        }
        else{
            arrowColour = Color.white;
            swipeBar.color = Color.white;
            Camera.main.backgroundColor = ConvertColorTo01(14, 14, 14);
            scoreText.color = ConvertColorTo01(255, 255, 255, 83);
            livesText.color = ConvertColorTo01(255, 255, 255, 83);
        }
        StartCoroutine(SpawnArrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnArrow(){
        while (true){
            GameObject go = Resources.Load<GameObject>("arrowPF");
            go.GetComponent<Arrow>().speed += 0.2f;
            go.GetComponent<SpriteRenderer>().color = arrowColour;
            Instantiate(go, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

    private Color ConvertColorTo01 (int r, int g, int b, int a = 255){
        return new Color(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
    }
}
