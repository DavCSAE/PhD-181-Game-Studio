using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Singleton;

    [SerializeField] InteractionIcons icons;



    Animator anim;

    [SerializeField] GameObject talkPopUp;
    [SerializeField] Image talkIcon;

    [SerializeField] GameObject nextPopUp;
    [SerializeField] Image nextIcon;

    GameObject currentPopUp;

    private void Awake()
    {
        Singleton = this;
    }

    private void OnEnable()
    {
        PlayerEvents.InputDeviceChangeEvent += UpdateIcons;

        PlayerEvents.StartDialogueEvent += ShowNextPopUp;

        PlayerEvents.EndDialogueEvent += ShowTalkPopUp;
    }

    private void OnDisable()
    {
        PlayerEvents.InputDeviceChangeEvent -= UpdateIcons;

        PlayerEvents.StartDialogueEvent -= ShowNextPopUp;

        PlayerEvents.EndDialogueEvent -= ShowTalkPopUp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTalkPopUp()
    {
        HidePopUp();

        talkPopUp.SetActive(true);
        currentPopUp = talkPopUp;
    }

    public void ShowNextPopUp()
    {
        HidePopUp();

        nextPopUp.SetActive(true);
        currentPopUp = nextPopUp;

        print(1);
    }

    public void HidePopUp()
    {
        if (currentPopUp == null) return;

        currentPopUp.SetActive(false);
        currentPopUp = null;

        print(2);
    }

    void UpdateIcons()
    {
        string currDevice = InputManager.Singleton.GetCurrentDevice();

        print("Update Icons: " + currDevice);

        if (currDevice == "keyboard")
        {
            print("Keyboard icons!");
            talkIcon.sprite = icons.eIcon;
            nextIcon.sprite = icons.eIcon;
        }
        else if (currDevice == "gamepad")
        {
            print("Gamepad icons!");
            talkIcon.sprite = icons.northButtonIcon;
            nextIcon.sprite = icons.southButtonIcon;
        }
    }
}
