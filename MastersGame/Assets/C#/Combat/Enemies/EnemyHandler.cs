using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    List<GenericEnemy> currentRoomEnemies;

    // Start is called before the first frame update
    void Start()
    {
        currentRoomEnemies = new List<GenericEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    // public void initCombatRoom(GameDifficultyEnum localDifficulty, RoomTypeEnum currentRoomType) 
    // {
    //     //Construct a scriptable object instance that holds data of current room. This is done so a player can leave a room, and come back with enemies still saved there
           // TODO look into potential procedural generation of small "dungeons" for each node on a map. (Do this in another script though) 
    // }
}
