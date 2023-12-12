using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static StylesSkillTree;
using UnityEngine.UI;

public class StylesSkill : MonoBehaviour
{
    public int id;

    public TMP_Text TitleText;
    public TMP_Text DescriptionText;
    public TMP_Text Cost;
    
    public int[] ConnectedSkills;

    public void UpdateUI()
    {
        TitleText.text = $"{skillTree.SkillNames[id]}";
        DescriptionText.text = $"{skillTree.SkillDescriptions[id]}";
        Cost.text = $"{skillTree.SkillCosts[id]}";

        if(skillTree.isUnlocked[id])
            GetComponent<Image>().color = Color.yellow;
        else GetComponent<Image>().color = 
            (Player.Instance.getXp() >= skillTree.SkillCosts[id]) ? 
                Color.green : Color.white;

        foreach (var connectedSkill in ConnectedSkills)
        {
            skillTree.SkillList[connectedSkill].gameObject.SetActive(skillTree.isUnlocked[id]);
            skillTree.ConnectorList[connectedSkill].SetActive(skillTree.isUnlocked[id]);
        }
        
    }

    public void Buy()
    {
        if (Player.Instance.getXp() < skillTree.SkillCosts[id] || skillTree.isUnlocked[id])
            return;
        Player.Instance.addXp(-skillTree.SkillCosts[id]);
        skillTree.isUnlocked[id] = true;
        skillTree.StylesUpdateAllUI();
    }
}