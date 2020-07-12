using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flee : MonoBehaviour
{

    RectTransform rect;

    public float distance = 200.0f;
    public float veloc = 5.0f;

    public bool collideBounds = false;

    void Start() {
        rect = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 delta = Input.mousePosition - rect.position;
        if (delta.x > (Screen.width/2.0f)) {
            delta.x -= Screen.width;
        } else if (delta.x < -(Screen.width/2.0f)) {
            delta.x += Screen.width;
        }
        if (delta.y > (Screen.height/2.0f)) {
            delta.y -= Screen.height;
        } else if (delta.y < -(Screen.height/2.0f)) {
            delta.y += Screen.height;
        }
        delta.y = delta.y % (Screen.height/2.0f);
        // print("delta: " + delta);
        if (delta.magnitude < distance) {
            float x = delta.magnitude/distance;
            rect.position -= delta.normalized * (1.0f - x*x*x) * veloc;
            if (collideBounds) {
                if (rect.position.x < rect.rect.width/2.0f) {
                    rect.position = new Vector3(rect.rect.width/2.0f, rect.position.y, rect.position.z);
                } else if (rect.position.x > Screen.width - rect.rect.width/2.0f) {
                    rect.position = new Vector3(Screen.width - rect.rect.width/2.0f, rect.position.y, rect.position.z);
                }
                if (rect.position.y < rect.rect.height/2.0f) {
                    rect.position = new Vector3(rect.position.x, rect.rect.height/2.0f, rect.position.z);
                } else if (rect.position.y > Screen.height - rect.rect.height/2.0f) {
                    rect.position = new Vector3(rect.position.x, Screen.height - rect.rect.height/2.0f, rect.position.z);
                }
            } else {
                if (rect.position.x < 0.0) {
                    rect.position += new Vector3(Screen.width,0,0);
                } else if (rect.position.x > Screen.width) {
                    rect.position += new Vector3(-Screen.width,0,0);
                }
                if (rect.position.y < 0.0) {
                    rect.position += new Vector3(0,Screen.height,0);
                } else if (rect.position.y > Screen.height) {
                    rect.position += new Vector3(0,-Screen.height,0);
                }
            }
        }
    }
}
