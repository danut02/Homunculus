using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour, IInteractable
{
    // trebuie schimbata partea de interactiune, nu o sa folosim tot timpul interactable
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Events: "+Player.Instance.getEventCounter());
        Player.Instance.setEventCounter(Player.Instance.getEventCounter()+1);
        Debug.Log("Events: "+Player.Instance.getEventCounter());
        return true;
    }
}