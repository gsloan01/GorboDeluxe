using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGoalUI : MonoBehaviour
{
    [SerializeField] TMP_Text goalTxt;
    [SerializeField] Image marker;

    public void Set(QuestGoal goal)
    {
        if(goal.customGoalText != "")
        {
            goalTxt.text = goal.customGoalText;
        }
        else
        {
            switch (goal.goalType)
            {
                case QuestGoal.GoalType.Kill:
                    goalTxt.text = $"{goal.currentTotal} / {goal.totalNeeded} {goal.validTypes[0].ToString()}s killed";
                    break;
                case QuestGoal.GoalType.TalkTo:
                    goalTxt.text = $"Speak to {goal.characterName}";
                    break;
                case QuestGoal.GoalType.Gather:
                    goalTxt.text = $"{goal.totalNeeded} / {goal.currentTotal} {goal.itemName}s gathered";
                    break;
                case QuestGoal.GoalType.GoTo:
                    goalTxt.text = $"Go to {goal.areaName}";

                    break;
                default:
                    break;
            }
        }
        
    }
}
