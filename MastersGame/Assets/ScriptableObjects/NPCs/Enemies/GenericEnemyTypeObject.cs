using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObject/NPCs/Enemies/Types")]
public class GenericEnemyTypeObject : ScriptableObject 
{
    [SerializeField] private int health = 0;
    [SerializeField] private int armour = 0; 
    [SerializeField] private int movementSpeed = 0;  
    [SerializeField] private int mana = 0; 
    [SerializeField] private int manaRecharge = 0;  
    [SerializeField] private int castSpeed = 0; 
    [SerializeField] private int attackSpeed = 0;
    private bool isCorrupted;
    private EnemySubtypeEnum enemySubtype; //Dictates the weapons an enemy is able to use.

    //[SerializeField] private Sprite enemySprite;
    
    // Using a dictionary to make the code more readable as the performance decrease is negligable at this size.
    // TODO create dictionaries in generic enemyHandler class that store different enemy type stats. These could be loaded in via Json?
    public void Init(bool isCorrupted, Dictionary<EntityStatEnum, int> enemyTypeStats, EnemySubtypeEnum enemySubtype)
    {
        //Corruption gives a multiplier to all(?) stats of an enemy (Or maybe depends on enemytype?)
        health              = enemyTypeStats[EntityStatEnum.HEALTH];
        armour              = enemyTypeStats[EntityStatEnum.ARMOUR];
        movementSpeed       = enemyTypeStats[EntityStatEnum.MOVEMENT_SPEED];

        mana                = enemyTypeStats[EntityStatEnum.MANA];
        manaRecharge        = enemyTypeStats[EntityStatEnum.MANA_RECHARGE];
        castSpeed           = enemyTypeStats[EntityStatEnum.CAST_SPEED];

        attackSpeed         = enemyTypeStats[EntityStatEnum.ATTACK_SPEED];

        this.enemySubtype   = enemySubtype;
    }

    public int _getHealth() { return this.health; }
    public int _getArmour() { return this.armour; }
    public int _getMovementSpeed() { return this.movementSpeed; }
    public int _getMana() { return this.mana; }
    public int _getManaRecharge() { return this.manaRecharge; }
    public int _getCastSpeed() { return this.castSpeed; }
    public int _getAttackSpeed() { return this.attackSpeed; }
    public EnemySubtypeEnum _getEnemySubType() { return this.enemySubtype; }
}
