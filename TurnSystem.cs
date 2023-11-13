using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance { get; private set; }
    GameObject[] Enemy=new GameObject[6];
    public event EventHandler OnTurnChanged;
    int enemyCount;
    int i=0;
    private int turnNumber = 1;
    private bool isPlayerTurn = true;
    private List<Unit> ulist;
    public List<Unit> SpeedList;
    public GameObject SpeedUI;
    private int num;
    public Unit selectedUnit;
    public Unit selectedEnemy;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Theres more than one TurnSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        ulist=UnitManager.Instance.GetUnitList();
    }
    private void Start(){
        StartCoroutine(speedSort(ulist)); //최초 실행 시 UI 초기화 용
        SpeedUIManager.Instance.UpdateSpeedUI();
    }
    public void NextUp(){
        Debug.Log("리스트 "+i+"번");
        if(i>=SpeedList.Count){
            i=0;
            Debug.Log("Reset");
            NextTurn();
        }
        else if(SpeedList[i]==null){
            Debug.Log("해당 유닛은 죽었습니다");
            i++;
            NextUp();
        }
        else if(SpeedList[i].isEnemy){
            isPlayerTurn=false; 
            Debug.Log(SpeedList[i]+"is player?: "+isPlayerTurn);
            selectedEnemy=SpeedList[i];
            i++;
        }
        else {
            isPlayerTurn=true;
            Debug.Log(SpeedList[i]+"is player?: "+isPlayerTurn);
            selectedUnit=SpeedList[i];
            Debug.Log("선택된 유닛: "+selectedUnit);
            SkipButtonController.Instance.skButtonOn();
            UnitActionSystem.Instance.transferSelect(selectedUnit);
            i++;
        }
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }
    public void NextTurn()
    {
        turnNumber++;
        UnitManager.Instance.ClearUnitList();
        StartCoroutine(speedSort(ulist));
        SpeedUIManager.Instance.UpdateSpeedUI();
        isPlayerTurn = true; //잠재적 위험요소
        UiButtonController.instance.Onclick();
        HandController.instance.resetHandPosition(selectedUnit);
        //UnitActionSystem.Instance.SetSelectedAction(selectedUnit.GetMoveAction());
        Enemy=GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemy!=null){
            for(int enemyCount=0; enemyCount<Enemy.Length; enemyCount++){
                Enemy[enemyCount]=null;
            }
        }
        if(Enemy==null || Enemy.Length == 0){ //전투 종료 조건
            Invoke("ending",2.5f);
        }
    }
    public void ending(){
        SceneManager.LoadSceneAsync(4);
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    public IEnumerator speedSort(List<Unit> ulist){
        SpeedList=ulist.OrderByDescending(x=>x.speed).ToList();  //정렬 내림차순
        for(num=0; num<SpeedList.Count-1; num++){
            if(SpeedList[num].speed==SpeedList[num+1].speed){   //속도가 동일할 경우
                int s1=Random.Range(1,7);   //1D6 다이스
                int s2;
                Debug.Log(s1);
                do
                {
                    s2=Random.Range(1,7);
                    Debug.Log(s2);
                } while (s1==s2);   //중복됐을 시 다시 굴림

                if(s1>s2){  
                    (SpeedList[num], SpeedList[num+1]) = (SpeedList[num+1], SpeedList[num]);  //Swap
                }
            }
        }
        for(int i=0; i<SpeedList.Count; i++){
                    Debug.Log("SpeedList["+i+"]: "+SpeedList[i]);
        }
        yield return null;
    }

    public Unit GetSelectedEnemy(){
        return selectedEnemy;
    }
    public void SpawnedSpeedList(Unit unit){    //유닛 소환되면 리스트 맨 끝에 추가
        SpeedList.Add(unit);
    }
    public void DeadSpeedList(Unit unit){   //유닛 죽으면 리스트에서 제거
        //SpeedList.Remove(unit);  
    }
}