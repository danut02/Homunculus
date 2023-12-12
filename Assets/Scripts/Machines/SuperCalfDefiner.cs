using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCalfDefiner : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private int calvesGrowth;
    
    [SerializeField] private int xpReward;
    public string InteractionPrompt => _prompt;
    
    public bool Interact(Interactor interactor)
    {
        Player.Instance.addXp(xpReward);
        Player.Instance.calves.setDevelopment(Player.Instance.calves.getDevelopment() + calvesGrowth);
        Debug.Log("Calves: "+Player.Instance.calves.getDevelopment());
        
        return true;
    }
}
