using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckList : MonoBehaviour
{
    // Start is called before the first frame update
    public static DeckList instance;
    public int[][] deckList=new int[3][];
    void Awake(){
        if(DeckList.instance ==null) DeckList.instance = this;
        for(int i=0;i<3;i++){
            if(!PlayerPrefs.HasKey("DeckList"+i)){
                        deckList[i]=new int[] { 0,0,0,0,0,0,0,0,0,0};
            }else{
                LoadIntArray();
            }
        }


    }
    public void SaveIntArray()
    {
        for(int i=0;i<3;i++){
        string json = JsonUtility.ToJson(new IntArrayWrapper(deckList[i]));
        PlayerPrefs.SetString("DeckList"+i, json);
        PlayerPrefs.Save(); // PlayerPrefs 변경 사항을 저장
        }
    }
    // PlayerPrefs에서 JSON 문자열을 가져와 int 배열로 역직렬화
    public void LoadIntArray()
    {
        for(int i=0;i<3;i++){
            if (PlayerPrefs.HasKey("DeckList"+i))
            {
                string json = PlayerPrefs.GetString("DeckList"+i);
                IntArrayWrapper wrapper = JsonUtility.FromJson<IntArrayWrapper>(json);
                deckList[i] = wrapper.array;
            }
        }
    }
    public void sortDeckList(int classId){
        
    }

}
[System.Serializable]
public class IntArrayWrapper
{
    public int[] array;

    public IntArrayWrapper(int[] arr)
    {
            array = arr;
    }
}

