using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static MovementController;
using static AnimationsController;

public class SuperLegPress : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private int quadsGrowth;
    [SerializeField] private int glutesGrowth;
    [SerializeField] private int hamstringsGrowth;
    [SerializeField] private int calvesGrowth;
    
    [SerializeField] private int xpReward;
    public string InteractionPrompt => _prompt;
    public AnimationsController player;
    
    public Image repRythmBar;
    private int repCount;
    public GameObject repRythmBarPanel;
    public GameObject keysAlternateRythmPanel;
    public TMP_Text repTextContent;
    public GameObject repsCounterPanel;
    
    public GameObject repBarPanel;
    public Image repBar;
    
    private bool isWorking = false;
    
    public bool Interact(Interactor interactor)
    {
        if (isWorking || animationsInstance.isAnimation)
            return false;
        
        Player.Instance.addXp(xpReward);
        
        StartCoroutine(StartRepsRoutine());
        
        Player.Instance.quads.setDevelopment(Player.Instance.quads.getDevelopment() + quadsGrowth);
        Debug.Log("Quads: "+Player.Instance.quads.getDevelopment());
        
        Player.Instance.glutes.setDevelopment(Player.Instance.glutes.getDevelopment() + glutesGrowth);
        Debug.Log("Glutes: "+Player.Instance.glutes.getDevelopment());
        
        Player.Instance.hamstrings.setDevelopment(Player.Instance.hamstrings.getDevelopment() + hamstringsGrowth);
        Debug.Log("Hamstrings: "+Player.Instance.hamstrings.getDevelopment());
        
        Player.Instance.calves.setDevelopment(Player.Instance.calves.getDevelopment() + calvesGrowth);
        Debug.Log("Calves: "+Player.Instance.calves.getDevelopment());
        
        return true;
    }
    
    IEnumerator StartRepsRoutine()
    {
        repCount = 0;
        movementInstance.canMove = false;
        repTextContent.text = $"{repCount}";
        repRythmBarPanel.SetActive(true);
        repsCounterPanel.SetActive(true);
        keysAlternateRythmPanel.SetActive(true);
        repBarPanel.SetActive(true);
        isWorking = true;
        while (repCount < 2)
        {
            repRythmBar.fillAmount = 0;
            repBar.fillAmount = 0;
            yield return StartCoroutine(FillRepBar());
            repCount++;
            repTextContent.text = $"{repCount}";
        }

        repCount++;
        
        repRythmBarPanel.SetActive(false);
        keysAlternateRythmPanel.SetActive(false);
        repBarPanel.SetActive(false);
        StartCoroutine(waitOneSec());
    }

    IEnumerator FillRepBar()
    {
        while (repBar.fillAmount < 0.98f)
        {
            repRythmBar.fillAmount += 0.2f * Time.deltaTime;
            if (repRythmBar.fillAmount > 0.99f)
                repRythmBar.fillAmount = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Player.Instance.setStamina(Player.Instance.getStamina()-5f);
                if (isBetween(repRythmBar.fillAmount, 0.08f, 0.123f) ||

                    isBetween(repRythmBar.fillAmount, 0.28f, 0.323f) ||

                    isBetween(repRythmBar.fillAmount, 0.48f, 0.523f) ||

                    isBetween(repRythmBar.fillAmount, 0.68f, 0.723f) ||

                    isBetween(repRythmBar.fillAmount, 0.88f, 0.923f))
                    repBar.fillAmount += 0.111f;
                else repBar.fillAmount -= 0.111f;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Player.Instance.setStamina(Player.Instance.getStamina()-5f);
                if (isBetween(repRythmBar.fillAmount, 0.18f, 0.223f) ||

                    isBetween(repRythmBar.fillAmount, 0.38f, 0.423f) ||

                    isBetween(repRythmBar.fillAmount, 0.58f, 0.623f) ||

                    isBetween(repRythmBar.fillAmount, 0.78f, 0.823f))
                    repBar.fillAmount += 0.111f;
                else repBar.fillAmount -= 0.111f;
            }

            // if (Input.GetKeyDown(KeyCode.UpArrow))
            //     repRythmBar.fillAmount += 0.01f;
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

