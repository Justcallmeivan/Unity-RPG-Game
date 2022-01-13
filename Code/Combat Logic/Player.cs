using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Comabatant
{
    public string weapon = "Sword";
    public Combat combat;
    public void equipWeapon(string weapon)
    {
        this.weapon = weapon;
    }
    public void attack()
    {
        combat.turn(new Action("Attack", weapon));
    }
    public void run()
    {
        combat.turn(new Action("Run", weapon));
    }
    public void block()
    {
        combat.turn(new Action("Block", weapon));
    }
}
