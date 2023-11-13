using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUI : MonoBehaviour
{
    public static CharacterUI Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private SpriteRenderer portraitSpriteRenderer;
    [SerializeField] private Image healthBarImage;
    private Unit selectedUnit;
    private string cName;
    private int cHealth;
    private Sprite cPortrait;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Theres more than one CharacterUI! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCharacterUI(Unit unit){
        cPortrait=UnitData.UnitDataList[unit.classId].portrait;
        portraitSpriteRenderer.sprite=cPortrait;
        NameText.text=unit.GetName();
        healthBarImage.fillAmount=unit.GetComponent<HealthSystem>().GetHealthNormalized();
        HealthText.text=unit.GetComponent<HealthSystem>().getHealth().ToString()+" / "+unit.GetComponent<HealthSystem>().getHealthMax().ToString();
    }
}
