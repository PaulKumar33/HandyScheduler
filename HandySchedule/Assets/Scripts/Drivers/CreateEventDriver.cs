using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreateEventDriver : MonoBehaviour
{
    //UI objects
    public GameObject createEvent;
    public GameObject dispEvents;
    public List<Button> _EventButtons;

    public Button ev1;
    public Button ev2;
    public Button ev3;
    
    //public ui items
    public Dropdown months;
    public Dropdown days;

    public InputField years;
    public InputField eventName;
    public InputField Location;

    public Button createEventButton;
    public Button clearFieldsButton;

    public Text dispText;

    List<string> monthsList = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    List<string> daysList = new List<string>() { };

    EventScript ev;
    _Event Events;


    // Use this for initialization
    void Start()
    {
        Init();
    }

    private void Init()
    {
        //note when using get component you only use such when it is attached 
        months.ClearOptions();
        months.AddOptions(monthsList);

        createEventButton.onClick.AddListener(OnCreate);
        clearFieldsButton.onClick.AddListener(OnClear);

        _EventButtons = new List<Button>();
        _EventButtons.Add(ev1);
        _EventButtons.Add(ev2);
        _EventButtons.Add(ev3);
                        
        for (int i = 1; i<=31; i++)
        {
            daysList.Add(i.ToString());
        }
        days.ClearOptions();
        days.AddOptions(daysList);

        createEvent.SetActive(true);
        dispEvents.SetActive(false);
    }

    public void OnCreate()
    {
        /*
         for now, simple want to create an event object
         */
        //HandledBcall();

    }

    public void OnCreateLocalEvent()
    {
        int years = Convert.ToInt32(this.years.text);
        EventScript.current = new EventScript(eventName.text, Location.text, years, days.value, months.value, null);
        EventScript.current.CreateEventCall();
        EventScript.current.DisplayLocalEventContents(eventName.text, (bool result, string resText) =>
        {
            if (!result)
            {
                Debug.Log(resText);
                dispText.text = resText;
            }

            else if (result)
            {
                Debug.Log("Displaying the event");
                dispText.text = resText;
            }

        });
    }

    void HandledBcall()
    {
        DatabaseHandler dbHandle = new DatabaseHandler();
        dbHandle = GetComponent<DatabaseHandler>();
        //need to handle time
        string day = daysList[days.value];
        string month = monthsList[months.value];
        dbHandle.AddToDatabase(day, month, years.text, eventName.text, null, null, (result, resultString)=> {
            if (result)
            {
                Debug.Log("Succesfully created event");
            }
            else if (!result)
            {
                Debug.Log("Unable to access db. Could not make entry");
            }
        });
    }


    private void OnClear()
    {
        years.text = "Year";
        eventName.text = "Input Event Name";
        days.RefreshShownValue();
        months.RefreshShownValue();
    }
    
    public void OnDisplayEvents()
    {
        int counter = 0;
        createEvent.SetActive(false);
        dispEvents.SetActive(true);
        List<_Event> retList = new List<_Event>();
        retList = EventScript.current.DisplayEList();
        _Event hold;

        foreach(_Event e in retList)
        {
            if(counter == 3)
            {
                break;
            }
            hold = e;
            _Event.current = e;
            string name = _Event.current.Name;
            string location = _Event.current.Location;

            Button tempBut = _EventButtons[counter];
            string ev = string.Format("ev{0}", counter+1);
            GameObject.Find(ev).GetComponentInChildren<Text>().text = name + "\n" + location;
            counter++;
        }
    }

    public void OnEventClicked()
    {
        //logic for when a displayed event is chosen
    }
}