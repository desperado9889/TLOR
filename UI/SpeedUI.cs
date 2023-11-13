using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedUI : MonoBehaviour
{
    public static SpeedUI Instance { get; private set; }
    List<Unit> SuList;
    [SerializeField] private TextMeshProUGUI SpeedText;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Theres more than one TurnSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void UpdateSpeedUI()
    {   
        SpeedText.text="";
        SuList=TurnSystem.Instance.SpeedList;
        Debug.Log("실행");
        for(int i=0; i<SuList.Count; i++){
            if(SuList[i]!=null){
                SpeedText.text+=SuList[i].ToString().Replace("(Unit)","")+"\n";
            }
        }
    }
}
