using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Poll : MonoBehaviour
{
    public List<Prize> prizes = new List<Prize>();
    public List<UIobject> UIobjects = new List<UIobject>();
    public Canvas canvas;
    public List<string> Logs = new List<string>();
    public string date;


    public int prizeX;
    public int prizeY;
    public int prizeSizeX;
    public int prizeSizeY;
    // Start is called before the first frame update
    void Start()
    {
        //date for logs
        date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        UIobject prize = new UIobject();
        prize.name = "Prize";
        prize.isButton = false;
        prize.hasText = true;
        prize.posX = prizeX;
        prize.posY = prizeY;
        prize.sizeX = 0;
        prize.sizeY = 0;
        prize.textString = "Prize";
        prize.textSize = 0;
        prize.textPosX = 0;
        prize.textPosY = 0;
        //add prize to first place of Uiobjects
        UIobjects.Add(prize);

        for (int i = 0; i < UIobjects.Count; i++)
        {
            Logs.Add("[" + date + "] Setting Up UIobjects[" + i + "] = " + UIobjects[i].name);
            UIobjects[i].setCanvas(canvas);
            UIobjects[i].setupUI();
        }
    }

    //on exit
    private void OnApplicationQuit()
    {
        foreach (string log in Logs)
        {
            Debug.Log(log);
        }
    }

    void setupPrize(int id)
    {
        UIobjects[UIobjects.Count - 1].sprite = prizes[id].image;
        UIobjects[UIobjects.Count - 1].textString = prizes[id].name;
        UIobjects[UIobjects.Count - 1].textSize = 50;
        UIobjects[UIobjects.Count - 1].textPosX = 0;
        UIobjects[UIobjects.Count - 1].textPosY = 0;
        UIobjects[UIobjects.Count - 1].posX = prizeX;
        UIobjects[UIobjects.Count - 1].posY = prizeY;
        UIobjects[UIobjects.Count - 1].sizeX = prizeSizeX;
        UIobjects[UIobjects.Count - 1].sizeY = prizeSizeY;
    }

    // Update is called once per frame
    void Update()
    {
        date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        for (int i = 0; i < UIobjects.Count; i++)
        {
            UIobjects[i].SetPosition();
            //if mouse click in the area of the button call onClick
            if (Input.GetMouseButtonDown(0))
            {
                //mouse pos to UI object pos
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos = MousePointToCanvasPoint(mousePos);
                if (UIobjects[i].isButton)
                {
                    if (mousePos.x > UIobjects[i].posX - UIobjects[i].sizeX / 2 && mousePos.x < UIobjects[i].posX + UIobjects[i].sizeX / 2)
                    {
                        if (mousePos.y > UIobjects[i].posY - UIobjects[i].sizeY / 2 && mousePos.y < UIobjects[i].posY + UIobjects[i].sizeY / 2)
                        {
                            UIobjects[i].onClick();
                        }
                    }
                }
            }
        }
    }

    Prize roll() {
        float totalWeight = 0;
        foreach (Prize prize in prizes) {
            totalWeight += prize.chance;
        }
        float randomValue = Random.Range(0, totalWeight);
        float weightSum = 0;
        foreach (Prize prize in prizes) {
            weightSum += prize.chance;
            if (randomValue <= weightSum) {
                Logs.Add("[" + date + "] Prize = " + prize.name);
                setupPrize(prizes.IndexOf(prize));
                return prize;
            }
        }
        return prizes[prizes.Count - 1];
    }

    public void rollPub()
    {
        Prize prize = roll();
        
    }

    public void troll()
    {
        Debug.Log("troll");
    }

    Vector2 MousePointToCanvasPoint(Vector2 mousePos)
    {
        Vector2 canvasPos = new Vector2();
        canvasPos.x = mousePos.x * (Screen.width / 2) / 10;
        canvasPos.y = mousePos.y * (Screen.height / 2) / 5;
        return canvasPos;
    }
}
