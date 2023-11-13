using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTrans : MonoBehaviour
{
    public Material[] material;
    Material[] FrameMaterial;
    public int classId;
    void Start()
    {
        FrameMaterial=this.GetComponent<Renderer>().materials;
        FrameMaterial[1]=material[2];
        this.GetComponent<Renderer>().materials=FrameMaterial;
    }
    public void changeCopyMarterial(){
        classId = UnitActionSystem.Instance.selectedUnit.classId;
        switch (classId){
            case 0:
                FrameMaterial[1]=material[1];
                break;
            case 1:
                FrameMaterial[1]=material[2];
                break;
            case 2:
                FrameMaterial[1]=material[3];
                break;
        }   
        this.GetComponent<Renderer>().materials=FrameMaterial;
    }
}
