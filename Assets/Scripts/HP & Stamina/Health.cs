using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar0;
    public Image healthBar1;
    public Image healthBar2;
    public Image healthBar3;
    public Image healthBar4;
    
    private float maxHealth, maxHealthOverall, health;
    public float maxHealthInit;
    public float recoveryRate;

    private bool canRegenerate ;
    private bool reachedLastBreath;
    
    public void speedRecovery()
    {
        Debug.Log("Speedy recovery");
        StartCoroutine(speedRecoveryCoroutine());
    }

    private IEnumerator speedRecoveryCoroutine()
    {
        recoveryRate *= 10;
        Debug.Log("S-a intrat in Corutina de la health");
        yield return new WaitForSeconds(3f);

        recoveryRate /= 10;
    }
    private void Start()
    {
        maxHealth = Player.Instance.getMaxHealth();
        maxHealthOverall = Player.Instance.getMaxHealthOverall();
        canRegenerate = Player.Instance.getCanRegenerate();
        reachedLastBreath = Player.Instance.getReachedLastBreath();
        health = Player.Instance.getHealth();
        if (reachedLastBreath)
        {   healthBar0.fillAmount = 0;
            healthBar1.fillAmount = 0;
            healthBar2.fillAmount = 0;
            healthBar3.fillAmount = 0;
            healthBar4.fillAmount = 1;
        }
        else
            if (health < 2 * maxHealth + (maxHealth / 10) + (maxHealth / 4) && health >= 2 * maxHealth + (maxHealth / 4))
            {
                healthBar0.fillAmount =
                    Mathf.Clamp((health - maxHealth * 2 - (maxHealth / 4)) / (maxHealthInit / 10), 0f, 1f);
                healthBar3.fillAmount = healthBar2.fillAmount = healthBar1.fillAmount = healthBar0.fillAmount;
                healthBar4.fillAmount = 0;
            }
            else if (health < 2*maxHealth+(maxHealth/4) && health >= 2*maxHealth)
                {
                    healthBar0.fillAmount = 0;
                    healthBar1.fillAmount = Mathf.Clamp((health-maxHealth*2) / (maxHealthInit/4),0f,1f) ;
                    healthBar3.fillAmount = healthBar2.fillAmount = healthBar1.fillAmount;
                    healthBar4.fillAmount = 0;
                }
                else if (health < 2*maxHealth && health >= maxHealth)
                {   healthBar0.fillAmount = 0;
                    healthBar1.fillAmount = 0;
                    healthBar2.fillAmount = Mathf.Clamp(((health-maxHealth*1) / maxHealthInit),0f,1f) ;
                    healthBar3.fillAmount = healthBar2.fillAmount;
                    healthBar4.fillAmount = 0;
                }
                else if (health < maxHealth && health > 1.1f)
                {
                    healthBar0.fillAmount = 0;
                    healthBar1.fillAmount = 0;
                    healthBar2.fillAmount = 0;
                    healthBar3.fillAmount = Mathf.Clamp(((health) / maxHealthInit),0f,1f) ;
                    if(!reachedLastBreath)
                        healthBar4.fillAmount = 0;
                    
                }
                else if (health <=1 )
                    {
                        if (reachedLastBreath)
                        {
                            health = 0;
                            healthBar0.fillAmount = 0;
                            healthBar1.fillAmount = 0;
                            healthBar2.fillAmount = 0;
                            healthBar3.fillAmount = 0;
                            healthBar4.fillAmount = 0;
                            Debug.Log("Homunculus has died");
                        }
                        else
                        {
                            reachedLastBreath = true;
                            health=1;
                            canRegenerate = !canRegenerate;
                            healthBar0.fillAmount = 0;
                            healthBar1.fillAmount = 0;
                            healthBar2.fillAmount = 0;
                            healthBar3.fillAmount = 0;
                            healthBar4.fillAmount = 1;
                        }
                    }
    }

    void LateUpdate()
    {
        maxHealth = Player.Instance.getMaxHealth();
        maxHealthOverall = Player.Instance.getMaxHealthOverall();
        canRegenerate = Player.Instance.getCanRegenerate();
        reachedLastBreath = Player.Instance.getReachedLastBreath();
        health = Player.Instance.getHealth();
        
            if (health < 2*maxHealth+(maxHealth / 10) + (maxHealth/4) && health >= 2*maxHealth+ (maxHealth/4))
                healthBar0.fillAmount = Mathf.Clamp((health-maxHealth*2-(maxHealth/4)) / (maxHealthInit / 10),0f,1f) ;
            else if (health < 2*maxHealth+(maxHealth/4) && health >= 2*maxHealth)
            {
                healthBar0.fillAmount = 0;
                healthBar1.fillAmount = Mathf.Clamp((health-maxHealth*2) / (maxHealthInit/4),0f,1f) ;
            }
            else if (health < 2*maxHealth && health >= maxHealth)
            {   healthBar0.fillAmount = 0;
                healthBar1.fillAmount = 0;
                healthBar2.fillAmount = Mathf.Clamp(((health-maxHealth*1) / maxHealthInit),0f,1f) ;
            }
            else if (health < maxHealth && health > 0)
            {
                healthBar0.fillAmount = 0;
                healthBar1.fillAmount = 0;
                healthBar2.fillAmount = 0;
                maxHealth = health;
                maxHealthOverall = (maxHealth / 10) + 2 * maxHealth + (maxHealth / 4);
                healthBar3.fillAmount = Mathf.Clamp(((health) / maxHealthInit),0f,1f) ;
                if(!reachedLastBreath)
                    healthBar4.fillAmount = 0;
                
            }
            else if (health <=0 )
                {
                    if (reachedLastBreath)
                    {
                        health = 0;
                        healthBar0.fillAmount = 0;
                        healthBar1.fillAmount = 0;
                        healthBar2.fillAmount = 0;
                        healthBar3.fillAmount = 0;
                        healthBar4.fillAmount = 0;
                        Debug.Log("Homunculus has died");
                    }
                    else
                    {
                        reachedLastBreath = true;
                        health=1;
                        canRegenerate = !canRegenerate;
                        healthBar0.fillAmount = 0;
                        healthBar1.fillAmount = 0;
                        healthBar2.fillAmount = 0;
                        healthBar3.fillAmount = 0;
                        healthBar4.fillAmount = 1;
                    }
                }
            
        if (health < maxHealthOverall && canRegenerate)
        {   
            health+= recoveryRate * Time.deltaTime;
            if (health < 2*maxHealth+(maxHealth / 10) + (maxHealth/4) && health >= 2*maxHealth+ (maxHealth/4)){
                healthBar0.fillAmount = Mathf.Clamp((health-maxHealth*2-(maxHealth/4)) / (maxHealthInit / 10),0f,1f) ;
                healthBar1.fillAmount = Mathf.Clamp((maxHealth/ maxHealthInit),0f,1f) ;
                }
            else if (health < 2*maxHealth+(maxHealth/4) && health >= 2*maxHealth)
            {
                healthBar0.fillAmount = 0;
                healthBar1.fillAmount = Mathf.Clamp((health-maxHealth*2) / (maxHealthInit/4),0f,1f) ;
                healthBar2.fillAmount = Mathf.Clamp((maxHealth / maxHealthInit),0f,1f) ;
            }
            else if (health < 2 * maxHealth && health >= maxHealth)
            {
                healthBar0.fillAmount = 0;
                healthBar1.fillAmount = 0;
                healthBar2.fillAmount = Mathf.Clamp(((health-maxHealth*1) / maxHealthInit),0f,1f) ;
                healthBar3.fillAmount = Mathf.Clamp((maxHealth / maxHealthInit),0f,1f) ;
            }
            else if (health < maxHealth && health > 0)
            {
                healthBar0.fillAmount = 0;
                healthBar1.fillAmount = 0;
                healthBar2.fillAmount = 0;
                healthBar3.fillAmount = Mathf.Clamp(((health) / maxHealthInit),0f,1f) ;
                if(!reachedLastBreath)
                    healthBar4.fillAmount = 0;
                else
                {
                    healthBar3.fillAmount = 0;
                    healthBar4.fillAmount = 1;
                }
            }
        }
        
        
         Player.Instance.setMaxHealth(maxHealth);
         Player.Instance.setMaxHealthOverall(maxHealthOverall);
         Player.Instance.setCanRegenerate(canRegenerate);
         Player.Instance.setReachedLastBreath(reachedLastBreath);
         Player.Instance.setHealth(health);
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(healthBar0.fillAmount);
            Debug.Log(healthBar1.fillAmount);
            Debug.Log(healthBar2.fillAmount);
            Debug.Log(healthBar3.fillAmount);
        }
    }
}
