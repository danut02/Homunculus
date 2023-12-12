using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingSkillTree : MonoBehaviour
{
    public static GrapplingSkillTree skillTree;
    private void Awake() => skillTree = this;

    // public int[] SkillLevels;
    // public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;
    public int[] SkillCosts;
    public bool[] isUnlocked;
    
    public List<GrapplingSkill> SkillList;
    public GameObject SkillHolder;
    
    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;
    

    private void Start()
    {
        
        SkillNames = new[]
        {
            "Prindere", "Aruncare",
            "Rasturnare", "Bite",
            "Sufocare", "Arm Bar",
            "Crushing Hug", "Wrist Break",
            "Neck Break"
        };

        SkillDescriptions = new[]
        {"Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
            "Descriere Sugestiva",
        };
        
        SkillCosts = new[]
        { 2, 2, 2, 2, 2, 2, 2, 2, 2
        };

        isUnlocked = new[]
        { false, false, false, false, false, false, false, false, false
        };
        
        foreach (var skill in SkillHolder.GetComponentsInChildren<GrapplingSkill>())
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
        SkillList[3].ConnectedSkills = new[] {4,5,6,7 };
        SkillList[4].ConnectedSkills = new[] { 8 };
        SkillList[5].ConnectedSkills = new[] { 8 };
        SkillList[6].ConnectedSkills = new[] { 8 };
        SkillList[7].ConnectedSkills = new[] { 8 };
        SkillList[8].ConnectedSkills = new[] { 8 };
        skillTree.SkillList[8].gameObject.SetActive(skillTree.isUnlocked[8]);
        skillTree.ConnectorList[8].SetActive(skillTree.isUnlocked[8]);
        if (!Player.Instance.getNewGame())
        {
            PlayerData data = SaveSystem.LoadPlayer();
            if (data.grapplingSkillTreeUnlockingVector != null)
            {
                for (var i = 0; i < data.grapplingSkillTreeUnlockingVector.Length; i++)
                {
                    isUnlocked[i] = data.grapplingSkillTreeUnlockingVector[i];
                }
            }
        }

        GrapplingUpdateAllUI();
    }

    public void GrapplingUpdateAllUI()
    {
        foreach (var skill in SkillList)
        {
            skill.UpdateUI();
        }
    }
}
