using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectHandler : MonoBehaviour
{
    public List<ActiveStatChange> statChangeQueue;
    
    //Call this every (custom) gametick. For every 5 fixed updates called, 1 tick passes?
    //TODO use event system with this.
    void TickUpdate()
    {

        //Sorts the list of tuples by remaining duration first

        //FIIIIIIIX THIIIIIS
        //Need to change from tuples as they are immutable. Custom class? Need way to sort it
        // https://stackoverflow.com/questions/3163922/sort-a-custom-class-listt lambda expression for it
        statChangeQueue.Sort((a, b) => a.getStatChangedDuration().CompareTo(b.getStatChangedDuration()));
        for (int i = 0; i < statChangeQueue.Count; i++) 
        {
            //Minuses 1 from the duration
            statChangeQueue[i].updateStatDuration();
            if (statChangeQueue[i].getStatChangedDuration() == 0)
            {
                statChangeQueue.RemoveAt(i);
            }
        }
    }

    public bool updateStat(EntityStatEnum adjustedStat, int duration, int adjustmentAmount) 
    {
        // (EntityStatEnum, int, int) statChangeTuple = (adjustedStat, duration, adjustmentAmount);
        // statChangeQueue.Add(statChangeTuple);

        return true;
    }
}
