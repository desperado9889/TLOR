using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUIValue : MonoBehaviour
{
    private Unit selectedUnit;
    public int unitId;
    public string unitName;
    /*private int unitId;
    private string unitName;*/
    private Button speedUibutton;
    private void Start()
    {
        speedUibutton = GetComponent<Button>();
        speedUibutton.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        if(selectedUnit.isEnemy!=true){
            UnitActionSystem.Instance.SetSelectedUnit(selectedUnit);
        }
    }
    public void setUnit(Unit unit){
        selectedUnit=unit;
    }
    public void setUnitId(int id){
        unitId=id;
    }
    public int getUnitId(){
        return unitId;
    }
    public void setUnitName(string name){
        unitName=name;
    }
    public string getUnitName(){
        return unitName;
    }
}
