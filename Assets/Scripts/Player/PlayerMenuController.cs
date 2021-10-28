using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    public GameObject lastVisitedPanel;
    public GameObject CharacterPanel, InventoryPanel, QuestPanel, OptionsPanel, SkillsPanel;

    private void Awake()
    {
        lastVisitedPanel = InventoryPanel;
    }

    private void OnEnable()
    {
        if(lastVisitedPanel == CharacterPanel)
        {
            CharacterPanel_OnClick();
        }
        else if(lastVisitedPanel == InventoryPanel)
        {
            InventoryPanel_OnClick();
        }
        else if (lastVisitedPanel == QuestPanel)
        {
            QuestPanel_OnClick();
        }
        else if (lastVisitedPanel == OptionsPanel)
        {
            OptionsPanel_OnClick();
        }
        else if (lastVisitedPanel == SkillsPanel)
        {
            SkillsPanel_OnClick();
        }
    }

    public void CharacterPanel_OnClick()
    {
        Debug.Log("Character Panel Button Clicked");
        if(CharacterPanel)
        {
            CharacterPanel.SetActive(true);
            InventoryPanel?.SetActive(false);
            //QuestPanel?.SetActive(false);
            //OptionsPanel?.SetActive(false);
            //SkillsPanel?.SetActive(false);

            lastVisitedPanel = CharacterPanel;
        }
    }
    public void InventoryPanel_OnClick()
    {

        //Debug.Log("Inventory Panel Button Clicked");
        if(InventoryPanel)
        {
            InventoryPanel.SetActive(true);
            CharacterPanel?.SetActive(false);
            //QuestPanel?.SetActive(false);
            //OptionsPanel?.SetActive(false);
            //SkillsPanel?.SetActive(false);
            lastVisitedPanel = InventoryPanel;
        }
    }
    public void QuestPanel_OnClick()
    {
        if(QuestPanel)
        {
            QuestPanel.SetActive(true);
            CharacterPanel?.SetActive(true);
            InventoryPanel?.SetActive(false);
            OptionsPanel?.SetActive(false);
            SkillsPanel?.SetActive(false);
            lastVisitedPanel = QuestPanel;
        }
    }
    public void OptionsPanel_OnClick()
    {
        if(OptionsPanel)
        {
            OptionsPanel.SetActive(true);
            CharacterPanel?.SetActive(false);
            InventoryPanel?.SetActive(false);
            QuestPanel?.SetActive(false);
            SkillsPanel?.SetActive(false);
            lastVisitedPanel = OptionsPanel;
        }
    }
    public void SkillsPanel_OnClick()
    {
        if(SkillsPanel)
        {
            SkillsPanel.SetActive(true);
            CharacterPanel?.SetActive(false);
            InventoryPanel?.SetActive(false);
            QuestPanel?.SetActive(false);
            OptionsPanel?.SetActive(false);
            lastVisitedPanel = SkillsPanel;
        }
    }
}
