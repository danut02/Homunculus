using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementController;

public class Bathtub : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public Health health;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Ai interactionat cu baia");
        FreezePlayer();
        health.speedRecovery();
        return true;
    }
    public void FreezePlayer()
    {
        Debug.Log("Se incearca inghetarea playerului");
        StartCoroutine(FreezePlayerCoroutine());
    }

    private IEnumerator FreezePlayerCoroutine()
    {
        movementInstance.canMove = false;
        Debug.Log("S-a intrat in Corutina");
        yield return new WaitForSeconds(3f);
        movementInstance.canMove = true;
    }
}