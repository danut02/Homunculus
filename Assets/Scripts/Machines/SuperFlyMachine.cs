using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFlyMachine : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private int chestGrowth;
    [SerializeField] private int anteriorDeltGrowth;
    
    [SerializeField] private int xpReward;

    public string InteractionPrompt => _prompt;
    
    public bool Interact(Interactor interactor)
    {
        Player.Instance.addXp(xpReward);
        
        Player.Instance.chest.setDevelopment(Player.Instance.chest.getDevelopment() + chestGrowth);
        Debug.Log("Chest: "+Player.Instance.chest.getDevelopment());
        
        Player.Instance.anteriorDelt.setDevelopment(Player.Instance.anteriorDelt.getDevelopment() + anteriorDeltGrowth);
        Debug.Log("AnteriorDelt: "+Player.Instance.anteriorDelt.getDevelopment());
        
        return true;
    }
}
