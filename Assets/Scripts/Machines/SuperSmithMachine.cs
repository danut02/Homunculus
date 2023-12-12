using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static MovementController;
using static AnimationsController;

public class SuperSmithMachine : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private int chestGrowth;
    [SerializeField] private int tricepsGrowth;
    [SerializeField] private int anteriorDeltGrowth;
    
    [SerializeField] private int xpReward;
    public string InteractionPrompt => _prompt;
    
    
    
    public Image repRythmBar;
    private int repCount;
    public GameObject repRythmBarPanel;
    public GameObject keysRythmPanel;
    public TMP_Text repTextContent;
    public GameObject repsCounterPanel;
    
    public GameObject repBarPanel;
    public Image repBar;
    
    private bool isWorking = false;

    private float barSpeed = 0.2f;
    
    public bool Interact(Interactor interactor)
    {
        if (isWorking || animationsInstance.isAnimation)
            return false;
        
        Player.Instance.addXp(xpReward);
        
        StartCoroutine(StartRepsRoutine());
        
        
        Player.Instance.chest.setDevelopment(Player.Instance.chest.getDevelopment() + chestGrowth);
        Debug.Log("Chest:"+Player.Instance.chest.getDevelopment());
        
        Player.Instance.triceps.setDevelopment(Player.Instance.triceps.getDevelopment() + tricepsGrowth);
        Debug.Log("Triceps:"+Player.Instance.triceps.getDevelopment());
        
        Player.Instance.anteriorDelt.setDevelopment(Player.Instance.anteriorDelt.getDevelopment() + anteriorDeltGrowth);
        Debug.Log("AnteriorDelt:"+Player.Instance.anteriorDelt.getDevelopment());
        return true;
    }
    
    IEnumerator StartRepsRoutine()
    {
        repCount = 0;
        movementInstance.canMove = false;
        repTextContent.text = $"{repCount}";
        repRythmBarPanel.SetActive(true);
        repsCounterPanel.SetActive(true);
        keysRythmPanel.SetActive(true);
        
        repBarPanel.SetActive(true);
        isWorking = true;
        while (repCount < 6)
        {
            repRythmBar.fillAmount = 0;
            repBar.fillAmount = 0;
            repCount++;
            if (repCount % 2 == 0)
                barSpeed *= 1.2f;
            yield return StartCoroutine(FillRepBar());
            repTextContent.text = $"{repCount}";
        }

        repCount++;
        
        repRythmBarPanel.SetActive(false);
        keysRythmPanel.SetActive(false);
        
        repBarPanel.SetActive(false);
        StartCoroutine(waitOneSec());
    }

    IEnumerator FillRepBar()
    {
        while (repBar.fillAmount < 0.98f)
        {
            repRythmBar.fillAmount += barSpeed * Time.deltaTime;
            if (repRythmBar.fillAmount > 0.99f)
                repRythmBar.fillAmount = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {   Player.Instance.setStamina(Player.Instance.getStamina()-5f);
                if (isBetween(repRythmBar.fillAmount, 0.08f, 0.123f) ||
                    isBetween(repRythmBar.fillAmount, 0.18f, 0.223f) ||
                    isBetween(repRythmBar.fillAmount, 0.28f, 0.323f) ||
                    isBetween(repRythmBar.fillAmount, 0.38f, 0.423f) ||
                    isBetween(repRythmBar.fillAmount, 0.48f, 0.523f) ||
                    isBetween(repRythmBar.fillAmount, 0.58f, 0.623f) ||
                    isBetween(repRythmBar.fillAmount, 0.68f, 0.723f) ||
                    isBetween(repRythmBar.fillAmount, 0.78f, 0.823f) ||
                    isBetween(repRythmBar.fillAmount, 0.88f, 0.923f))
                    repBar.fillAmount += 0.111f;
                else repBar.fillAmount -= 0.111f;
            }

            yield return null;
        }
    }

    IEnumerator waitOneSec()
    {
        yield return new WaitForSeconds(1.5f);
        movementInstance.canMove = true;
        repsCounterPanel.SetActive(false);
        isWorking = false;
    }

    bool isBetween(float x, float l, float u)
    {
        if (x > l && x < u)
            return true;
        return false;
    }
}
