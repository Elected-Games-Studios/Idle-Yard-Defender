using UnityEngine;
using System.Collections;
public class AttackProcessor : MonoBehaviour
{
    //take in the dmg from this IHaveStats and the IHaveHealth of the target 
    //onColEnter processmelee();
    public void ProcessMelee(IHaveStats attacker, IHaveHealth target)
        {
        int amount = CalculateAttackAmount(attacker);
        ProcessAttack(target, amount);
        }
    //calculate the flat dmg X Strength stat according to player stats
    //run this on shootweapon, pass in on instantiate of bullet
    public int CalculateAttackAmount(IHaveStats attacker)
    {
        return attacker.STR;
    }
    //hurt the enemy with the damage amount.  maybe this is a delegate
    public void ProcessAttack(IHaveHealth target, int amount)
    {
        target.ModifyHealth(amount);
    }
}