using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{

    private bool transition = false;

    public void nextsceneButton(){
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print("transition");
        if (!transition) {
            transition = true;
            GameObject trans = new GameObject("Transition");
            Transition t = trans.AddComponent<Transition>();
            t.nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }

    public void previoussceneButton(){
        if (!transition) {
            int curr = SceneManager.GetActiveScene().buildIndex;
            if (curr != 0) {
                transition = true;
                GameObject trans = new GameObject("Transition");
                Transition t = trans.AddComponent<Transition>();
                t.duration = t.duration / 2.0f;
                t.nextScene = curr - 1;
            }
        }
    }
}
