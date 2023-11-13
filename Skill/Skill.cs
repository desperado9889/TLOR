using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Skill
{
    public int skillClassId;
    public string skillName;
    public int skillId;
    public int skillDamage;
    public int skillCost;
    
    public Skill(int cId, string name, int id, int damage, int cost){
        skillClassId = cId;
        skillName = name;
        skillId = id;
        skillDamage = damage;
        skillCost = cost;
    }
    public void DoSkill(Unit skUnit){
        
        Debug.Log(skillClassId + skillName);
        if(skillId == 5){
            skUnit.GetComponent<HealthSystem>().heal(skillDamage);
            skUnit.GetComponent<Unit>().SpendActionPoints(skillCost); //코스트 사용
        }
        if(skillId == 2){
            UnitActionSystem.Instance.SetSelectedAction(skUnit.GetComponent<Unit>().GetAction<SwordAction>());
            skUnit.GetComponent<Unit>().SpendActionPoints(skillCost); //코스트 사용
            Debug.Log(skillName+"!");
        }
        if(skillId == 3){
            UnitActionSystem.Instance.SetSelectedAction(skUnit.GetComponent<Unit>().GetAction<ShootAction>());
            skUnit.GetComponent<Unit>().SpendActionPoints(skillCost); //코스트 사용
            Debug.Log(skillName+"!");
        }
        if(skillId == 10){
            UnitActionSystem.Instance.SetSelectedAction(skUnit.GetComponent<Unit>().GetAction<GrenadeAction>());
            skUnit.GetComponent<Unit>().SpendActionPoints(skillCost); //코스트 사용
            Debug.Log(skillName+"!");
        }
        if(skillId == 13){
            UnitActionSystem.Instance.SetSelectedAction(skUnit.GetComponent<Unit>().GetAction<SwordAction>());
            skUnit.GetComponent<Unit>().SpendActionPoints(skillCost); //코스트 사용
            Debug.Log(skillName+"!");
        }
        if(skillId == 14){
            UnitActionSystem.Instance.SetSelectedAction(skUnit.GetComponent<Unit>().GetAction<InteractAction>());
            skUnit.GetComponent<Unit>().SpendActionPoints(skillCost); //코스트 사용
            Debug.Log(skillName+"!");
        }
        else if(skillId == 1){
            UnitActionSystem.Instance.SetSelectedAction(skUnit.GetComponent<Unit>().GetAction<MoveAction>());
            skUnit.GetComponent<Unit>().SpendActionPoints(skillCost); //코스트 사용
        }
        
    }
}
