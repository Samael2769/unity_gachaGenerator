using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[System.Serializable]
public class UIobject
{
    public string name;
    public Sprite sprite;
    [HideInInspector] public Image image;
    [HideInInspector] public TextMeshProUGUI text;
    public string textString;
    public bool isButton;
    public bool hasText;
    [HideInInspector] public Button button;
    [HideInInspector] public GameObject gameObject;

    public int sizeX;
    public int sizeY;

    public int posX;
    public int posY;

    public int textSize;
    public int textPosX;
    public int textPosY;

    public UnityEvent onClickAction;

    public void setupUI()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
        rectTransform.localPosition = new Vector3(posX, posY, 0);
        image = gameObject.AddComponent<Image>();
        image.sprite = sprite;

        if (hasText)
        {
            GameObject t = new GameObject("Text");
            t.AddComponent<TextMeshProUGUI>();
            //set t parent to gameObject
            t.transform.SetParent(gameObject.transform);
            text = t.GetComponent<TextMeshProUGUI>();
            text.text = textString;
            text.fontSize = textSize;
            text.alignment = TextAlignmentOptions.Center;
            text.rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
            text.rectTransform.localPosition = new Vector3(textPosX, textPosY, 0);
        }
    }

    public void setCanvas(Canvas canvas)
    {
        //create UI object
        gameObject = new GameObject(name);
        gameObject.AddComponent<RectTransform>();
        gameObject.transform.SetParent(canvas.transform);
    }

    public void SetPosition()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
        rectTransform.localPosition = new Vector3(posX, posY, 0);
        image.sprite = sprite;

        if (hasText)
        {
            text.rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
            text.rectTransform.localPosition = new Vector3(textPosX, textPosY, 0);
            text.text = textString;
            text.fontSize = textSize;
        }
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void SetImage(Sprite sprite)
    {
        this.image.sprite = sprite;
    }

    public void onClick()
    {
        if (isButton)
        {
            onClickAction.Invoke();
        }
    }
}
