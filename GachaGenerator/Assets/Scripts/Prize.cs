using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Prize
{
    public string name;
    public Sprite image;
    public int chance;
    public string id;

    public Prize(string name, Sprite image, int chance, string id)
    {
        this.name = name;
        this.image = image;
        this.chance = chance;
        this.id = id;
    }
}
