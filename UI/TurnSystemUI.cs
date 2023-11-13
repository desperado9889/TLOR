using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystemUI : MonoBehaviour
{
    public static TurnSystemUI Instance;
    [SerializeField] private Button endTurnBtn;
    [SerializeField] private TextMeshProUGUI turnNumberText;
    [SerializeField] private GameObject enemyTurnVisualGameObject;
    int?[,] SkillCard;
    int turn;
    public int previousTurn=1;
    public int[,] PreviousCards = new int[3, 10];
    public int[] pCardIndex = new int[6];
    public GameObject unitActionSystem;
    private List<Unit> UnitList;
    public bool action = false;
    Unit selectedUnit;
    private void Awake(){
        Instance=this;
        UnitList=UnitManager.Instance.GetUnitList();
    }
    private void Start()
    {
        endTurnBtn.onClick.AddListener(() => 
        {
            UiButtonController.instance.Onclick(); // Ui off
            TurnSystem.Instance.NextUp(); //속도 가장 빠른 유닛 행동  
            selectedUnit = TurnSystem.Instance.selectedUnit;
            SkillCard = ReadyButtonController.CardSet; // 배열에 저장한 카드 목록
            for(int i=0; i<2; i++){
                for(int j=0; j<6; j++){
                    Debug.Log("SkillCard["+i+","+j+"]: "+SkillCard[i,j]);
                }
            }
            StartCoroutine(DoCard(SkillCard)); // 저장한 스킬 메소드들 인수로 실행
        });

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged; //이벤트 핸들러에 함수 추가, OnTurnChanged: 턴이 바뀌면 수정되야할 조건을 담은 이벤트
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        UpdateTurnText();
        UpdateEnemyTurnVisual();    
    }
    private void UpdateTurnText()
    {
        turn=TurnSystem.Instance.GetTurnNumber();
        turnNumberText.text = "턴 " + turn;
    }

    private void UpdateEnemyTurnVisual()
    {
        enemyTurnVisualGameObject.SetActive(!TurnSystem.Instance.IsPlayerTurn());
    }

    public IEnumerator DoCard(int?[,] SkillCard){ // 메소드 순차 실행을 위한 coroutine 함수
        int turnsize=0;
        while(UnitList.Count>turnsize){ //Unit 사망, 소환 시 즉각 반영
            if(TurnSystem.Instance.IsPlayerTurn()){
                for(int i=0; i<6; i++){
                    if(SkillCard[selectedUnit.classId,i]!=null){
                        int j = (int)SkillCard[selectedUnit.classId,i];
                        Dragable.instance.CopyCardOn(j);
                        SkillData.skillList[j].DoSkill(selectedUnit);
                        yield return StartCoroutine(WaitForMouseClick()); //마우스 입력 기다림(무한루프)
                        yield return new WaitForSeconds(1.0f); //마우스 입력 후 1초 대기
                    }
                }
                Debug.Log("모든 메소드 실행 완료");
                for(int i=0; i<6; i++) // 카드 위치 초기화를 위한 반복문
                {
                    if(object.ReferenceEquals(SkillCard[selectedUnit.classId, i],null)){break;}
                    if(SkillCard[selectedUnit.classId, i]>0){ // 스킬카드인지 이동 카드인지 확인  
                        pCardIndex[i]=ReadyButtonController.CardIndex[selectedUnit.classId, i];
                        if(pCardIndex[i]!=11){
                            Debug.Log("pCardIndex["+i+"]"+pCardIndex[i]);
                            PreviousCards[selectedUnit.classId, pCardIndex[i]]=1;
                        }
                        SkillCard[selectedUnit.classId, i]=null;
                    }else{
                        Debug.Log("삭제됨");
                        GameObject.Find("MoveCard").GetComponent<Dragable2>().removeCard(); // 이동카드면 삭제
                    }
                }
            }
            else{
                yield return StartCoroutine(WaitForActionComplete());
                EnemyAI.Instance.SetActionComplete();
                //StopCoroutine(WaitForActionComplete());
                Debug.Log("적 행동 완료됨");
            }
            Debug.Log("다음 유닛으로");
            Debug.Log("턴 진행: "+turnsize+"/"+UnitList.Count);
            TurnSystem.Instance.NextUp();
            selectedUnit = TurnSystem.Instance.selectedUnit;
            turnsize++;
        }
    }

    IEnumerator WaitForMouseClick()// 마우스 입력을 기다리는 무한 루프
    {
        int count = 0;
        while (!action)
        {
            if(count == 0){
                Debug.Log("마우스 입력 대기");
                count ++;
            }   
            yield return null;
        }
        action = false;
    }
    
    IEnumerator WaitForActionComplete(){
        while (!EnemyAI.Instance.GetActionComplete()){ 
            //Debug.Log("적 행동 중");
            yield return null; 
        }
    }
    public int[,] getPreviousCards(){
        return PreviousCards;
    }
}
