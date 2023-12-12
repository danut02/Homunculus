using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryModule : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Player.Instance.setHealth(2350);
        Player.Instance.setStamina(310);
        Debug.Log("Ai incercat sa te regenerezi " + Player.Instance.getHealth() + "   " + Player.Instance.getStamina());
        return true;
    }
}