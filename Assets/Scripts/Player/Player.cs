using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance = new Player();
    
    public Abdomen abdomen = new Abdomen();
    public AnteriorDelt anteriorDelt = new AnteriorDelt();
    public Back back = new Back();
    public Biceps biceps = new Biceps();
    public Calves calves = new Calves();
    public Chest chest = new Chest();
    public Forearms forearms = new Forearms();
    public Glutes glutes = new Glutes();
    public Hamstrings hamstrings = new Hamstrings();
    public LateralDelt lateralDelt = new LateralDelt();
    public PosteriorDelt posteriorDelt = new PosteriorDelt();
    public Quads quads = new Quads();
    public SpinalErectors spinalErectors = new SpinalErectors();
    public Trapezoid trapezoid = new Trapezoid();
    public Triceps triceps = new Triceps();
    
    private float health = 2350;
    private float maxHealth = 1000;
    private float maxHealthOverall = 2350;
    private bool canRegenerate = true;
    private bool reachedLastBreath = false;
    
    private float stamina = 310;
    private float maxStamina = 100;
    private float maxStaminaOverall = 310;

    private int xp = 999;
    private int eventCounter = 0;
    
    private int nightsSlept = 0;
    private bool newGame = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public void setEventCounter(int value)
    {
        eventCounter = value;
    }
    public int getEventCounter()
    {
        return eventCounter;
    }
    
    public void setNightsSlept(int value)
    {
        nightsSlept = value;
    }
    public int getNightsSlept()
    {
        return nightsSlept;
    }
    
    public void setHealth(float value)
    {
        health = value;
    }

    public float getHealth()
    {
        return health;
    }
    
    public void setMaxHealth(float value)
    {
        maxHealth = value;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }
    
    public void setMaxHealthOverall(float value)
    {
        maxHealthOverall = value;
    }

    public float getMaxHealthOverall()
    {
        return maxHealthOverall;
    }
    
    public void setCanRegenerate(bool value)
    {
        canRegenerate = value;
    }

    public bool getCanRegenerate()
    {
        return canRegenerate;
    }
    
    public void setReachedLastBreath(bool value)
    {
        reachedLastBreath = value;
    }

    public bool getReachedLastBreath()
    {
        return reachedLastBreath;
    }

    
    public void setStamina(float value)
    {
        stamina = value;
    }

    public float getStamina()
    {
        return stamina;
    }
    
    public void setMaxStamina(float value)
    {
        maxStamina = value;
    }

    public float getMaxStamina()
    {
        return maxStamina;
    }
    
    public void setMaxStaminaOverall(float value)
    {
        maxStaminaOverall = value;
    }

    public float getMaxStaminaOverall()
    {
        return maxStaminaOverall;
    }

    public int getXp()
    {
        return xp;
    }

    public void addXp(int value)
    {
        xp += value;
    }

    public void setXp(int value)
    {
        xp = value;
    }
    public void setNewGame(bool value)
    {
        newGame = value;
    }

    public bool getNewGame()
    {
        return newGame;
    }
    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            abdomen.setDevelopment(data.abdomenDevelopment);
            anteriorDelt.setDevelopment(data.anteriorDeltDevelopment);
            back.setDevelopment(data.backDevelopment);
            biceps.setDevelopment(data.bicepsDevelopment);
            calves.setDevelopment(data.calvesDevelopment);
            chest.setDevelopment(data.chestDevelopment);
            forearms.setDevelopment(data.forearmsDevelopment);
            glutes.setDevelopment(data.glutesDevelopment);
            hamstrings.setDevelopment(data.hamstringsDevelopment);
            lateralDelt.setDevelopment(data.lateralDeltDevelopment);
            posteriorDelt.setDevelopment(data.posteriorDeltDevelopment);
            quads.setDevelopment(data.quadsDevelopment);
            spinalErectors.setDevelopment(data.spinalErectorsDevelopment);
            trapezoid.setDevelopment(data.trapezoidDevelopment);
            triceps.setDevelopment(data.tricepsDevelopment);
            setEventCounter(data.eventCounter);
            
            setXp(data.xp);
            setHealth(data.health);
            setMaxHealth(data.maxHealth);
            setMaxHealthOverall(data.maxHealthOverall);
            setCanRegenerate(data.canRegenerate);
            setReachedLastBreath(data.reachedLastBreath);
            
            setStamina(data.stamina); 
            setMaxStamina(data.maxStamina);
            setMaxStaminaOverall(data.maxStaminaOverall);
            
            setNightsSlept(data.nightsSlept);
        }
    }
}