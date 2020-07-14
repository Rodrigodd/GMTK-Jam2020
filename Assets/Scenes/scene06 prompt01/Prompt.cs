using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prompt : MonoBehaviour
{
    // DEVils [version 1.0.3f1]
    // (c) 2020 DEVils. All Rights Reserved.
    public Text textBox;
    public InputField inputField;

    public int level = 0;
    private bool compiled = false;

    void Start() {
        inputField.Select();
        inputField.ActivateInputField();
    }

    void nextScene() {
        gameObject.GetComponent<NextSceneButton>().nextsceneButton();
    }

    void previousScene() {
        gameObject.GetComponent<NextSceneButton>().previoussceneButton();
    }

    void ParseInput(string input) {
        string[] args = input.Split(' ');
        switch (level) {
            case 0:
                if(args[0] == "exit") {
                    previousScene();
                } else if(args[0] == "play_game") {
                    nextScene();
                } else if(args[0] == "echo") {
                    textBox.text += "\n " + (args.Length >= 2 ? args[1] : "argument is invalid");
                } else if (args[0] == "help") {
                    textBox.text += "\n\n list of commands:";
                    textBox.text += "\n  exit - exit the prompt";
                    textBox.text += "\n  play_game - enter this command to play";
                    textBox.text += "\n  echo <arg> - print <arg> to output";
                    textBox.text += "\n";
                } else {
                    textBox.text += "\n command not found\n type \"help\" for a list of all commands.";
                }
                break;
            case 1:
                if(args[0] == "exit") {
                    previousScene();
                } else if(args[0] == "run") {
                    if (args.Length <= 1) {
                        textBox.text += "\n argument is invalid";
                    } else if (args[1] == "game") {
                        nextScene();
                    } else if (args[1] == "fibonacci") {
                        textBox.text += "\n 1 1 2 3 5 8 13 21 34 55 89";
                    } else if (args[1] == "save_file.txt") {
                        textBox.text += "\n file is not executable";
                    } else {
                        textBox.text += "\n file not found";
                    }
                } else if (args[0] == "list") {
                    textBox.text += "\n\n files:";
                    textBox.text += "\n  fibonacci";
                    textBox.text += "\n  game";
                    textBox.text += "\n  save_file.txt";
                    textBox.text += "\n";
                } else if(args[0] == "echo") {
                    textBox.text += "\n " + (args.Length >= 2 ? args[1] : "argument is invalid");
                } else if (args[0] == "help") {
                    textBox.text += "\n\n list of commands:";
                    textBox.text += "\n  exit - exit the prompt";
                    textBox.text += "\n  run <file> - run the file with name <file>";
                    textBox.text += "\n  list - list all files";
                    textBox.text += "\n  echo <arg> - print <arg> to output";
                    textBox.text += "\n";
                } else {
                    textBox.text += "\n command not found\n type \"help\" for a list of all commands.";
                }
                break;
            case 2:
                if(args[0] == "exit") {
                    previousScene();
                } else if(args[0] == "run") {
                    if (args.Length <= 1) {
                        textBox.text += "\n argument is invalid";
                    } else if (compiled && args[1] == "game") {
                        nextScene();
                    } else if (args[1] == "fibonacci") {
                        textBox.text += "\n 1 1 2 3 5 8 13 21 34 55 89";
                    } else if (args[1] == "save_file.txt") {
                        textBox.text += "\n file is not executable";
                    } else {
                        textBox.text += "\n file not found";
                    }
                } else if (args[0] == "list") {
                    textBox.text += "\n\n files:";
                    textBox.text += "\n  fibonacci";
                    textBox.text += "\n  save_file.txt";
                    textBox.text += "\n  game.source";
                    if (compiled) {
                        textBox.text += "\n  game";
                    }
                    textBox.text += "\n";
                } else if (args[0] == "echo") {
                    textBox.text += "\n " + (args.Length >= 2 ? args[1] : "argument is invalid");
                } else if (args[0] == "make") {
                    if (args.Length <= 1) {
                        textBox.text += "\n argument is invalid";
                    } else if (args[1] == "fibonacci" || args[1] == "save_file.txt" || (compiled && args[1] == "game")) {
                        textBox.text += "\n compiling... failed parsing source file: this file is not a source file.";
                    } else if (args[1] == "game.source") {
                        textBox.text += "\n compiling... sucess: output to file \"game\"";
                        compiled = true;
                    } else {
                        textBox.text += "\n file not found";
                    }
                } else if (args[0] == "help") {
                    textBox.text += "\n\n list of commands:";
                    textBox.text += "\n  exit - exit the prompt";
                    textBox.text += "\n  run <file> - run the file with name <file>";
                    textBox.text += "\n  make <source> - compile a source file into a executable";
                    textBox.text += "\n  list - list all files";
                    textBox.text += "\n  echo <arg> - print <arg> to output";
                    textBox.text += "\n";
                } else {
                    textBox.text += "\n command not found\n type \"help\" for a list of all commands.";
                }
                break;
        }
    }

    void Update()
    {
        if (!inputField.isFocused) {
            inputField.Select();
            inputField.ActivateInputField();
        }
        if(Input.GetKeyDown(KeyCode.Return)) {
            string input = inputField.text.Trim();
            if (input.Length != 0) {
                textBox.text += "\n > " + input;
                ParseInput(input);
            }
            inputField.text = "";
        }
    }
}
