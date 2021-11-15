using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestMenuUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon, completenessIcon;
    [SerializeField] TMP_Text title, trackingButtonTXT;
    [SerializeField] QuestInfoPage infoPage;

    [SerializeField] Sprite checkmark;
    Quest quest;

    public void SetTracking()
    {
        if(quest.tracked)
        {
            trackingButtonTXT.text = "Stop Tracking";
        }
        else
        {
            trackingButtonTXT.text = "TrackQuest";

        }
        quest.tracked = false;
    }

    public void Set(Quest quest, QuestInfoPage infopage)
    {
        infoPage = infopage;
        this.quest = quest;
        quest.OnQuestReadyToTurnIn.AddListener(OnComplete);
        icon.sprite = quest.icon;
        title.text = quest.QuestName;
    }
    public void OnComplete()
    {
        completenessIcon.sprite = checkmark;
    }
    public void OnTurnIn()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        infoPage.Set(quest);
    }
}
