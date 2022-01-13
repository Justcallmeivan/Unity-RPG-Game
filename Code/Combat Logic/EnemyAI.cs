using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Comabatant
{
    public string weapon;

    public EnemyAI(string weapon)
    {
        this.weapon = weapon;
    }
    public Action doAction()
    {
        return new Action("Attack", weapon);
    }
}
