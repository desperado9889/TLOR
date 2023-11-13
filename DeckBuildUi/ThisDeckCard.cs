using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThisDeckCard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int id;
    [SerializeField] TextMeshProUGUI Cost;
    [SerializeField] TextMeshProUGUI CardName;
    int apCost;
    string cardName;
    // Update is called once per frame
    void Update()
    {
        if(DeckList.instance.deckList[CardListContrioller.instance.selectedUnitId][id]!=0){
            this.apCost = CardData.instance.cardList[DeckList.instance.deckList[CardListContrioller.instance.selectedUnitId][id]].apCost;
            this.cardName = CardData.instance.cardList[DeckList.instance.deckList[CardListContrioller.instance.selectedUnitId][id]].cardName;

            Cost.text = apCost.ToString();
            CardName.text = cardName;
        }
        else{
            
        }
    }
    public void Onclick(){
        int i = CardListData.instance.UsedIndex[CardListContrioller.instance.selectedUnitId][id];
        DeckList.instance.deckList[CardListContrioller.instance.selectedUnitId][id]=0;
        CardListData.instance.Used[CardListContrioller.instance.selectedUnitId][i]=0;
        CardListData.instance.UsedIndex[CardListContrioller.instance.selectedUnitId][id] = 0;
    }
}
