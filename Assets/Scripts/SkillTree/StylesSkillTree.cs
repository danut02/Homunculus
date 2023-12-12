using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StylesSkillTree : MonoBehaviour
{
    public static StylesSkillTree skillTree = null;

    private void Awake()
    {
        if (skillTree == null)
        {
            skillTree = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (skillTree != this)
        {
            Destroy(gameObject);
        }
    }

    // public int[] SkillLevels;
    // public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;
    public int[] SkillCosts;
    public bool[] isUnlocked;
    
    public List<StylesSkill> SkillList;
    public GameObject SkillHolder;
    
    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    private void Start()
    {
        
        SkillNames = new[]
        {
            "Boxing", "Kickboxing",
            "Karate", "MuayThai",
            "Freestyle"
        };

        SkillDescriptions = new[]
        {"Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva"
            
        };
        
        SkillCosts = new[]
        { 2, 2, 2, 2, 2
        };
        
        isUnlocked = new[] { false, false, false, false, false };

        foreach (var skill in SkillHolder.GetComponentsInChildren<StylesSkill>())
        {
            SkillList.Add(skill);
        }

        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>())
        {
            ConnectorList.Add(connector.gameObject);
        }
        for (var i = 0; i < SkillList.Count; i++)
            SkillList[i].id = i;

        SkillList[0].ConnectedSkills = new[] { 1, 2 };
        SkillList[1].ConnectedSkills = new[] { 3 };
        SkillList[2].ConnectedSkills = new[] { 3 };
        SkillList[3].ConnectedSkills = new[] {4 };
        if (!Player.Instance.getNewGame())
        {
            PlayerData data = SaveSystem.LoadPlayer();
            if (data.stylesSkillTreeUnlockingVector != null)
            {
                for (var i = 0; i < data.stylesSkillTreeUnlockingVector.Length; i++)
                {
                    isUnlocked[i] = data.stylesSkillTreeUnlockingVector[i];
                }
            }
        }

        StylesUpdateAllUI();
    }

    public void StylesUpdateAllUI()
    {
        foreach (var skill in SkillList)
        {
            skill.UpdateUI();
        }
    }
}
