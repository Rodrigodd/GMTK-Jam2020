using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private int currentLang = 0;

    void Awake() {
        AutoLocale.ChangeLanguage(currentLang);
    }

    public void ChangeLanguage(int language) {
        currentLang = language;
        AutoLocale.ChangeLanguage(language);
    }
}
