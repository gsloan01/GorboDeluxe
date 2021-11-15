using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    Player player;
    

    public List<Quest> quests;

    private void Start()
    {
        player = GetComponent<Player>();
        foreach(Quest q in quests)
        {
            Debug.Log($"Accepting {q.QuestName}");
            q.OnAccept(player);
        }
    }

    public void OnAcceptNewQuest(Quest quest)
    {
        quests.Add(quest);
        quest.OnAccept(player);

    }
}
