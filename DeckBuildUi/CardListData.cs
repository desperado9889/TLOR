using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListData : MonoBehaviour
{
    public static CardListData instance;
    public static int[][] Card;
    public int[][] Used = new int[3][];
    public int[][] UsedIndex = new int[3][];
    void Awake(){
        if(CardListData.instance ==null) CardListData.instance = this;
        Card = new int[3][]
        {
            new int[] {2, 2, 2, 3, 3, 3, 4, 4, 5, 5},
            new int[] {6, 6, 6, 7, 7, 8, 8, 9, 9, 10},
            new int[] {11, 11, 11, 12, 12, 12, 13, 13, 14, 14}
        };
        
        for(int i=0;i<3;i++){
            if(!PlayerPrefs.HasKey("State"+i)){
                Used[i] = new int[] {0,0,0,0,0,0,0,0,0,0};
            }else{
                LoadUsed();
            }
            if(!PlayerPrefs.HasKey("Index"+i)){
                UsedIndex[i] = new int[] {0,0,0,0,0,0,0,0,0,0};
            }else{
                LoadUsedIndex();
            }
        }
        

    }
    // Start is called before the first frame update
    public void SaveUsed()
    {
        for(int i=0;i<3;i++){
        string json = JsonUtility.ToJson(new IntArrayWrapper(Used[i]));
        PlayerPrefs.SetString("State"+i, json);
        PlayerPrefs.Save(); // PlayerPrefs 변경 사항을 저장
        }
    }
    public void SaveUsedIndex()
    {
        for(int i=0;i<3;i++){
        string json2 = JsonUtility.ToJson(new IntArrayWrapper(UsedIndex[i]));
        PlayerPrefs.SetString("Index"+i, json2);
        PlayerPrefs.Save(); // PlayerPrefs 변경 사항을 저장
        }
    }
    // PlayerPrefs에서 JSON 문자열을 가져와 int 배열로 역직렬화
    public void LoadUsed()
    {
        for(int i=0;i<3;i++){
            if (PlayerPrefs.HasKey("State"+i))
            {
                string json = PlayerPrefs.GetString("State"+i);
                IntArrayWrapper wrapper = JsonUtility.FromJson<IntArrayWrapper>(json);
                Used[i] = wrapper.array;
            }

        }
    }
    public void LoadUsedIndex()
    {
        for(int i=0;i<3;i++){
            if (PlayerPrefs.HasKey("Index"+i))
            {
                string json2 = PlayerPrefs.GetString("Index"+i);
                IntArrayWrapper wrapper2 = JsonUtility.FromJson<IntArrayWrapper>(json2);
                UsedIndex[i] = wrapper2.array;
            }

        }
    }
    public void sortDeckList(int classId){
        
    }

}

