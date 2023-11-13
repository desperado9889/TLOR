using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardData: MonoBehaviour{
public List<int?> figure=new List<int?> ();
public List<CardValue> cardList = new List<CardValue> ();
public static CardData instance;
   
   void Awake(){
      if(CardData.instance == null) CardData.instance=this;
    //카드 수치
    figure.Add(null);
    figure.Add(6);
    figure.Add(3);
    figure.Add(2);
    figure.Add(2);
    figure.Add(8);
    figure.Add(10);
    //int ClassId, int Id, string CardName, int ApCost, string CardDescription, Sprite ThisImage, Sprite ThisAtkType, int? Range, Sprite ThisRange
    cardList.Add(new CardValue(0, 0, "cardName", 0, "cardDescription", Resources.Load <Sprite>("CardSprite/0"), Resources.Load<Sprite>("RangeSprite/bow"), 0, Resources.Load<Sprite>("RangeSprite/8"),Resources.Load<Sprite>("CardFrame/FrameColor0")));
    cardList.Add(new CardValue(0, 1, "이동", 2, "이동합니다", Resources.Load <Sprite>("CardSprite/sprint"), Resources.Load<Sprite>("None"), null, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor0")));
    cardList.Add(new CardValue(0, 2, "베기", 1, "인접한 단일 대상에게 "+figure[1]+"의 데미지를 준다", Resources.Load <Sprite>("CardSprite/1"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor0")));
    cardList.Add(new CardValue(0, 3, "발포", 3, "사거리 내 단일 대상에게 "+figure[2]+"의 데미지를 준다", Resources.Load <Sprite>("CardSprite/2"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("RangeSprite/8"),Resources.Load<Sprite>("CardFrame/FrameColor0")));
    cardList.Add(new CardValue(0, 4, "힘 모으기", 1, "다음 공격은 "+figure[3]+"배의 데미지를 준다", Resources.Load <Sprite>("CardSprite/3"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("RangeSprite/2l"),Resources.Load<Sprite>("CardFrame/FrameColor0")));
    cardList.Add(new CardValue(0, 5, "모닥불", 2, "체력 "+figure[4]+"회복", Resources.Load <Sprite>("CardSprite/bonfire"), Resources.Load<Sprite>("None"), null, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor0")));
    cardList.Add(new CardValue(1, 6, "지팡이 타격", 1, "단일 대상에게 "+figure[1]+"의 데미지를 준다", Resources.Load <Sprite>("CardSprite/6"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor1")));
    cardList.Add(new CardValue(1, 7, "신성한 파괴", 3, "사거리 내의 장애물 하나를 파괴한다", Resources.Load <Sprite>("CardSprite/7"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor1")));
    cardList.Add(new CardValue(1, 8, "명상", 1, "다음 공격은 "+figure[3]+"배의 데미지를 준다", Resources.Load <Sprite>("CardSprite/8"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor1")));
    cardList.Add(new CardValue(1, 9, "불의 세례", 3, "단일 대상에게 "+figure[5]+"의 데미지를 준다", Resources.Load <Sprite>("CardSprite/9"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor1")));
    cardList.Add(new CardValue(1, 10, "썬더 콜링", 5, "범위 대상에게 "+figure[2]+"의 데미지를 주고 사거리 내의 장애물을 파괴한다", Resources.Load <Sprite>("CardSprite/10"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("RangeSprite/9"),Resources.Load<Sprite>("CardFrame/FrameColor1")));
    cardList.Add(new CardValue(2, 11, "사격", 1, "사거리 내 단일 대상에게 "+figure[2]+"의 데미지를 준다", Resources.Load <Sprite>("CardSprite/11"), Resources.Load<Sprite>("RangeSprite/bow"), 3, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor2")));
    cardList.Add(new CardValue(2, 12, "조준 사격", 2, "사거리 내 단일 대상에게 "+figure[1]+"의 데미지를 준다", Resources.Load <Sprite>("CardSprite/12"), Resources.Load<Sprite>("RangeSprite/bow"), 4, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor2")));
    cardList.Add(new CardValue(2, 13, "단검 베기", 1, "인접한 단일 대상에게 "+figure[1]+"의 데미지를 준다", Resources.Load <Sprite>("CardSprite/13"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor2")));
    cardList.Add(new CardValue(2, 14, "문 따기", 1, "잠겨있는 문을 연다", Resources.Load <Sprite>("CardSprite/14"), Resources.Load<Sprite>("RangeSprite/bow"), 1, Resources.Load<Sprite>("None"),Resources.Load<Sprite>("CardFrame/FrameColor2")));
   }
}
