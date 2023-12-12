using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAbsCruncher : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private int abdomenGrowth;
    
    [SerializeField] private int xpReward;
    
    public string InteractionPrompt => _prompt;
    
    public bool Interact(Interactor interactor)
    {
        Player.Instance.addXp(xpReward);
        
        Player.Instance.abdomen.setDevelopment(Player.Instance.abdomen.getDevelopment() + abdomenGrowth);
        Debug.Log("Abdomen: "+Player.Instance.abdomen.getDevelopment());
        
        return true;
    }
}
