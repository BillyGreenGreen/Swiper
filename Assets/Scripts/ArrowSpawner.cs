using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
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
            yield return new WaitForSeconds(1);
        }
        
    }
}
