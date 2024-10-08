using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/NPCs/EnemyData")]
public class GenericEnemyData : ScriptableObject 
{
    //TODO use create instance

    [Header("Equipment")]
    [SerializeField] public GenericWeaponTypeObject _weaponType;

    [Header("EnemyType")]
    [SerializeField] public GenericEnemyTypeObject _enemyType;

    [Header("Initial Stat Values")]
    /* 
        All of these stats can be affected by enemyType, whether it is corrupted, and their weapon. 
        If not mentioned here, then the stat can be found by checking the dedicated enemy type SO or weapon type SO

        These stats will not be changed during runtime and are purely for visual debugging and intial setup.
    */
    [SerializeField] private int totalHealth = 0;
    [SerializeField] private int totalArmour = 0; // Armour is the amount of damage done to one piece of health. Potentially useful for bosses? Could be useless
    [SerializeField] private int intialMovementSpeed = 0;  // Movement speed of the enemy
    [SerializeField] private int totalMana = 0; // Total mana of the enemy. 
    [SerializeField] private int totalManaRecharge = 0;  //Specific spell cost handled purely by weapon?
    [SerializeField] private int intialCastSpeed = 0; // Though primarily decided by weaponType, this could also be tweaked by type of enemy caster
    [SerializeField] private int intialDamage = 0; // Though primarily decided by weaponType, this could also be tweaked by type of enemy caster (Some enemies coat their weapons in mana)
    [SerializeField] private int intialAttackSpeed = 0;

    [Header("Changable Stat Values")]
    /* 
        Though similar to the stats above, these stats can be changed during play due to certain factors, eg if an enemy is slowed.
        TODO changes to these stats are stored in an array of tuples? ->
        TODO -> (Sorted by change duration?) (change duration, stat changed, amount changed) and reverted when time is up or enemy dies 
    */
    public int _currentHealth = 0;
    public int _currentArmour = 0;
    public int _currentMovementSpeed = 0;
    public int _currentMana = 0;
    public int _currentManaRecharge = 0;
    public int _currentCastSpeed = 0;
    public int _currentDamage = 0;
    public int _currentAttackSpeed = 0;


    // This scriptable object is created whenever a new enemy is needed.
    // Corrupted enemies can increase health, damage or other stats?
    public void Init(GenericWeaponTypeObject weaponType, GenericEnemyTypeObject enemyType) 
    {
        this._weaponType = weaponType;
        this._enemyType = enemyType;

        
        //TODO get any weapon based stat adjustments and apply them to the base enemy stats
        //TODO in enemyType SO (and weaponType) create a getEnemyStat(Func<string, int> getStatMethod) that gets a specific stat depending on the given method name
        totalHealth =           _enemyType._getHealth();
        totalArmour =           _enemyType._getArmour();
        intialMovementSpeed =   (int)(_enemyType._getMovementSpeed() * 
                                _weaponType._getMovementSpeedAdjustment());

        totalMana =             (int)(_enemyType._getMana() * 
                                _weaponType._getManaAdjustment());
        totalManaRecharge =     (int)(_enemyType._getManaRecharge() * 
                                _weaponType._getManaRechargeAdjustment());
        _currentCastSpeed =     (int)(_enemyType._getCastSpeed() * 
                                _weaponType._getCastSpeedAdjustment());

        _currentDamage =        _weaponType._getDamage();
        _currentAttackSpeed =   (int)(_enemyType._getAttackSpeed() *
                                _weaponType._getAttackSpeedAdjustment());
    }

    //EXTRA THOUGHTS

    // Potentially enemies can drop their weapons for the player?

    // All enemies use mana, it's just how. Some coat their weapons with it, some can perform skills. This is determined by type of enemy? 

    // Default goblins coat their weapons in mana, so can't use spells, unless given more mana by a caster enemy?

    // Enemy type determines what weapon type it can use

    // Have a method for onKill to store damage done *Could calculate it accurately taking armour into account?
    
}

