using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotooptions : MonoBehaviour
{
    static int lastScene = 0;
    public void Gotooptions() {
        lastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Menu Options");
    }

    public void GoBack() {
        SceneManager.LoadScene(lastScene);
    }
}
