using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestInfoPage : MonoBehaviour
{
    [SerializeField] TMP_Text title, description;
    [SerializeField] List<QuestGoalUI> goalUIs = new List<QuestGoalUI>();

    private void OnEnable()
    {
        if(PlayerManager.Instance.player.TryGetComponent<QuestManager>( out QuestManager qm))
        {
            if(qm.quests.Count > 0) Set(qm.quests[0]);

        }
    }

    public void Set(Quest quest)
    {
        foreach(var v in goalUIs)
        {
            v.gameObject.SetActive(false);
        }
        title.text = quest.QuestName;
        description.text = quest.description;
        for (int i = 0; i < goalUIs.Count; i++)
        {
            if(i < quest.goals.Count)
            {
                goalUIs[i].Set(quest.goals[i]);
                goalUIs[i].gameObject.SetActive(true);
            }
            else
            {
                goalUIs[i].gameObject.SetActive(false);
            }
            
        }
    }
}
