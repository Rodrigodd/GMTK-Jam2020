using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{
    public void nextsceneButton(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
