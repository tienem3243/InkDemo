using UnityEngine;
using TMPro;
using Ink.Runtime;
using System;
using UnityEngine.UI;
namespace Dialog{
public partial class DialogManager : MonoBehaviour
{
    [Header("Dialog UI")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject StoryContext;
    private static DialogManager instance;
    [SerializeField] private Story CurrentStory;
    private bool dialogIsPlaying;
    private String currentLine;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choiceText;

    private bool isChoiceAble
    {
        get
        {
            Debug.Log(CurrentStory.currentChoices.Count);
            return CurrentStory.currentChoices.Count > 0 ? true : false;
        }
    }
    private float textSpeed = 0.05f;
    private Coroutine currentDialog;
    [SerializeField] private bool lineDisplaying;
    public bool getDialogIsPlaying { get => dialogIsPlaying; private set => dialogIsPlaying = value; }

    #region Const
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string DISPLAY_CHOICE = "DisplayChoice";
    private const string DEFAULT = "Default";
    private const string HIDE_CHOICE = "HideChoice";
    #endregion
    //Character Info UI
    [SerializeField] Image portrait;
    [SerializeField] TextMeshProUGUI characterName;
    //animation
    [SerializeField] Animator portrailAnimator;
    private Vector2 DISPLAY_VECTOR = new Vector2(635, 357.2f);
    private Vector2 DEFAULT_SIZE_DELTA_DIALOG = new Vector2(635, 264.88f);
    private Vector2 DEFAULT_SIZE_DELTA_STORY_CONTEXT = new Vector2(0,0);

    private Vector2 FUL_FILL_STORY_CONTEXT = new Vector2(0, 0);
 
    
}

   
}
