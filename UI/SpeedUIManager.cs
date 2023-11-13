using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUIManager : MonoBehaviour
{
    public static SpeedUIManager Instance { get; private set; }
    public GameObject speedUIPrefab;
    public List<Unit> SuList;
    public SpeedUIValue[] speedUIs;
    public int thisId;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Theres more than one SpeedUIManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public void SpawnSpeedUI(Unit unit)
    {
        Unit selectedUnit = unit; 
        for(int i=0; i<UnitData.UnitDataList.Count; i++){
            if(unit.classId==UnitData.UnitDataList[i].unitId){
                GameObject speedUI = Instantiate(speedUIPrefab, this.transform);
                speedUI.name=selectedUnit.name+"SpeedUI";
                SpeedUIValue speedUIValue = speedUI.GetComponent<SpeedUIValue>();
                speedUIValue.setUnit(unit);
                Debug.Log(unit);
                speedUIValue.setUnitId(unit.classId);
                speedUIValue.setUnitName(unit.name);
                Transform unitImage = speedUI.transform.Find("UnitImage"); 
                speedUI.transform.Find("StatusAbnormality").gameObject.SetActive(false);
                SpriteRenderer unitPortrait = unitImage.GetComponent<SpriteRenderer>();
                if (unitPortrait != null)
                {
                    unitPortrait.sprite = UnitData.UnitDataList[i].portrait;
                }
                else{
                    Debug.Log("Sprite is Missing");
                }
            }
        }
        speedUIs = FindObjectsOfType<SpeedUIValue>();
    }

    public void UpdateSpeedUI(){
        SuList=TurnSystem.Instance.SpeedList;  
        for(int i=0; i<SuList.Count; i++){
            for(int j=0; j<speedUIs.Length; j++){
                if(SuList[i].classId==speedUIs[j].getUnitId()){
                    if(speedUIs[i]!=null){
                        speedUIs[j].transform.SetSiblingIndex(i);
                    }
                    break;
                }
            }
        }
    }

    public void DeadSpeedUI(Unit unit)
    {
        Unit selectedUnit = unit;
        foreach (SpeedUIValue speedUI in speedUIs)
        {
            if (speedUI.getUnitId() == unit.classId && speedUI.getUnitName()==unit.name)
            {
                Destroy(speedUI.gameObject);
            }
        }
    }
}
