using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using static AnimationsController;

public class PauseScript : MonoBehaviour
{
    public GameObject ui;
    public GameObject pauseMenu;
    public GameObject mainButtons;
    public GameObject settingsButtons;
    public GameObject skillTreePanel;
    public GameObject xpPanel;
    public GameObject fistsPanel;
    public GameObject legsPanel;
    public GameObject grapplingPanel;
    public GameObject countersPanel;
    public GameObject stylesPanel;
    public GameObject dfFlyPanel;
    public GameObject dfTankPanel;
    public GameObject odEscapePanel;
    public GameObject player;
    public GameObject tppCamera;
    public GameObject fppCamera;
    bool isPaused;
    bool wasTppCameraDisabled = false;

    public GameObject repsCounterPanel;
    public GameObject repBarPanel;
    
    public GameObject repRythmBarPanel;
    public GameObject keysRythmPanel;

    public GameObject keysAlternateRythmPanel;

    public void Pause()
    {
        //if tppCamera was disabled during game, we make wasTppCameraDisabled true, else false
        if (animationsInstance.isAnimation)
            return;
        if(!tppCamera.activeSelf)
        {
            wasTppCameraDisabled = true;
        }
        else
        {
            wasTppCameraDisabled = false;
        }
        
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
        
        
        isPaused = true;
        tppCamera.SetActive(true); //we enable tppCamera always so that we can see pause menu
        Time.timeScale = 0; // we stop time
        pauseMenu.SetActive(true); // we enable pause menu
        ui.SetActive(false); // we disable UI
        player.SetActive(false); // we disable player
        settingsButtons.SetActive(false); // we disable settings buttons
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(false);
        fistsPanel.SetActive(false); 
        legsPanel.SetActive(false);
        grapplingPanel.SetActive(false);
        countersPanel.SetActive(false);
        stylesPanel.SetActive(false);
        dfFlyPanel.SetActive(false);
        odEscapePanel.SetActive(false);
        dfTankPanel.SetActive(false);// we disable all panels
        mainButtons.SetActive(true); // we enable main buttons
        Cursor.visible = true; // we make cursor visible
        Cursor.lockState = CursorLockMode.None; // we unlock cursor
        Debug.Log("Pause");
    }
    

    public void Resume()
    {
        //if tppCamera was disabled during game, we disable it again when we resume the game
        if(wasTppCameraDisabled)
        {
            tppCamera.SetActive(false);
        }
        isPaused = false;
        Time.timeScale = 1; // we resume time
        pauseMenu.SetActive(false); // we disable pause menu
        ui.SetActive(true); // we enable UI
        player.SetActive(true); // we enable player
        Cursor.visible = false; // we make cursor invisible
        Cursor.lockState = CursorLockMode.Locked; // we lock cursor
        Debug.Log("Resume");
    }

    public void Settings()
    {
        settingsButtons.SetActive(true); // we enable settings buttons
        mainButtons.SetActive(false); // we disable main buttons
    }

    public void SkillTree()
    {
        skillTreePanel.SetActive(true); // we enable skill tree panel
        mainButtons.SetActive(false); // we disable main buttons
        xpPanel.SetActive(true);
    }

    public void Fists()
    {
        fistsPanel.SetActive(true); // we enable fists panel
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(true);
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
    }

    public void Legs()
    {
        legsPanel.SetActive(true); // we enable legs panel
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(true);
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
    }
    
    public void Grappling()
    {
        grapplingPanel.SetActive(true); // we enable legs panel
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(true);
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
    }
    
    public void Counters()
    {
        countersPanel.SetActive(true); // we enable legs panel
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(true);
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
    }
    
    public void Styles()
    {
        stylesPanel.SetActive(true); // we enable legs panel
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(true);
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
    }
    
    public void DFFly()
    {
        dfFlyPanel.SetActive(true); // we enable legs panel
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(true);
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
    }
    
    public void DFTank()
    {
        dfTankPanel.SetActive(true); // we enable legs panel
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(true);
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
    }
    
    
    public void ODEscape()
    {
        odEscapePanel.SetActive(true); // we enable legs panel
        skillTreePanel.SetActive(false); // we disable skill tree panel
        xpPanel.SetActive(true);
        FistsSkillTree.skillTree.FistsUpdateAllUI();
        LegsSkillTree.skillTree.LegsUpdateAllUI();
        GrapplingSkillTree.skillTree.GrapplingUpdateAllUI();
        CountersSkillTree.skillTree.CountersUpdateAllUI();
        StylesSkillTree.skillTree.StylesUpdateAllUI();
        DefenseFlySkillTree.skillTree.DefenseFlyUpdateAllUI();
        DefenseTankSkillTree.skillTree.DefenseTankUpdateAllUI();
    }

    public void BackToMain()
    {
        settingsButtons.SetActive(false); // we disable settings buttons
        skillTreePanel.SetActive(false); // we disable skill tree panel
        mainButtons.SetActive(true); // we enable main buttons
        xpPanel.SetActive(false);
    }

    public void BackToSkillTree()
    {
        fistsPanel.SetActive(false); 
        legsPanel.SetActive(false);
        grapplingPanel.SetActive(false);
        countersPanel.SetActive(false);
        stylesPanel.SetActive(false);
        dfFlyPanel.SetActive(false);
        odEscapePanel.SetActive(false);
        dfTankPanel.SetActive(false);// we disable all panels
        skillTreePanel.SetActive(true); // we enable skill tree panel
    }

    public void Save()
    {
        SaveSystem.SavePlayer();
    }
    
    void Start()
    {
        Time.timeScale = 1; // we resume time
        pauseMenu.SetActive(false); // we disable pause menu
        isPaused = false;
        player.SetActive(true); // we enable player
        Cursor.visible = false; // we make cursor invisible
        
        repBarPanel.SetActive(false);
        repsCounterPanel.SetActive(false);
        
        repRythmBarPanel.SetActive(false);
        keysRythmPanel.SetActive(false);
        
        keysAlternateRythmPanel.SetActive(false);
    }
    void Update()
    {
        // if we press escape, we pause or resume the game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
