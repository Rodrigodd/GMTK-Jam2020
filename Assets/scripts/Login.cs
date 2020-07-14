using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject incorrectPanel;
    private string Username;
    private string Password;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoginButton(){
        
        if(Password == ",}duhw-6cdxR=7d"&&Username == "GA#g&dURMB+Z38<"){
            gameObject.GetComponent<NextSceneButton>().nextsceneButton();
        } else {
            incorrectPanel.SetActive(true);
        }

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
    // Update is called once per frame
    void Update()
    {

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;

        if(Input.GetKeyDown(KeyCode.Return)){
            if(Password == ",}duhw-6cdxR=7d"&&Username == "GA#g&dURMB+Z38<"){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }
}

