using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class prepareShot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Color cold = Color.blue;
    Color ready = Color.yellow;
    Color set = new Color(1.0f, 0.64f, 0.0f);
    Color fire = Color.red;
    Color originalColor;

    public Text text;
    Image image;

    bool isOver;
    float chargeStart;

    public float readyTime = 1.0f;
    public float setTime = 2.0f;
    public float fireTime = 3.0f;
    public float dieTime = 4.0f;

    public GameObject panel;
    public GameObject playPistol;
    public float bangTime;
    public bool initiateTimer = false;
    public bool changeScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        originalColor = image.color;
    }

    public void Shoot()
    {
        panel.SetActive(true);
        initiateTimer = true;
        bangTime = Time.time + 2;
    }
    void Update()
    {
        if (initiateTimer && bangTime < Time.time)
        {
            GetComponent<NextSceneButton>().nextsceneButton();
        }
        if (isOver)
        {
            float charge = Time.time - chargeStart;
            if (charge < readyTime)
            {
                image.color = cold;
                text.text = "Hold it!";
                text.color = Color.white;
            }
            else if (charge < setTime)
            {
                image.color = ready;
                text.text = "Ready";
            }
            else if (charge < fireTime)
            {
                image.color = set;
                text.text = "Set";
            }
            else if (charge < dieTime)
            {
                image.color = fire;
                text.text = "Fire!";
                playPistol.SetActive(true);
            }
            else
            {
                GetComponent<NextSceneButton>().previoussceneButton();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        chargeStart = Time.time;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        image.color = originalColor;
    }
    // Update is called once per frame
}
