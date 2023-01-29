
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using System;
using System.Linq;
namespace Dialog
{
    public partial class DialogManager
    {
        public static DialogManager GetInstance()
        {
            return instance;
        }

        private List<String> GetChoice()
        {
            List<String> currentChoices = CurrentStory.currentChoices.Select(p => p.text).ToList();
            return currentChoices;
        }
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Found more than 1 Dialog Manager");
            }
            instance = this;

        }

        private void Start()
        {
            dialogIsPlaying = false;
            dialogPanel.SetActive(false);

            choiceText = new TextMeshProUGUI[choices.Length];
            int index = 0;
            foreach (GameObject choice in choices)
            {
                choiceText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        }
        private void Update()
        {
            if (!dialogIsPlaying) return;
            if (InputManager.getInstance().GetSubmitPresseed())
            {
                Debug.Log("cast");
                ContinudeStory();
            }
        }

        //Dialog Manager Method
        public void EnterDiaglogMode(TextAsset inkJSON)
        {
            CurrentStory = new Story(inkJSON.text);
            dialogIsPlaying = true;
            dialogPanel.SetActive(true);
            ContinudeStory();
        }

        private void ExitDialogMode()
        {
            dialogIsPlaying = false;
            dialogPanel.SetActive(false);
            dialogText.text = "";
        }
        public void ContinudeStory()
        {
            if (CurrentStory.canContinue)
            {
                if (currentDialog != null)
                {
                    StopCoroutine(currentDialog);
                }
                //Quick complete dialog typing
                if (lineDisplaying)
                {
                    dialogText.text = currentLine;
                    lineDisplaying = false;
                }
                //Continude story
                else
                {
                    //continude
                    currentLine = CurrentStory.Continue();
                    //typing
                    currentDialog = StartCoroutine(DisplayLine(currentLine));
                    //choice
                    DisplayChoices();
                    //tag handler
                    HandlerTag(CurrentStory.currentTags);
                }


            }
            else
            {
                ExitDialogMode();
            }
        }


        //tag
        private void HandlerTag(List<string> currentTags)
        {
              RectTransform rt= StoryContext.GetComponent<RectTransform>();
            if(currentTags.Count==0)   {
                //hardcode
                Debug.Log("chuhe");
              
                RectTransformExtensions.SetRight(rt,23,0.4f);
            }else{
                RectTransformExtensions.SetRight(rt,210,0.4f);
            }   
            foreach (String tag in currentTags)
            {
                String[] slitTag = tag.Split(":");
                if (slitTag.Length != 2)
                {
                    Debug.Log("Tag could not be approximately parse" + tag);
                    return;
                }
                String key = slitTag[0].Trim();
                String value = slitTag[1].Trim();
                switch (key)
                {
                    case PORTRAIT_TAG:
                        portrait.sprite = Resources.Load<Sprite>("Character/" + value + "/default");
                        Debug.Log(value);
                        break;
                    case LAYOUT_TAG:
                        Debug.Log(value);
                        break;
                    case SPEAKER_TAG:
                        characterName.text = value;
                        Debug.Log(value);
                        break;
                    default:
                      
                        break;
                }
            }
        }
        //choice


    }
}
