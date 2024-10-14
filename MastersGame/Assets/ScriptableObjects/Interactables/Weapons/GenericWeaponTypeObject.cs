using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObject/Gear/Weapons")]
public class GenericWeaponTypeObject : ScriptableObject 
{   
    // Stored as floats as most of these values will be low and used as multipliers for values given by the enemy type
    // An exception to this is damage on hit, which is purely calculated by the weapon. 
    [SerializeField] private int damage = 0; 
    [SerializeField] private float attackSpeedModifier = 0;
    [SerializeField] private float movementSpeedModifier = 0;  // This stat will probably be only used for casters or heavy weapon users?
    [SerializeField] private float manaModifier = 0; 
    [SerializeField] private float manaRechargeModifier = 0;  
    [SerializeField] private float castSpeedModifier = 0; 
    private WeaponSubtypeEnum weaponSubtype; // Dictates the weapons subtype. Can't currently think of a use.
    private Dictionary<int, WeaponTraitsEnum> weaponTraits; //List of all possible traits for this type of weapon (the int is their rank)

    //[SerializeField] private Sprite weaponSprite;
    
    // Using a dictionary to make the code more readable as the performance decrease is negligable at this size.
    // TODO create dictionaries in generic enemyHandler class(?) that store different weapon type stats. These could be loaded in via Json?

    //Takes in a set of stats for the weapon type (eg: stats for a dagger), that weapon's subtype (mostly for debug purposes), and the possible traits for a weapon of that type.
    public void Init(Dictionary<EntityStatEnum, float> weaponTypeStats, WeaponSubtypeEnum weaponSubtype, Dictionary<int, WeaponTraitsEnum> weaponTraits)
    {
        damage                  = (int)weaponTypeStats[EntityStatEnum.DAMAGE];
        attackSpeedModifier     = weaponTypeStats[EntityStatEnum.ATTACK_SPEED];

        movementSpeedModifier   = weaponTypeStats[EntityStatEnum.MOVEMENT_SPEED];

        manaModifier            = weaponTypeStats[EntityStatEnum.MANA];
        manaRechargeModifier    = weaponTypeStats[EntityStatEnum.MANA_RECHARGE];
        castSpeedModifier       = weaponTypeStats[EntityStatEnum.CAST_SPEED];

        this.weaponSubtype      = weaponSubtype;
        this.weaponTraits       = weaponTraits;
    }

    public int _getDamage() { return this.damage; }
    public float _getAttackSpeedAdjustment() { return this.attackSpeedModifier; }
    public float _getMovementSpeedAdjustment() { return this.movementSpeedModifier; }
    public float _getManaAdjustment() { return this.manaModifier; }
    public float _getManaRechargeAdjustment() { return this.manaRechargeModifier; }
    public float _getCastSpeedAdjustment() { return this.castSpeedModifier; }
    public WeaponSubtypeEnum _getWeaponSubType() { return this.weaponSubtype; }
    public Dictionary<int, WeaponTraitsEnum> _getWeaponPossibleTraits() { return this.weaponTraits; }
}
