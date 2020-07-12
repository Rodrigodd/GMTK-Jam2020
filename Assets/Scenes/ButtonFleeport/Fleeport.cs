using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fleeport : MonoBehaviour
{
    int count = 0;
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
    }
    public void Onclick()
    {
        if (count < 3)
        {
            count++;
            Vector3 delta = new Vector3();
            delta.x = Mathf.Abs(Random.Range(0.0f, Screen.width));
            delta.y = Mathf.Abs(Random.Range(0.0f, Screen.height));
            rect.position = delta;
        }
        else
        {
            gameObject.GetComponent<NextSceneButton>().nextsceneButton();
        }

    }
    RectTransform rect;
}
