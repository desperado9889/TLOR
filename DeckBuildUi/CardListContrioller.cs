using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListContrioller : MonoBehaviour
{
    public static CardListContrioller instance;
    public int[] cId = new int[10];
    public int selectedUnitId;

    GameObject card;
    // Start is called before the first frame update
    void Awake(){
        if(CardListContrioller.instance == null) CardListContrioller.instance = this;
        selectedUnitId = 0;
    }
    void Start()
    {
        selectDeck(selectedUnitId);
    }
    public void selectDeck(int classId){
        for (int i = 0; i < 10; i++)
        {
            cId[i]=CardListData.Card[classId][i];
            card=this.transform.GetChild(i).gameObject;
            card.GetComponent<ThisCardUi>().thisId=cId[i];
        }
    }
}
