using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class ThisCard : MonoBehaviour
{
    public static ThisCard instance; //외부에서 스크립트에 접근하기 위한 인스턴스 객체
    public List<CardValue> thisCard = new List<CardValue>();
    public GameObject[] players;
    public GameObject CardUnit;
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
    public SpriteRenderer cardSpriteRenderer;
    public SpriteRenderer atkTypeSpriteRenderer;
    public SpriteRenderer rangeSpriteRenderer;

    public TextMeshPro nameTMP;
    public TextMeshPro costTMP;
    public TextMeshPro cardDescriptionTMP;
    public TextMeshPro rangeTMP;
    MoveAction moveAction;
    public void Awake()
    {
        if (ThisCard.instance == null) { ThisCard.instance = this; } //인스턴스 객체 초기화
    }
    void Start()
    {
        thisCard[0] = CardData.instance.cardList[thisId];
        players = GameObject.FindGameObjectsWithTag("Player"); //Player태그를 가진 오브젝트 가져오기
    }

    void Update()
    {
        thisCard[0] = CardData.instance.cardList[thisId];
        setText();
    }
    void setText()
    {
        foreach (GameObject obj in players)
        {
            if (obj != null)
            {
                Unit unit = obj.GetComponent<Unit>(); // Unit 컴포넌트를 가져옴
                if (unit != null && unit.classId == thisCard[0].classId) // 직업코드가 같은 오브젝트 찾기
                {
                    CardUnit = obj;
                }
            }
        }
        classId = thisCard[0].classId;
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        apCost = thisCard[0].apCost;
        cardDescription = thisCard[0].cardDescription;
        range = thisCard[0].range;
        thisSprite = thisCard[0].thisImage;
        atkTypeSprite = thisCard[0].thisAtkType;
        rangeSprite = thisCard[0].thisRange;

        nameTMP.text = "" + cardName;
        costTMP.text = "" + apCost;
        cardDescriptionTMP.text = "" + cardDescription;
        rangeTMP.text = "" + range;

        cardSpriteRenderer.sprite = thisSprite;
        atkTypeSpriteRenderer.sprite = atkTypeSprite;
        rangeSpriteRenderer.sprite = rangeSprite;
    }
    public void skill()
    {
        UnitActionSystem.Instance.SetSelectedAction(CardUnit.GetComponent<Unit>().GetAction<ShootAction>());
        Debug.Log(this.name + " ap: " + this.apCost);
        Debug.Log("CardUnit: " + CardUnit);
        CardUnit.GetComponent<Unit>().SpendActionPoints(this.apCost);
    }

    public void move()
    {
        UnitActionSystem.Instance.SetSelectedAction(CardUnit.GetComponent<Unit>().GetAction<MoveAction>());
        CardUnit.GetComponent<Unit>().SpendActionPoints(this.apCost);
    }

}