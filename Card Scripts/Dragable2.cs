using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable2 : MonoBehaviour
{
    private GameObject copyCard;
    void Start(){
        copyCard = Dragable.instance.copyCard;
    }
    private void OnMouseEnter(){ // 카드에 마우스 오버시 
            copyCard.SetActive(true);
            copyCard.GetComponent<ThisCard>().thisId = this.GetComponent<ThisCard>().thisId;
    }
    private void OnMouseExit(){ 
            copyCard.SetActive(false);

    }
    private void OnMouseDown(){
        Destroy(gameObject);
     //gameObject.SetActive(false); 
    }
    public void removeCard(){
        Destroy(gameObject);
    }
}
