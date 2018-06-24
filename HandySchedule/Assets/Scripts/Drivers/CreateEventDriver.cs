﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreateEventDriver : MonoBehaviour
{
    //public ui items
    public Dropdown months;
    public Dropdown days;

    public InputField years;
    public InputField eventName;
    public InputField Location;

    public Button createEventButton;
    public Button clearFieldsButton;

    List<string> monthsList = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    List<string> daysList = new List<string>() { };


    // Use this for initialization
    void Start()
    {
        Init();
    }

    private void Init()
    {
        /*months = GetComponent<Dropdown>();
        days = GetComponent<Dropdown>();
        years = GetComponent<InputField>();*/
        //note when using get component you only use such when it is attached 
        months.ClearOptions();
        months.AddOptions(monthsList);

        createEventButton.onClick.AddListener(OnCreate);
        clearFieldsButton.onClick.AddListener(OnClear);
        
        for (int i = 0; i<=31; i++)
        {
            daysList.Add(i.ToString());
        }
        days.ClearOptions();
        days.AddOptions(daysList);
        
    }

    public void OnCreate()
    {
        //flow for adding the event to the db
        HandledBcall();

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

    void Update()
    {

    }


}