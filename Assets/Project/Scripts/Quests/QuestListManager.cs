using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListManager : MonoBehaviour
{
    [SerializeField] QuestManager playersQuests;
    [SerializeField] GameObject QuestListPanel;
    [SerializeField] QuestMenuUI questMenuPrefab;
    [SerializeField] QuestInfoPage infoPage;
    List<Quest> activeQuests = new List<Quest>();
    private void OnEnable()
    {
        foreach(Quest quest in playersQuests.quests)
        {
            if(!activeQuests.Contains(quest))
            {
                QuestMenuUI newQuestUI = Instantiate(questMenuPrefab, QuestListPanel.transform);
                newQuestUI.Set(quest, infoPage);
                activeQuests.Add(quest);
            }
        }
    }
    private void OnDisable()
    {
        //get rid of them
    }
}
