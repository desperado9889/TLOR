using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class ThisCardUi : MonoBehaviour
{
    public static ThisCardUi instance; //외부에서 스크립트에 접근하기 위한 인스턴스 객체
    public List<CardValue> thisCard = new List<CardValue>();
    public int thisId;
    public int classId;
    public int id;
    public string cardName;
    public int apCost;
    public string cardDescription;
    public int? range;
    public int order;
    public Sprite thisSprite;
    public Sprite atkTypeSprite;
    public Sprite rangeSprite;
    public Sprite cardFrameSprite;
    public Image cardFrameImage;
    public Image cardImage;
    public Image atkTypeImage;
    public Image rangeImage;
    
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI costTMP;
    public TextMeshProUGUI cardDescriptionTMP;
    public TextMeshProUGUI rangeTMP;
    [SerializeField] int index;
    [SerializeField] bool buttonState = true;
    public void Awake(){
        if(ThisCardUi.instance == null){ ThisCardUi.instance = this; } //인스턴스 객체 초기화
    }
    void Start()
    {
        thisCard[0]=CardData.instance.cardList[thisId];
        setText();
    }

    void Update()
    {
        thisCard[0]=CardData.instance.cardList[thisId];
        if(CardListData.instance.Used[CardListContrioller.instance.selectedUnitId][index] ==1){
            buttonState = false;
        }else{
            buttonState = true;
        }
        buttonOnOff(buttonState);
        setText();
    }
    void setText(){
        classId=thisCard[0].classId;
        id=thisCard[0].id;
        cardName=thisCard[0].cardName;
        apCost=thisCard[0].apCost;
        cardDescription=thisCard[0].cardDescription;
        range=thisCard[0].range;
        thisSprite = thisCard[0].thisImage;
        atkTypeSprite = thisCard[0].thisAtkType;
        rangeSprite = thisCard[0].thisRange;
        cardFrameSprite = thisCard[0].thisFrame;

        nameTMP.text=""+cardName;
        costTMP.text=""+apCost;
        cardDescriptionTMP.text=""+cardDescription;
        rangeTMP.text=""+range;
        
        cardFrameImage.sprite = cardFrameSprite;
        cardImage.sprite=thisSprite;
        atkTypeImage.sprite=atkTypeSprite;
        rangeImage.sprite=rangeSprite;
    }
    public void Onclick(){
        for(int i=0;i<10;i++){
            if(DeckList.instance.deckList[CardListContrioller.instance.selectedUnitId][i]==0){
                DeckList.instance.deckList[CardListContrioller.instance.selectedUnitId][i]=id;
                CardListData.instance.Used[CardListContrioller.instance.selectedUnitId][index] = 1;
                CardListData.instance.UsedIndex[CardListContrioller.instance.selectedUnitId][i] = index;
                return;
            }
        }
        
    }
    public void buttonOnOff(bool state){
        this.gameObject.GetComponent<Button>().interactable = state;
    }
}