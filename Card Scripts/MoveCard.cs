using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class MoveCard : MonoBehaviour
{
    List<CardValue> thisCard = new List<CardValue>();
    GameObject CardUnit;
    public int thisId;
    int id;
    string cardName;
    int Damage;
    int apCost;
    string cardDescription;
    
    Sprite thisSprite;
    Image thatImage;
    SpriteRenderer spriteRenderer;

    TextMeshPro nameTMP;
    TextMeshPro costTMP;
    TextMeshPro cardDescriptionTMP;
    void Start()
    {
        thisCard[0]=CardData.instance.cardList[thisId];
        CardUnit = GameObject.Find("Worrior");
    }

    // Update is called once per frame
    void Update()
    {
        setText();
    }
    void setText(){
        id=thisCard[0].id;
        cardName=thisCard[0].cardName;
        apCost=thisCard[0].apCost;
        cardDescription=thisCard[0].cardDescription;
        thisSprite = thisCard[0].thisImage;

        nameTMP.text=""+cardName;
        costTMP.text=""+apCost;
        cardDescriptionTMP.text=""+cardDescription;
        
        //thatImage.sprite=thisSprite;
        spriteRenderer.sprite=thisSprite;
    }
     public void skill(){
        GameObject Unit = GameObject.Find("Worrior");
        Debug.Log("현재 유닛의 위치 : " + CardUnit.GetComponent<Unit>().GetGridPosition());
    }

}