using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveDefenseEscapeSkillTree : MonoBehaviour
{
    public static OffensiveDefenseEscapeSkillTree skillTree;
    private void Awake() => skillTree = this;

    // public int[] SkillLevels;
    // public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;
    public int[] SkillCosts;
    public bool[] isUnlocked;
    
    public List<OffensiveDefenseEscapeSkill> SkillList;
    public GameObject SkillHolder;
    
    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;
    

    private void Start()
    {
        
        SkillNames = new[]
        {
            "Guard Break", "Suplex Break",
            "Choke Break", "Disarm",
            "Weapon Catch", "Weapon Break"
        };

        SkillDescriptions = new[]
        {"Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva"
        };
        
        SkillCosts = new[]
        { 2, 2, 2, 2, 2, 2
        };

        isUnlocked = new[]
        { false, false, false, false, false, false
        };
        
        foreach (var skill in SkillHolder.GetComponentsInChildren<OffensiveDefenseEscapeSkill>())
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
        SkillList[3].ConnectedSkills = new[] { 4 };
        SkillList[4].ConnectedSkills = new[] { 5 };
        if (!Player.Instance.getNewGame())
        {
            PlayerData data = SaveSystem.LoadPlayer();
            if (data.offensiveDefenseEscapeSkillTreeUnlockingVector != null)
            {
                for (var i = 0; i < data.offensiveDefenseEscapeSkillTreeUnlockingVector.Length; i++)
                {
                    isUnlocked[i] = data.offensiveDefenseEscapeSkillTreeUnlockingVector[i];
                }
            }
        }

        OffensiveDefenseEscapeUpdateAllUI();
    }

    public void OffensiveDefenseEscapeUpdateAllUI()
    {
        foreach (var skill in SkillList)
        {
            skill.UpdateUI();
        }
    }
}
