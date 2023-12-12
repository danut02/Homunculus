using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Player.Instance.setHealth(Player.Instance.getHealth()-200);
        Debug.Log("OOF " + Player.Instance.getHealth());
        
        return true;
    }
}
