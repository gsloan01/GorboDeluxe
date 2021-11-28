using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListManager : MonoBehaviour
{
    [SerializeField] QuestManager playersQuests;
    [SerializeField] GameObject QuestListPanel;
    [SerializeField] QuestMenuUI questMenuPrefab;
    [SerializeField] QuestInfoPage infoPage;
    private void OnEnable()
    {
        foreach(Quest quest in playersQuests.quests)
        {
            QuestMenuUI newQuestUI = Instantiate(questMenuPrefab, QuestListPanel.transform);
            
            newQuestUI.Set(quest, infoPage);
        }
    }
    private void OnDisable()
    {
        //get rid of them
    }
}
