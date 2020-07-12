using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{

    public float duration = 0.4f;
    public int nextScene;
    private bool changeScene = false;
    private float startTime;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        Canvas canvas = gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 1;
        CanvasScaler canvasScaler = gameObject.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        canvasScaler.scaleFactor = 20;
        canvasScaler.referencePixelsPerUnit = 100;

        GameObject child = new GameObject("Image");
        child.transform.SetParent(gameObject.transform);

        image = child.AddComponent<Image>();
        image.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        RectTransform rect = child.GetComponent<RectTransform>();

        Vector2 rectMiddle = new Vector2(0.5f, 0.5f);

        float horizontalSize = 1.0f;
        float verticalSize = 1.0f;

        rect.sizeDelta = Vector2.zero;
        rect.anchoredPosition = Vector2.zero;

        rect.anchorMin = new Vector2(rectMiddle.x - horizontalSize / 2,
            rectMiddle.y - verticalSize / 2);
        rect.anchorMax = new Vector2(rectMiddle.x + horizontalSize / 2,
            rectMiddle.y + verticalSize / 2);
        Object.DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (!changeScene) {
            if (Time.time > startTime + duration) {
                image.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                startTime = Time.time;
                SceneManager.LoadScene(nextScene);
                changeScene = true;
            } else {
                image.color = new Color(0.0f, 0.0f, 0.0f, (Time.time - startTime)/duration);
            }
        } else {
            if (Time.time > startTime + duration) {
                Destroy(gameObject);
            } else {
                image.color = new Color(0.0f, 0.0f, 0.0f, 1.0f - (Time.time - startTime)/duration);
            }
        }
    }
}
