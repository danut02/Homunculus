using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MovementController;
using static AnimationsController;

public class BenchPress : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private int chestGrowth;
    [SerializeField] private int tricepsGrowth;
    [SerializeField] private int anteriorDeltGrowth;

    [SerializeField] private int xpReward;
    public string InteractionPrompt => _prompt;

    public AnimationsController player;

    public TMP_Text repTextContent;
    public Image repBar;
    private int repCount;
    public GameObject repsCounterPanel;
    public GameObject repBarPanel;

    private float clickIncrement = 50f;
    
    private bool isWorking = false;

    public bool Interact(Interactor interactor)
    {
        if (isWorking || animationsInstance.isAnimation)
            return false;
        Player.Instance.addXp(xpReward);
    
        StartCoroutine(StartRepsRoutine());

        Player.Instance.chest.setDevelopment(Player.Instance.chest.getDevelopment() + chestGrowth);
        Debug.Log("Chest: " + Player.Instance.chest.getDevelopment());

        Player.Instance.triceps.setDevelopment(Player.Instance.triceps.getDevelopment() + tricepsGrowth);
        Debug.Log("Triceps: " + Player.Instance.triceps.getDevelopment());

        Player.Instance.anteriorDelt.setDevelopment(Player.Instance.anteriorDelt.getDevelopment() + anteriorDeltGrowth);
        Debug.Log("AnteriorDelt: " + Player.Instance.anteriorDelt.getDevelopment());

        Player.Instance.setEventCounter(Player.Instance.getEventCounter() + 1);
        Debug.Log("Events: " + Player.Instance.getEventCounter());

        return true;

    }

    IEnumerator StartRepsRoutine()
    {
        repCount = 0;
        movementInstance.canMove = false;
        repTextContent.text = $"{repCount}";
        repBarPanel.SetActive(true);
        repsCounterPanel.SetActive(true);
        isWorking = true;
        while (repCount <= 9)
        {
            repBar.fillAmount = 0;
            repCount++;
            if (repCount % 2 == 0)
                clickIncrement -= 4f;
            yield return StartCoroutine(FillRepBar());
            repTextContent.text = $"{repCount}";
        }

        repCount++;
        repBarPanel.SetActive(false);
        StartCoroutine(waitOneSec());
    }
    
    IEnumerator FillRepBar()
    {
        while (repBar.fillAmount < 0.98f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                repBar.fillAmount += clickIncrement * Time.deltaTime;
                Player.Instance.setStamina(Player.Instance.getStamina()-1.5f);
            }
            else
                repBar.fillAmount -= 1f * Time.deltaTime;
            yield return null;
        }
    }
    
    IEnumerator waitOneSec()
    {
        yield return new WaitForSeconds(1.5f);
        repsCounterPanel.SetActive(false);
        movementInstance.canMove = true;
        isWorking = false;
    }
    
}
