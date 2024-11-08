using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy :  MonoBehaviour
{
    //TODO use create instance

    [Header("Equipment")]
    [SerializeField] public GenericWeaponTypeObject _weaponType;
    [SerializeField] public List<WeaponTraitsEnum> _currentEnemyTraits;

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
    [SerializeField] private int initialMovementSpeed = 0;  // Movement speed of the enemy
    [SerializeField] private int totalMana = 0; // Total mana of the enemy. 
    [SerializeField] private int totalManaRecharge = 0;  //Specific spell cost handled purely by weapon?
    [SerializeField] private int initialCastSpeed = 0; // Though primarily decided by weaponType, this could also be tweaked by type of enemy caster
    [SerializeField] private int initialDamage = 0; // Though primarily decided by weaponType, this could also be tweaked by type of enemy caster (Some enemies coat their weapons in mana)
    [SerializeField] private int initialAttackSpeed = 0;

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
    // Enemyhandler creates an enemy prefab with this script on, then passes in the weapon and enemytype scriptable(?) objects?
    
    public void InitEnemy(GenericWeaponTypeObject weaponType, GenericEnemyTypeObject enemyType, int localDifficulty) 
    {
        this._weaponType = weaponType;
        this._enemyType = enemyType;

        InitStats();
        InitTraits();
        
    }

    private void InitStats() 
    {
        totalHealth =           _enemyType._getHealth();
        totalArmour =           _enemyType._getArmour();
        initialMovementSpeed =   (int)(_enemyType._getMovementSpeed() * 
                                _weaponType._getMovementSpeedAdjustment());

        totalMana =             (int)(_enemyType._getMana() * 
                                _weaponType._getManaAdjustment());
        totalManaRecharge =     (int)(_enemyType._getManaRecharge() * 
                                _weaponType._getManaRechargeAdjustment());
        initialCastSpeed =     (int)(_enemyType._getCastSpeed() * 
                                _weaponType._getCastSpeedAdjustment());

        initialDamage =        _weaponType._getDamage();
        initialAttackSpeed =   (int)(_enemyType._getAttackSpeed() *
                                _weaponType._getAttackSpeedAdjustment());
    }

    private void InitTraits() 
    {
        //TODO choose a set of traits based on local difficulty enemy type (also is influenced by weapon type, as that is where we are gaining the list to pull from)
    }
    //EXTRA THOUGHTS

// Potentially enemies can drop their weapons for the player?

// All enemies use mana, it's just how. Some coat their weapons with it, some can perform skills. This is determined by type of enemy? 

// Default goblins coat their weapons in mana, so can't use spells, unless given more mana by a caster enemy?

// Enemy type determines what weapon type it can use

// Have a method for onKill to store damage done *Could calculate it accurately taking armour into account?

//------------------------------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------------------------------

/*
 * generic weapon
- polearm
- shortblade
- heavy_blunt

Have a modifier for each weapon (Tier system?) that affects damage and traits



generic enemy
- Horde
- Lancer
- Tank

- have enum for enemy type

2 dictionaries with the enum and values
Eg enum for enemy type, then a dict(?) of the stats
 */

 //On construction, pass in a dict (in an SO?) with possible weapons, but don't store it. (Do this with stats too? And AI?)
 // use objectYouCreate.AddComponent<ClassName>(); to add specific AI script depending on type?
    // Use interface to enforce specific AI behaviour?
 // Animation based on both weapon type and it's subtype
}

