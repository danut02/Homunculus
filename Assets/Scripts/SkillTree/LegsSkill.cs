using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LegsSkillTree;
using UnityEngine.UI;

public class LegsSkill : MonoBehaviour
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
        if (id != 8)
        {
            if (skillTree.isUnlocked[id])
                GetComponent<Image>().color = Color.yellow;
            else
                GetComponent<Image>().color =
                    (Player.Instance.getXp() >= skillTree.SkillCosts[id]) ? Color.green : Color.white;
            foreach (var connectedSkill in ConnectedSkills)
            {
                if (connectedSkill != 8)
                {
                    skillTree.SkillList[connectedSkill].gameObject.SetActive(skillTree.isUnlocked[id]);
                    skillTree.ConnectorList[connectedSkill].SetActive(skillTree.isUnlocked[id]);
                }
            }
        }
        else
        {
            Debug.Log("1");
            if (skillTree.isUnlocked[7] && skillTree.isUnlocked[6] && skillTree.isUnlocked[5] &&
                skillTree.isUnlocked[4])
            {
                Debug.Log("2");
                if (skillTree.isUnlocked[id])
                    GetComponent<Image>().color = Color.yellow;
                else
                {Debug.Log("3");
                    GetComponent<Image>().color =
                        (Player.Instance.getXp() >= skillTree.SkillCosts[id]) ? Color.green : Color.white;
                }

                foreach (var connectedSkill in ConnectedSkills)
                {
                    skillTree.SkillList[connectedSkill].gameObject.SetActive(true);
                    skillTree.ConnectorList[connectedSkill].SetActive(true);
                }
            }

        }

        
        
    }

    public void Buy()
    {
        if (Player.Instance.getXp() < skillTree.SkillCosts[id] || skillTree.isUnlocked[id])
            return;
        Player.Instance.addXp(-skillTree.SkillCosts[id]);
        skillTree.isUnlocked[id] = true;
        skillTree.LegsUpdateAllUI();
    }
}