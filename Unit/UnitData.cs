using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    public static List<UnitInfo> UnitDataList = new List<UnitInfo> ();

    void Awake(){
        //int unitId, string unitName, Sprite portrait
        UnitDataList.Add(new UnitInfo(0,"Pirate", Resources.Load <Sprite>("Portrait/Pirate")));
        UnitDataList.Add(new UnitInfo(1,"Priest", Resources.Load <Sprite>("Portrait/Priest")));
        UnitDataList.Add(new UnitInfo(2,"Assasin", Resources.Load <Sprite>("Portrait/Assasin")));
        UnitDataList.Add(new UnitInfo(3,"Skeleton", Resources.Load <Sprite>("Portrait/skeleton_b")));
    }
}
