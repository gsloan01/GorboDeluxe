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
    public bool tracked;
    public bool readyForTurnIn;
    public bool mainQuest;
    public Sprite icon;
    public UnityEvent OnQuestCompletionEvent;
    public AudioClip QuestSFX;
    Player player;

    
    public void OnAccept(Player player)
    {
        this.player = player;
        foreach(QuestGoal g in goals)
        {
            
            g.player = player;
            Debug.Log($"setting goal for {QuestName}");
            g.SetGoal();
            g.GoalsUpdated.AddListener(CheckCompletion);
            Debug.Log($"{QuestName} accepted");

        }

    }

    public void OnQuestCompletion(Player player)
    {
        Debug.Log("Quest Completed");
        player.data.OnGainXP(xpReward);
        player.data.OnGoldChange(goldReward);
        if(itemRewards != null) if(itemRewards.Count > 0) player.inventory.TryAddItems(itemRewards);
        PlayerManager.Instance.player.GetComponent<QuestManager>().quests.Remove(this);
        PlayerManager.Instance.player.GetComponent<Player>().OnQuestComplete(QuestName.ToUpper() + " COMPLETED");
        if (QuestSFX != null) SFXManager.Instance.PlaySFX(QuestSFX, player.transform);
        
    }
    public void CheckCompletion()
    {
        bool completion = true;
        foreach(QuestGoal questGoal in goals)
        {
            if(!questGoal.completed)
            {
                completion = false;
                break;
            }

        }
        if (completion) OnQuestCompletion(player);
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
    public string customGoalText = "";

    [Header("Kill Goal")]
    public int currentTotal;
    public int totalNeeded;
    public List<EnemyData.EnemyType> validTypes;

    [Space(10)]
    [Header("Gather Goal")]
    public string itemName;

    [Space(10)]
    [Header("Talk To Goal")]
    public string characterName;

    [Space(10)]
    [Header("Go To Goal")]
    public string areaName;
    public UnityEvent GoalsUpdated;
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
                    completed = (currentTotal == totalNeeded);
                    break;
                }
            }
        }
        Debug.Log("Invoking GoalsUpdatedEvent");
        GoalsUpdated.Invoke();

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











