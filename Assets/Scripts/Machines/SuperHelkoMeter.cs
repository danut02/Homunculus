using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MovementController;
using static AnimationsController;

public class SuperHelkoMeter : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    
    [SerializeField] private int backGrowth;
    [SerializeField] private int bicepsGrowth;
    [SerializeField] private int posteriorDeltGrowth;
    [SerializeField] private int trapezoidGrowth;
    [SerializeField] private int forearmsGrowth;
    
    [SerializeField] private int xpReward;
    public string InteractionPrompt => _prompt;
    
    public AnimationsController player;

    public TMP_Text repTextContent;
    public Image repBar;
    private int repCount;
    public GameObject repsCounterPanel;
    public GameObject repBarPanel;

    private bool isWorking = false;
    private bool lastButtonPressed = false; //false == left ; ; ; true == right
    
    private float clickIncrement = 46f;
    
    public bool Interact(Interactor interactor)
    {
        if (isWorking || animationsInstance.isAnimation)
            return false;
        Player.Instance.addXp(xpReward);

        StartCoroutine(StartRepsRoutine());
        
        Player.Instance.back.setDevelopment(Player.Instance.back.getDevelopment() + backGrowth);
        Debug.Log("Back: "+Player.Instance.back.getDevelopment());
        
        Player.Instance.biceps.setDevelopment(Player.Instance.biceps.getDevelopment() + bicepsGrowth);
        Debug.Log("Biceps: "+Player.Instance.biceps.getDevelopment());
        
        Player.Instance.posteriorDelt.setDevelopment(Player.Instance.posteriorDelt.getDevelopment() + posteriorDeltGrowth);
        Debug.Log("PosteriorDelt: "+Player.Instance.posteriorDelt.getDevelopment());
        
        Player.Instance.trapezoid.setDevelopment(Player.Instance.trapezoid.getDevelopment() + trapezoidGrowth);
        Debug.Log("Trapezoid: "+Player.Instance.trapezoid.getDevelopment());
        
        Player.Instance.forearms.setDevelopment(Player.Instance.forearms.getDevelopment() + forearmsGrowth);
        Debug.Log("Forearms: "+Player.Instance.forearms.getDevelopment());
        
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
                clickIncrement -= 3.5f;
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
            if ((Input.GetMouseButtonDown(0) && lastButtonPressed == true) ||
                (Input.GetMouseButtonDown(1) && lastButtonPressed == false))
            {
                Player.Instance.setStamina(Player.Instance.getStamina()-1.5f);
                if (Input.GetMouseButton(0))
                    lastButtonPressed = false;
                if (Input.GetMouseButtonDown(1))
                    lastButtonPressed = true;
                repBar.fillAmount += clickIncrement * Time.deltaTime;

            }
            else if ((Input.GetMouseButtonDown(1) && lastButtonPressed == true) || (Input.GetMouseButtonDown(0) && lastButtonPressed == false))
            {
                Player.Instance.setStamina(Player.Instance.getStamina()-3f);
                if (Input.GetMouseButtonDown(0))
                    lastButtonPressed = false;
                if (Input.GetMouseButtonDown(1))
                    lastButtonPressed = true;
                repBar.fillAmount -= clickIncrement * Time.deltaTime;
            }
            else repBar.fillAmount -= 1f * Time.deltaTime;
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
}