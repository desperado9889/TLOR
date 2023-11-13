using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNumber : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMPro.TextMeshProUGUI numberUi;
    [SerializeField] GameObject deckList;
    public static CardNumber instance;
    public int totalNumber=10;
    public int number;
    // Update is called once per frame
    void Awake(){
        if(CardNumber.instance == null){    CardNumber.instance = this; }
    }
    void Update()
    {
        number = 0;
        for(int i=0;i<10;i++){
            if (deckList.transform.GetChild(i).gameObject.activeSelf){
                 number++;
            }
        }
        numberUi.text = totalNumber+"/"+number;
    }
}
