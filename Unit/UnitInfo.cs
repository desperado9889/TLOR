using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]

public class UnitInfo
{
    public int unitId;
    public string unitName;
    public Sprite portrait;
    
    public UnitInfo(int UnitId, string UnitName, Sprite Portrait){
        unitId=UnitId;
        unitName=UnitName;
        portrait=Portrait;
    }
}
