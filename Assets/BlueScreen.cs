using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class BlueScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F8)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
