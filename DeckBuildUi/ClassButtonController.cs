using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int CardListId;
    public void Onclick(){
        CardListContrioller.instance.selectedUnitId = CardListId;
        CardListContrioller.instance.selectDeck(CardListId);
    }
}
