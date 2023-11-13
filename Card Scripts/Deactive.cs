using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactive : MonoBehaviour
{
    public Material[] material;
    Material[] FrameMaterial;
    public bool used;
    public int classId;
    void Start()
    {
        FrameMaterial=this.GetComponent<Renderer>().materials;
        FrameMaterial[1]=material[1];
        this.GetComponent<Renderer>().materials=FrameMaterial;
    }

    public void isUsed(bool used){
        if(used==true){
            FrameMaterial[1]=material[5];
        }
        else{
            classId= UnitActionSystem.Instance.selectedUnit.classId;
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
        }
        this.GetComponent<Renderer>().materials=FrameMaterial;
    }
}
