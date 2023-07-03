using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    float secondsToWait = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
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
            Instantiate(go, gameObject.transform.position, Quaternion.identity);
            if (secondsToWait > 0.5){
                secondsToWait -= 0.02f;
            }
            
            yield return new WaitForSeconds(secondsToWait);
        }
    }

    private Color ConvertColorTo01 (int r, int g, int b, int a = 255){
        return new Color(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
    }
}
