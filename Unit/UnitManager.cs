using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }

    private List<Unit> unitList;
    private List<Unit> friendlyUnitList;
    private List<Unit> enemyUnitList;
    private List<Unit> listToRemove;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Theres more than one UnitManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        listToRemove = new List<Unit>();
        unitList = new List<Unit>();
        friendlyUnitList = new List<Unit>();
        enemyUnitList = new List<Unit>();
    }

    private void Start()
    {
        Unit.OnAnyUnitSpawned += Unit_OnAnyUnitSpawned;
        Unit.OnAnyUnitDead += Unit_OnAnyUnitDead;
    }

    private void Unit_OnAnyUnitSpawned(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;
        Debug.Log(unit + "is spawned");
        unitList.Add(unit);
        TurnSystem.Instance.SpawnedSpeedList(unit);
        SpeedUIManager.Instance.SpawnSpeedUI(unit);
        if (unit.IsEnemy())
        {
            enemyUnitList.Add(unit);
        }
        else
        {
            friendlyUnitList.Add(unit);
        }
    }

    private void Unit_OnAnyUnitDead(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;
        Debug.Log(unit + " is Dead");
        SpeedUIManager.Instance.DeadSpeedUI(unit);
        //unitList.Remove(unit);
        //TurnSystem.Instance.DeadSpeedList(unit);
        //SpeedUI.GetComponent<SpeedUI>().UpdateSpeedUI();
        listToRemove.Add(unit);
        if (unit.IsEnemy())
        {
            enemyUnitList.Remove(unit);
        }
        else
        {
            friendlyUnitList.Remove(unit);
        }
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }
    public List<Unit> GetFriendlyUnitList()
    {
        return friendlyUnitList;
    }

    public List<Unit> GetEnemyUnitList()
    {
        return enemyUnitList;
    }

    public void ClearUnitList(){
        foreach (Unit enemy in listToRemove){
            unitList.Remove(enemy);
        }
        listToRemove.Clear();
    }
}
