using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Quest
{
    public string QuestName;
    public string description;
    public List<QuestGoal> goals;

    public float xpReward;
    public int goldReward;
    public List<ItemData> itemRewards;

    public bool readyForTurnIn;

    Player player;

    public void OnAccept(Player player)
    {
        this.player = player;
        foreach(QuestGoal g in goals)
        {
            
            g.player = player;
            Debug.Log($"setting goal for {QuestName}");
            g.SetGoal();

            
        }

    }

    public void OnQuestCompletion(Player player)
    {
        player.data.OnGainXP(xpReward);
        player.data.OnGoldChange(goldReward);
        player.inventory.TryAddItems(itemRewards);
        Debug.Log($"{QuestName} has been completed!");
    }
    public void CheckCompletion()
    {
        
        foreach(QuestGoal questGoal in goals)
        {
            if(!questGoal.completed)
            {
                readyForTurnIn = false;
                break;
            }
            else
            {
                readyForTurnIn = true;
            }
        }
    }



}

[System.Serializable]
public class QuestGoal
{
    public bool completed;
    public bool active;
    public List<GoalConstraint> constraints;
    public QuestGoal nextGoal;

    public Player player;

    public enum GoalType
    {
        Kill, TalkTo, Gather, GoTo
    }

    public GoalType goalType;

    [Header("Kill Goal")]
    public int currentTotal;
    public int totalNeeded;
    public List<EnemyData.EnemyType> validTypes;

    [Space(10)]
    [Header("Gather Goal")]
    public string itemName;



    public void SetGoal()
    {
        Debug.Log("Setting goal");
        switch (goalType)
        {
            case GoalType.Kill:
                EnemyManager.Instance.OnEnemyDeath.AddListener(UpdateKill);
                break;
            case GoalType.TalkTo:
                
                break;
            case GoalType.Gather:
                player.inventory.OnItemAdded.AddListener(UpdateGather);
                break;
            case GoalType.GoTo:
                break;
            default:
                break;
        }
        
    }

    public void UpdateKill(Enemy enemy)
    {
        Debug.Log("Updating kill goal");
        if (!completed)
        {
            foreach (EnemyData.EnemyType e in enemy.data.types)
            {
                if (validTypes.Contains(e))
                {
                    currentTotal++;
                    completed = currentTotal == totalNeeded;
                    break;
                }
            }

        }

    }
    public void UpdateGather(ItemData item)
    {

    }

    public bool CheckConstraints()
    {
        bool success = true;
        foreach(GoalConstraint c in constraints)
        {
            if(!c.CheckConstraint())
            {
                success = false;
                break;
            }
        }
        return success;
    }
}
public abstract class GoalConstraint
{
    public abstract bool CheckConstraint();
}

public class TimeGoalConstraint : GoalConstraint
{
    public enum TimeOfDay
    { Day, Night}
    public List<TimeOfDay> acceptableTimes;
    public override bool CheckConstraint()
    {
        Debug.Log("Implement Time Goal Constraint");
        return true;
    }
}











