using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector2 currentPos;
    private Vector2 endPos = new Vector2(0, -8);
    public float speed = 5f;
    public float rotation = 0f;
    List<int> rotations = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        rotations.Add(0);
        rotations.Add(90);
        rotations.Add(180);
        rotations.Add(270);
        //0 = right
        //90 = up
        //180 = left
        //270 = down
        currentPos = new Vector2(0, 10);
        int rng = Random.Range(0, rotations.Count);
        rotation = rotations[rng];
        gameObject.transform.rotation = Quaternion.Euler(0,0,rotation);

        if(PlayerPrefs.GetString("ColourMode") == "Light"){
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        if (transform.position.y == -8){
            Destroy(gameObject);
        }
    }
}
