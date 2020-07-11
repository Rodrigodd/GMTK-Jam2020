using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flee : MonoBehaviour
{

    RectTransform rect;

    void Start() {
        rect = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 delta = Input.mousePosition - rect.position;
        // print("delta: " + delta);
        if (delta.magnitude < 100.0) {
            rect.position -= delta;
            print("rect: " + rect.position);
            if (rect.position.x < 0.0) {
                rect.position += new Vector3(Screen.width,0,0);
            } else if (rect.position.x > Screen.width) {
                rect.position += new Vector3(-Screen.width,0,0);
            }
            if (rect.position.y < 0.0) {
                rect.position += new Vector3(Screen.height,0,0);
            } else if (rect.position.y > Screen.height) {
                rect.position += new Vector3(-Screen.height,0,0);
            }
        }
    }
}
