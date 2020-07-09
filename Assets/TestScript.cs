using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time*2.0f*Mathf.PI / 5.0f;
        float r = 4.5f;
        transform.position = new Vector3(r*Mathf.Sin(2*t), r*Mathf.Cos(t), 0.0f);
    }
}
