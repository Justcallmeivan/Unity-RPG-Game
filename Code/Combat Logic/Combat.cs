using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class Combat : MonoBehaviour
{
    public string EnemyWeaponType;
    float damageInflicted;
    float damageReceived;
    bool isEnd;
    bool isEnemyTurn;
    public EnemyAI enemy;

    // Start is called before the first frame update
    void Start()
    {
       
            if (isEnemyTurn)
            {
                enemy.doAction();
                
            }
            else if (!isEnemyTurn)
            {

            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turn(Action action)
    {

        if (isEnemyTurn)
        {
            if (action.Equals("Attack"))
            {
                //attack player with enemy weapon
            }
            isEnemyTurn = false;
            //make all buttons accessible
            //text says your turn
        } else
        {
            if (action.Equals("Attack"))
            {
                //attack enemy with player selected weapon
            }
            isEnemyTurn = true;
            //make all buttons inaccessible
            //text says enemy turn
            //start coroutine
            if ()
            
        }
    }

    IEnumerator turn2()
    {
        yield return new WaitForSeconds(3f);
        enemy.doAction();
    }

    /*Player Attack Function
     *Player has weapon equipped
     *if weapon is strong against enemy weapon type do 10*1.75 damage
     *if weapon is weak against enemy weapon type do 10*.75 damage
     */
    float attack(string WeaponType)
    {
        damageInflicted = (float)10.0;
        //Axe weapon options
        if (WeaponType.Equals("Axe") && EnemyWeaponType.Equals("Lance"))
        {
            damageInflicted = (float)(10.0 * 1.75);
        }
        else if (WeaponType.Equals("Axe") && EnemyWeaponType.Equals("Sword"))
        {
            damageInflicted = (float)(10.0 * .75);
        }
        else if (WeaponType.Equals("Axe") && EnemyWeaponType.Equals("Axe"))
        {
            damageInflicted = (float)(10.0);
        }
        else if (WeaponType.Equals("Sword") && EnemyWeaponType.Equals("Axe"))
        {
            damageInflicted = (float)(10.0 * 1.75);
        }
        else if (WeaponType.Equals("Sword") && EnemyWeaponType.Equals("Lance"))
        {
            damageInflicted = (float)(10.0 * .75);
        }
        else if (WeaponType.Equals("Sword") && EnemyWeaponType.Equals("Sword"))
        {
            damageInflicted = (float)(10.0);
        }
        else if (WeaponType.Equals("Lance") && EnemyWeaponType.Equals("Sword"))
        {
            damageInflicted = (float)(10.0 * 1.75);
        }
        else if (WeaponType.Equals("Lance") && EnemyWeaponType.Equals("Axe"))
        {
            damageInflicted = (float)(10.0 * .75);
        }
        else if (WeaponType.Equals("Lance") && EnemyWeaponType.Equals("Lance"))
        {
            damageInflicted = (float)(10.0);
        }
        return damageInflicted;
    }
}
