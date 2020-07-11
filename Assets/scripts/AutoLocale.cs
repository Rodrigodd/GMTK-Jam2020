using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class AutoLocale : MonoBehaviour
{
    static Dictionary<string, string[]> strings = null;
    static int currentLang = 0;
    static List<AutoLocale> autoLocales;


    public string key;
    private Text textComponent;

    static void ParseCSV() {
        AutoLocale.strings = new Dictionary<string, string[]>();
        TextAsset textFile =(TextAsset)Resources.Load("strings");
        string text = textFile.text;
        print(text);
        string[] lines = text.Split('\n');
        foreach (string line in lines) {
            string[] words = line.Trim().Split(',');
            string key = words[0];
            print(key);
            string[] value = new string[words.Length - 1];
            Array.Copy(words, 1, value, 0, words.Length - 1);
            AutoLocale.strings.Add(key, value);
        }
    }

    static string GetString(string key) {
        if (AutoLocale.strings == null) {
            AutoLocale.ParseCSV();
        }
        string[] values = null;
        AutoLocale.strings.TryGetValue(key, out values);
        if (values == null) {
            return key;
        } else {
            return values[AutoLocale.currentLang];
        }
    }

    public static void ChangeLanguage(int language) {
        AutoLocale.currentLang = language;
        if (AutoLocale.autoLocales == null) return;
        foreach (AutoLocale text in AutoLocale.autoLocales) {
            text.UpdateText();
        }
    }

    void Awake() {
        if (autoLocales == null) {
            autoLocales = new List<AutoLocale>();
        }
        autoLocales.Add(this);
        textComponent = gameObject.GetComponent<Text>();
        UpdateText();
    }

    void UpdateText() {
        textComponent.text = AutoLocale.GetString(key);
    }
}
