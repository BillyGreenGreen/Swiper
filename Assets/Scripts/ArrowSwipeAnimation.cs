using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSwipeAnimation : MonoBehaviour
{
    public float rotation;
    private float speed = 2.5f;
    private float startTime = 0f;

    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    private void Start() {
        startColor = gameObject.GetComponent<SpriteRenderer>().color;
        endColor = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, 0);
        gameObject.transform.rotation = Quaternion.Euler(0,0,rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotation == 0){
            Vector2 endPos = new Vector2(1.5f, transform.position.y);
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (transform.position.x == 1.5f){
                Destroy(gameObject);
            }
        }
        else if (rotation == 90){
            Vector2 endPos = new Vector2(transform.position.x, 1.5f);
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (transform.position.y == 1.5f){
                Destroy(gameObject);
            }
        }
        else if (rotation == 180){
            Vector2 endPos = new Vector2(-1.5f, transform.position.y);
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (transform.position.x == -1.5f){
                Destroy(gameObject);
            }
        }
        else if (rotation == 270){
            Vector2 endPos = new Vector2(transform.position.x, -1.5f);
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (transform.position.y == -1.5f){
                Destroy(gameObject);
            }
        }
    }

    private void Update() {
        startTime += Time.deltaTime * speed;
        gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, startTime);
    }

    private Color ConvertColorTo01 (int r, int g, int b, int a = 255){
        return new Color(r/255.0f, g/255.0f, b/255.0f, a/255.0f);
    }
}
