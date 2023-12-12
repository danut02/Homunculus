using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistsSkillTree : MonoBehaviour
{
    public static FistsSkillTree skillTree;
    private void Awake() => skillTree = this;

    // public int[] SkillLevels;
    // public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;
    public int[] SkillCosts;
    public bool[] isUnlocked;
    
    public List<FistsSkill> SkillList;
    public GameObject SkillHolder;
    
    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;
    

    private void Start()
    {
        
        SkillNames = new[]
        {
            "Jab", "Straight",
            "Hook", "Uppercut",
            "Elbow Punch", "Elbow Cut",
            "Fast Straights", "Rising Uppercut",
            "Corkscrew punch"
        };

        SkillDescriptions = new[]
        {"Unlocks JAB",
            "Unlocks STRAIGHT",
            "Unlocks HOOK",
            "Unlocks UPPERCUT",
            "Unlocks ELBOW PUNCH",
            "Unlocks ELBOW CUT",
            "Unlocks FAST STRAIGHTS",
            "Unlocks RISING UPPERCUTS",
            "Unlocks CORKSCREW PUNCH",
        };
        
        SkillCosts = new[]
        { 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        isUnlocked = new[]
        { false, false, false, false, false, false, false, false, false
        };
        
        foreach (var skill in SkillHolder.GetComponentsInChildren<FistsSkill>())
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
            if (data.fistsSkillTreeUnlockingVector != null)
            {
                for (var i = 0; i < data.fistsSkillTreeUnlockingVector.Length; i++)
                {
                    isUnlocked[i] = data.fistsSkillTreeUnlockingVector[i];
                }
            }
        }

        FistsUpdateAllUI();
    }

    public void FistsUpdateAllUI()
    {
        foreach (var skill in SkillList)
        {
            skill.UpdateUI();
        }
    }
}
