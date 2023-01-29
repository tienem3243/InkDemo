using UnityEngine.EventSystems;
using RichTextSubstringHelper;
using System.Collections;
using DG.Tweening;
using System;
using UnityEngine;

using System.Collections.Generic;

namespace Dialog
{
    public partial class DialogManager
    {
        //display choice
        private IEnumerator DisplayLine(String line)
        {
            Debug.Log(line);
            lineDisplaying = true;
            dialogText.text = "";
            for (int i = 0; i < line.RichTextLength(); i++)
            {
                dialogText.text = line.RichTextSubString(i + 1);
                yield return new WaitForSeconds(textSpeed);
            }
            yield return lineDisplaying = false;
        }
        [ContextMenu("hide")]
        private void HideChoice()
        {

            dialogPanel.GetComponent<RectTransform>()
                    .DOSizeDelta(DISPLAY_VECTOR, 0.5f, false)
                    .SetEase(Ease.OutCubic);
        }
        private void DisplayChoice()
        {
            Debug.Log("Hide Choose");
            dialogPanel.GetComponent<RectTransform>()
             .DOSizeDelta(DEFAULT_SIZE_DELTA_DIALOG, 0.5f, true)
             .SetEase(Ease.OutCubic);
        }
   
   
        private void DisplayChoices()
        {
            List<String> currentChoices = GetChoice();
            if (currentChoices.Count > choices.Length)
            {
                Debug.LogWarning("More choice was given than UI support" + currentChoices.Count);
            }
            int index = 0;
            foreach (String choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choiceText[index].text = choice;
                index++;
            }
            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
            StartCoroutine(SelectFirstChoice());

            if (!isChoiceAble)
            {
                return;
            }
            DisplayChoice();
        }

        private IEnumerator SelectFirstChoice()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }

        public void MakeChoice(int choiceindex)
        {
            CurrentStory.ChooseChoiceIndex(choiceindex);
            if (!isChoiceAble)
                HideChoice();


        }
    }
}