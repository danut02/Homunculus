using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour,IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if (Player.Instance.getEventCounter() >= 5)
        {
            Debug.Log("S-a culcat nebunu");
            Player.Instance.setEventCounter(0);
            Player.Instance.setNightsSlept(Player.Instance.getNightsSlept()+1);
            SaveSystem.SavePlayer();
        }
        else
            Debug.Log("Nu mi-e somn vere");
        return true;
    }
}
