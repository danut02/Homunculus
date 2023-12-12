using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountersSkillTree : MonoBehaviour
{
    public static CountersSkillTree skillTree;
    private void Awake() => skillTree = this;

    // public int[] SkillLevels;
    // public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;
    public int[] SkillCosts;
    public bool[] isUnlocked;
    
    public List<CountersSkill> SkillList;
    public GameObject SkillHolder;
    
    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;
    

    private void Start()
    {
        
        SkillNames = new[]
        {
            "Piedica", "Counter",
            "Headbutt", "Dempsey Roll",
            "Gazele Turtle", "Cross Counter"
        };

        SkillDescriptions = new[]
        {"Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
        };
        
        SkillCosts = new[]
        { 2, 2, 2, 2, 2, 2
        };

        isUnlocked = new[]
        { false, false, false, false, false, false, false, false, false
        };
        
        foreach (var skill in SkillHolder.GetComponentsInChildren<CountersSkill>())
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
            if (data.countersSkillTreeUnlockingVector != null)
            {
                for (var i = 0; i < data.countersSkillTreeUnlockingVector.Length; i++)
                {
                    isUnlocked[i] = data.countersSkillTreeUnlockingVector[i];
                }
            }
        }

        CountersUpdateAllUI();
    }

    public void CountersUpdateAllUI()
    {
        foreach (var skill in SkillList)
        {
            skill.UpdateUI();
        }
    }
}
