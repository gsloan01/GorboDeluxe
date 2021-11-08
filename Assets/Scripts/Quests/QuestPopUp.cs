using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestPopUp : MonoBehaviour
{
    public TMP_Text title, description, goldReward, xpReward;
    public Quest quest;
    public void PopUp(Quest quest, bool fromDialogue)
    {
        ActivateAll();
        this.quest = quest;
        title.text = quest.QuestName;
        description.text = quest.description;
        goldReward.text = quest.goldReward.ToString();
        xpReward.text = quest.xpReward.ToString();
    }

    public void Accept()
    {
        foreach(GameObject p in PlayerManager.Instance.players)
        {
            p.GetComponent<QuestManager>().OnAcceptNewQuest(quest);
        }
        DeactivateAll();
    }



    public void ActivateAll()
    {
        title.gameObject.SetActive(true);
        description.gameObject.SetActive(true);
        goldReward.gameObject.SetActive(true);
        xpReward.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
    public void DeactivateAll()
    {
        title.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
        goldReward.gameObject.SetActive(false);
        xpReward.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

}
