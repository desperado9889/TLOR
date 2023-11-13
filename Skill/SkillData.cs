using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : MonoBehaviour
{
    public static List<Skill> skillList = new();
    
    void Awake(){   //int cId, string name, int id, int damage, int cost
        skillList.Add(new Skill(0,"skillName",0,0,0));
        skillList.Add(new Skill(0,"이동",1,0,2));
        skillList.Add(new Skill(0,"베기",2,6,1));
        skillList.Add(new Skill(0,"회전베기",3,3,3));
        skillList.Add(new Skill(0,"힘 모으기",4,0,2));
        skillList.Add(new Skill(0,"모닥불",5,0,2));
        skillList.Add(new Skill(1,"지팡이 타격",6,6,1));
        skillList.Add(new Skill(1,"신성한 파괴",7,0,3));
        skillList.Add(new Skill(1,"명상",8,0,1));
        skillList.Add(new Skill(1,"불의 세례",9,8,3));
        skillList.Add(new Skill(1,"파이어 볼",10,3,4));
        skillList.Add(new Skill(2,"사격",11,3,1));
        skillList.Add(new Skill(2,"조준 사격",12,6,2));
        skillList.Add(new Skill(2,"단검베기 ",13,6,1));
        skillList.Add(new Skill(2,"정조준",14,0,1));
    }
}
