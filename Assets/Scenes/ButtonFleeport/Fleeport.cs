using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fleeport : MonoBehaviour
{

    RectTransform rect;
    int count = 0;
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (count < 3)
        {
            count++;
            Vector3 delta = Input.mousePosition - rect.position;
            delta.x = Mathf.Abs(Random.Range(0.0f, Screen.width));
            delta.y = Mathf.Abs(Random.Range(0.0f, Screen.height));

        }
    }
}
