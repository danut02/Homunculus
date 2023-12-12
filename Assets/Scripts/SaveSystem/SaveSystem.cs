using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string path = Application.persistentDataPath + "/playerSave.json";

    public static void SavePlayer()
    {
        PlayerData data = new PlayerData
        {
            abdomenDevelopment = Player.Instance.abdomen.getDevelopment(),
            anteriorDeltDevelopment = Player.Instance.anteriorDelt.getDevelopment(),
            backDevelopment = Player.Instance.back.getDevelopment(),
            bicepsDevelopment = Player.Instance.biceps.getDevelopment(),
            calvesDevelopment = Player.Instance.calves.getDevelopment(),
            chestDevelopment = Player.Instance.chest.getDevelopment(),
            forearmsDevelopment = Player.Instance.forearms.getDevelopment(),
            glutesDevelopment = Player.Instance.glutes.getDevelopment(),
            hamstringsDevelopment = Player.Instance.hamstrings.getDevelopment(),
            lateralDeltDevelopment = Player.Instance.lateralDelt.getDevelopment(),
            posteriorDeltDevelopment = Player.Instance.posteriorDelt.getDevelopment(),
            quadsDevelopment = Player.Instance.quads.getDevelopment(),
            spinalErectorsDevelopment = Player.Instance.spinalErectors.getDevelopment(),
            trapezoidDevelopment = Player.Instance.trapezoid.getDevelopment(),
            tricepsDevelopment = Player.Instance.triceps.getDevelopment(),
            eventCounter = Player.Instance.getEventCounter(),
            stamina = Player.Instance.getStamina(),
            health = Player.Instance.getHealth(),
            maxHealth = Player.Instance.getMaxHealth(),
            maxHealthOverall = Player.Instance.getMaxHealthOverall(),
            canRegenerate = Player.Instance.getCanRegenerate(),
            reachedLastBreath = Player.Instance.getReachedLastBreath(),
            maxStamina = Player.Instance.getMaxStamina(),
            maxStaminaOverall = Player.Instance.getMaxStaminaOverall(),
            nightsSlept = Player.Instance.getNightsSlept(),
            xp = Player.Instance.getXp(),
            defenseFlySkillTreeUnlockingVector = DefenseFlySkillTree.skillTree.isUnlocked,
            countersSkillTreeUnlockingVector = CountersSkillTree.skillTree.isUnlocked,
            defenseTankSkillTreeUnlockingVector = DefenseTankSkillTree.skillTree.isUnlocked,
            fistsSkillTreeUnlockingVector = FistsSkillTree.skillTree.isUnlocked,
            grapplingSkillTreeUnlockingVector = GrapplingSkillTree.skillTree.isUnlocked,
            legsSkillTreeUnlockingVector = LegsSkillTree.skillTree.isUnlocked,
            offensiveDefenseEscapeSkillTreeUnlockingVector = OffensiveDefenseEscapeSkillTree.skillTree.isUnlocked,
            stylesSkillTreeUnlockingVector = StylesSkillTree.skillTree.isUnlocked
        };
        Debug.Log(StylesSkillTree.skillTree.isUnlocked);
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(path, json);
    }

    public static PlayerData LoadPlayer()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found at " + path);
            return null;
        }
    }
}