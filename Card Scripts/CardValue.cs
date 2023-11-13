using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]

public class CardValue
{
    public int classId;
    public int id;
    public string cardName;
    public int apCost;
    public string cardDescription;
    public int? range;
    public Sprite thisImage;
    public Sprite thisAtkType;
    public Sprite thisRange;
    public Sprite thisFrame;
    public CardValue(int ClassId, int Id, string CardName, int ApCost, string CardDescription, Sprite ThisImage, Sprite ThisAtkType, int? Range, Sprite ThisRange, Sprite ThisFrame){
        classId = ClassId;
        id=Id;
        cardName=CardName;
        apCost=ApCost;
        cardDescription=CardDescription;
        thisImage = ThisImage;
        thisAtkType=ThisAtkType;
        range=Range;
        thisRange=ThisRange;
        thisFrame = ThisFrame;
    }
}
