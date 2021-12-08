using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;
using UnityEngine.EventSystems;

public class DialogueSystem : MonoBehaviour, IPointerDownHandler
{

    [Header("UI Items")]
    [SerializeField] Image speakerIcon;
    [SerializeField] TMP_Text speakerName, content;
    [SerializeField] QuestPopUp questUI;
    [SerializeField] Player thisPlayer;
    AudioSource dialogueAudio;

    public Dialogue current;
    DialogueSegment currentSegment;
    public int dialogueIndex = 0;
    StringBuilder dialogueBuilder = new StringBuilder();

    [Header("Dialogue Options")]
    [SerializeField] bool charByCharDialogue = false;
    [SerializeField] float textSpeed = 5;

    int charIndex;
    bool reading;

    private void Awake()
    {
        dialogueAudio = GetComponent<AudioSource>();
        if (dialogueAudio.playOnAwake) dialogueAudio.playOnAwake = false;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        current = dialogue;
        gameObject.SetActive(true);
        
    }
    private void OnEnable()
    {
        Debug.Log("Dialogue system enabled");
        OnNextSegment();
        thisPlayer.inputHandler.OnMenuControlsActivate();
    }

    private void OnDisable()
    {
        thisPlayer.inputHandler.OnMKControlsActivate();
    }
    public void OnNextSegment()
    {
        if(dialogueIndex == 0)
        {
            Debug.Log("Starting new thing");
        }

        Debug.Log("OnNextSegment");
        if (dialogueIndex >= current.conversation.Count)
        {
            Debug.Log("conversationOver");
            gameObject.SetActive(false);
            dialogueIndex = 0;
        }
        else
        {
            currentSegment = current.conversation[dialogueIndex];
            Set(currentSegment);
            dialogueIndex++;
        }


    }

    void Set(DialogueSegment segment)
    {
        NewSound(false);
        speakerIcon.sprite = segment.speaker.speakerIcon;
        speakerName.text = segment.speaker.speakerName;
        charIndex = 0;
        dialogueBuilder.Clear();
        content.text = dialogueBuilder.ToString();
        Debug.Log("Deciding on dialogue style...");
        if (!charByCharDialogue) content.text = segment.segment;
        else
        {
            Debug.Log("Start Reading Dialogue");
            StartCoroutine(StartReadingDialogue(segment.segment));
            
        }
    }
    void NewSound(bool play = true)
    {
        if (currentSegment.speaker.sounds.Count > 0)
        {
            dialogueAudio.Stop();
            dialogueAudio.clip = currentSegment.speaker.sounds[Random.Range(0, currentSegment.speaker.sounds.Count)];
            if(play) dialogueAudio.Play();
        }
    }
    IEnumerator StartReadingDialogue(string script)
    {
        Debug.Log("StartedReading");
        reading = true;
        while(charIndex != script.Length && reading)
        {

            dialogueBuilder.Append(script[charIndex]);
            charIndex++;
            content.text = dialogueBuilder.ToString();

            NewSound();

            dialogueAudio.Play();
            yield return new WaitForSeconds(1 / textSpeed);
        }
        reading = false;
        charIndex = 0;
        OnFinishedReading();

    }
    void EndDialogue()
    {
        content.text = currentSegment.segment;
    }
    /// <summary>
    /// Will display an icon to show player can progress.
    /// </summary>
    void OnFinishedReading()
    {
        Debug.Log("FINSIHED READING");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (reading)
        {
            
            reading = false;
            charIndex = 0;
            dialogueBuilder.Clear();
            EndDialogue();
        }
        else
        {
            if (currentSegment.quest.QuestName != "")
            {
                //questUI.gameObject.SetActive(true);
                questUI.PopUp(currentSegment.quest, true);

            }
            else
            {
                OnNextSegment();
            }
            
        }

    }
}
