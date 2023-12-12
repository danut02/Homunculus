using UnityEngine;
using UnityEngine.UI;
using static AnimationsController;
using static MovementController;
public class Stamina : MonoBehaviour
{
    
    public Image staminaBar0;
    public Image staminaBar1;
    public Image staminaBar2;
    public Image staminaBar3;

    private float maxStamina, maxStaminaOverall, stamina;
    public float maxStaminaInit;
    public float attackCost;
    public float runCost;
    public float walkCost;
    public float recoveryRate;
    
    private void Start()
    {
        maxStamina = Player.Instance.getMaxStamina();
        maxStaminaOverall = Player.Instance.getMaxStaminaOverall();
        stamina = Player.Instance.getStamina();
        if (stamina <= 3 * maxStamina + (maxStamina / 10) && stamina >= 3 * maxStamina)
        {
            staminaBar0.fillAmount = Mathf.Clamp((stamina - maxStamina * 3) / (maxStaminaInit / 10), 0f, 1f);
            staminaBar3.fillAmount = staminaBar2.fillAmount = staminaBar1.fillAmount = staminaBar0.fillAmount;
        }
        else if (stamina < 3*maxStamina && stamina >= 2*maxStamina)
        {
            staminaBar0.fillAmount = 0;
            staminaBar1.fillAmount = Mathf.Clamp(((stamina-maxStamina*2) / maxStaminaInit),0f,1f) ;
            staminaBar3.fillAmount = staminaBar2.fillAmount = staminaBar1.fillAmount;
        }
        else if (stamina < 2*maxStamina && stamina >= maxStamina)
        {   staminaBar0.fillAmount = 0;
            staminaBar1.fillAmount = 0;
            staminaBar2.fillAmount = Mathf.Clamp(((stamina-maxStamina*1) / maxStaminaInit),0f,1f) ;
            staminaBar3.fillAmount = staminaBar2.fillAmount;
        }
        else if (stamina < maxStamina && stamina > 0)
        {
            staminaBar0.fillAmount = 0;
            staminaBar1.fillAmount = 0;
            staminaBar2.fillAmount = 0;
            staminaBar3.fillAmount = Mathf.Clamp(((stamina) / maxStaminaInit),0f,1f) ;
        }
        else
        {
            stamina = 0;
            staminaBar0.fillAmount = 0;
            staminaBar1.fillAmount = 0;
            staminaBar2.fillAmount = 0;
            staminaBar3.fillAmount = 0;
            Debug.Log("Homunculus has fainted");
        }
    }
    void Update()
    {

        stamina = Player.Instance.getStamina();
        maxStamina = Player.Instance.getMaxStamina();
        maxStaminaOverall = Player.Instance.getMaxStaminaOverall();

        
            if (!animationsInstance.isAnimation && Input.GetMouseButtonDown(0) && movementInstance.canMove)
            {
                stamina -= attackCost;
                if (stamina < 3 * maxStamina + (maxStamina / 10) && stamina >= 3 * maxStamina)
                {
                    staminaBar0.fillAmount = Mathf.Clamp((stamina - maxStamina * 3) / (maxStaminaInit / 10), 0f, 1f);
                }
                else if (stamina < 3 * maxStamina && stamina >= 2 * maxStamina)
                {
                    staminaBar0.fillAmount = 0;
                    staminaBar1.fillAmount = Mathf.Clamp(((stamina - maxStamina * 2) / maxStaminaInit), 0f, 1f);
                }
                else if (stamina < 2 * maxStamina && stamina >= maxStamina)
                {
                    staminaBar0.fillAmount = 0;
                    staminaBar1.fillAmount = 0;
                    staminaBar2.fillAmount = Mathf.Clamp(((stamina - maxStamina * 1) / maxStaminaInit), 0f, 1f);
                }
                else if (stamina < maxStamina && stamina > 0)
                {
                    staminaBar0.fillAmount = 0;
                    staminaBar1.fillAmount = 0;
                    staminaBar2.fillAmount = 0;
                    maxStamina = stamina;
                    maxStaminaOverall = (maxStamina / 10) + 3 * maxStamina;
                    staminaBar3.fillAmount = Mathf.Clamp(((stamina) / maxStaminaInit), 0f, 1f);
                }
                else
                {
                    stamina = 0;
                    staminaBar0.fillAmount = 0;
                    staminaBar1.fillAmount = 0;
                    staminaBar2.fillAmount = 0;
                    staminaBar3.fillAmount = 0;
                    Debug.Log("Homunculus has fainted");
                }

            }
        

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) 
            && movementInstance.canMove && !movementInstance.isFacingWall)
        {
            stamina -= walkCost * Time.deltaTime;
            if (stamina < 3 * maxStamina + (maxStamina / 10) && stamina >= 3 * maxStamina)
            {
                staminaBar0.fillAmount = Mathf.Clamp((stamina - maxStamina * 3) / (maxStaminaInit / 10), 0f, 1f);
            }
            else if (stamina < 3*maxStamina && stamina >= 2*maxStamina)
            {
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = Mathf.Clamp(((stamina-maxStamina*2) / maxStaminaInit),0f,1f) ;
            }
            else if (stamina < 2*maxStamina && stamina >= maxStamina)
            {   staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = 0;
                staminaBar2.fillAmount = Mathf.Clamp(((stamina-maxStamina*1) / maxStaminaInit),0f,1f) ;
            }
            else if (stamina < maxStamina && stamina > 0)
            {
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = 0;
                staminaBar2.fillAmount = 0;
                maxStamina = stamina;
                maxStaminaOverall = (maxStamina / 10) + 3 * maxStamina;
                staminaBar3.fillAmount = Mathf.Clamp(((stamina) / maxStaminaInit),0f,1f) ;
                
            }
            else
            {
                stamina = 0;
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = 0;
                staminaBar2.fillAmount = 0;
                staminaBar3.fillAmount = 0;
                Debug.Log("Homunculus has fainted");
            }
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W) 
            && movementInstance.canMove && !movementInstance.isFacingWall)
        {
            stamina -= runCost * Time.deltaTime;
            if (stamina < 3 * maxStamina + (maxStamina / 10) && stamina >= 3 * maxStamina)
            {
                staminaBar0.fillAmount = Mathf.Clamp((stamina - maxStamina * 3) / (maxStaminaInit / 10), 0f, 1f);
            }
            else if (stamina < 3*maxStamina && stamina >= 2*maxStamina)
            {
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = Mathf.Clamp(((stamina-maxStamina*2) / maxStaminaInit),0f,1f) ;
            }
            else if (stamina < 2*maxStamina && stamina >= maxStamina)
            {   staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = 0;
                staminaBar2.fillAmount = Mathf.Clamp(((stamina-maxStamina*1) / maxStaminaInit),0f,1f) ;
            }
            else if (stamina < maxStamina && stamina > 0)
            {
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = 0;
                staminaBar2.fillAmount = 0;
                maxStamina = stamina;
                maxStaminaOverall = (maxStamina / 10) + 3 * maxStamina;
                staminaBar3.fillAmount = Mathf.Clamp(((stamina ) / maxStaminaInit),0f,1f) ;
                
            }
            else
            {
                stamina = 0;
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = 0;
                staminaBar2.fillAmount = 0;
                staminaBar3.fillAmount = 0;
                Debug.Log("Homunculus has fainted");
            }
        }

        if (stamina < maxStaminaOverall && stamina!=0)
        {
            stamina += recoveryRate * Time.deltaTime;
            if (stamina < 3 * maxStamina + (maxStamina / 10) && stamina >= 3 * maxStamina)
            {
                staminaBar0.fillAmount = Mathf.Clamp((stamina - maxStamina * 3) / (maxStaminaInit / 10), 0f, 1f);
                staminaBar1.fillAmount = Mathf.Clamp((maxStamina/ maxStaminaInit),0f,1f) ;
            }
            else if (stamina < 3 * maxStamina && stamina >= 2*maxStamina)
            {
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = Mathf.Clamp(((stamina-maxStamina*2 ) / maxStaminaInit),0f,1f) ;
                staminaBar2.fillAmount = Mathf.Clamp((maxStamina / maxStaminaInit),0f,1f) ;
            }
            else if (stamina < 2 * maxStamina && stamina >= maxStamina)
            {
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = 0;
                staminaBar2.fillAmount = Mathf.Clamp(((stamina-maxStamina*1 ) / maxStaminaInit),0f,1f) ;
                staminaBar3.fillAmount = Mathf.Clamp((maxStamina / maxStaminaInit),0f,1f) ;
            }
            else if (stamina < maxStamina && stamina > 0)
            {
                staminaBar0.fillAmount = 0;
                staminaBar1.fillAmount = 0;
                staminaBar2.fillAmount = 0;
                staminaBar3.fillAmount = Mathf.Clamp(((stamina ) / maxStaminaInit),0f,1f) ;
            }
            else
            {
                stamina=maxStaminaOverall;
            }
        }
        
        Player.Instance.setStamina(stamina); 
        Player.Instance.setMaxStamina(maxStamina);
        Player.Instance.setMaxStaminaOverall(maxStaminaOverall);
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(staminaBar0.fillAmount);
            Debug.Log(staminaBar1.fillAmount);
            Debug.Log(staminaBar2.fillAmount);
            Debug.Log(staminaBar3.fillAmount);
        }
    }
}
