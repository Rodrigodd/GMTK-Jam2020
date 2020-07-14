using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{

    private bool transition = false;
    private bool startMusic = false;
    
    static private string[] musics = {
        "rock",
        "hall",
        "fada",
        "desert",
        "beach",
        "Cubo",
        "Trippin",
    };

    public AudioClip music = null;

    private AudioSource audioSource;

    void Start() {
        if (!startMusic) {
            startMusic = true;
            GameObject musicObject = new GameObject("musica");
            audioSource = musicObject.AddComponent<AudioSource>();
            if (music == null) {
                music = (AudioClip)Resources.Load("musics/" + musics[SceneManager.GetActiveScene().buildIndex % musics.Length]);
            }
            audioSource.clip = music;
            audioSource.volume = 0.3f;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopMusic() {
        audioSource.Stop();
    }

    public void nextsceneButton(){
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print("transition");
        if (!transition) {
            transition = true;
            GameObject trans = new GameObject("Transition");
            Transition t = trans.AddComponent<Transition>();
            t.nextScene = SceneManager.GetActiveScene().buildIndex + 1;

            GameObject musicObject = new GameObject("confirm");
            AudioSource audio = musicObject.AddComponent<AudioSource>();
            audio.clip = (AudioClip)Resources.Load("confirm");
            audio.Play();
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
                t.nextScene = Random.Range(0, curr);

                GameObject musicObject = new GameObject("negate");
                AudioSource audio = musicObject.AddComponent<AudioSource>();
                audio.clip = (AudioClip)Resources.Load("negate");
                audio.Play();
            }
        }
    }
}
