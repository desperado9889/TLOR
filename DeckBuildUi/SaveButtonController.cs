using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject NumberExceptionUi;
    void Start(){
        NumberExceptionUi.SetActive(false);
    }
    public void Onclick(){
        if(CardNumber.instance.totalNumber > CardNumber.instance.number && CardNumber.instance.number>0){
           StartCoroutine(ShowAndHideText());
           return;
        }
        DeckList.instance.SaveIntArray();
        CardListData.instance.SaveUsed();
        CardListData.instance.SaveUsedIndex();
    }
    IEnumerator ShowAndHideText()
    {
        NumberExceptionUi.SetActive(true);
        yield return new WaitForSeconds(2f);
        NumberExceptionUi.SetActive(false);
    }
}
