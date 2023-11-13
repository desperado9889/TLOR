using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckListOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<10;i++){
            if(DeckList.instance.deckList[CardListContrioller.instance.selectedUnitId][i]==0){
                this.transform.GetChild(i).gameObject.SetActive(false);
            }else{
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
