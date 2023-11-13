using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public static Dragable instance;
     Vector3 mousePosition; // 마우스 포지션
     Vector3 CardPosition; // 드래그 전 카드의 포지션
     Vector3 MovePosition;
    public bool CardDrag=false; // 카드 드래그 여부
    public RaycastHit hit; // 레이캐스트 객체
    public float MaxDistance = 5.0f;  // 레이캐스트 최대 거리(레이저 거리)
    public GameObject copyCard; // 확대할 카드 객체
    private GameObject hand; // 핸드존 객체
    private Transform myParents;
    public Transform p; // 카드의 부모 객체
    //[SerializeField] GameObject frame;
    int count = 0;
    void Awake(){
        CardPosition = transform.localPosition;
        // 카드의 초기 위치 저장
        myParents = this.transform.parent;
        hand = GameObject.Find("HandZone");
        copyCard = GameObject.Find("CopyCard");
    }
    void Start(){
      if(Dragable.instance == null){
            Dragable.instance = this;
        } 
        Physics.Raycast(transform.position,transform.forward,out hit, MaxDistance); // 레이캐스트 시작
        copyCard.SetActive(false);
        p=hand.transform; 
        //frame.GetComponent<Outline>().OnDisable();
    }
    void Update(){
        CardDrag=false;
    }
    private Vector3 GetMousePos(){
        return Camera.main.WorldToScreenPoint(transform.position); //게임속 마우스 포인트 가져옴
    }
    private void OnMouseDown(){
        if(this.enabled==true){
            Vector3 mouseOverPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,transform.localPosition.z); // 객체 확대 벡터 저장(클릭시 들어올리기)
            if(transform.parent.name.StartsWith("Table")){
                mouseOverPosition.y += 1.0f;
            }
            else{
                mouseOverPosition.z -= 1.0f;
            }
            transform.localPosition = mouseOverPosition; //카드의 포지션 변경
            mousePosition = Input.mousePosition -GetMousePos(); // 동시에 드래그시 움직일 좌표 가져오기
        }
    }
    public void OnMouseDrag(){ // 카드 드래그
        if(this.enabled==true){
            CardDrag = true; 
            Vector3 movePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition); 
            transform.position = movePosition;
        }
    }
    private void OnMouseEnter(){ // 카드에 마우스 오버시 
         if(!CardDrag&&count==0){
            copyCard.SetActive(true);
            copyCard.GetComponent<ThisCard>().thisId = this.GetComponent<ThisCard>().thisId;
            //frame.GetComponent<Outline>().OnEnable();
         }
    }
    private void OnMouseExit(){ 
        copyCard.SetActive(false);
        //frame.GetComponent<Outline>().OnDisable();
    }
    private void OnMouseUp(){
        if(Physics.Raycast(transform.position,transform.forward,out hit, MaxDistance)){ // 레이저랑 충돌한 객체가 있을 시
            if(hit.collider.name.StartsWith("TableF")){ // 충돌한 객체의 이름이 table or C_Table로 시작하는지
                    p = hit.transform;
                    transform.SetParent(p); // 카드의 부모객체를 충돌한 객체로 변경 
                    MovePosition = new Vector3(0,0,0);
            }else if(hit.collider.name.StartsWith("Card")&&hit.collider.transform.parent.name.StartsWith("TableF")){ // 내려놓을 테이블에 카드가 있을 경우
                    changeParent(this.transform,hit.transform); // 두 카드 테이블 변경(카드 스왑)
            }else{
                    // 카드의 부모객체를 충돌한 객체로 변경 
                    p = myParents;
                    transform.SetParent(p);
                    MovePosition = CardPosition; // 카드의 원래 포지션을 부모 포지션으로 변경
            }
        }
        else{
            p=myParents;
            transform.SetParent(myParents);
            MovePosition = CardPosition;
        }
        transform.localPosition = MovePosition;
    }
    public void changeParent(Transform c1, Transform c2){
        Transform tempParent;
        
        tempParent = c1.parent;
        c1.SetParent(c2.parent);
        c2.SetParent(tempParent);

        c1.transform.localPosition = new Vector3(0,0,0);
        c2.transform.localPosition = new Vector3(0,0,0);

    }
    public void ResetCardPosition(){
        transform.SetParent(hand.transform);
        transform.localPosition = CardPosition;
    }
    public void CopyCardOn(int cardId){
        copyCard.GetComponent<ThisCard>().thisId = cardId;
        copyCard.SetActive(true);  
    }
    public void CopyCardOff(){
        copyCard.SetActive(false);
    }
}