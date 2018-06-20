using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEventDriver : MonoBehaviour
{
    //public ui items
    public Dropdown months;
    public Dropdown days;

    public InputField years;
    public InputField eventName;

    public Button createEventButton;
    public Button clearFieldsButton;


    // Use this for initialization
    void Start()
    {
        Init();
    }

    private void Init()
    {
        List<string> monthsList = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        /*months = GetComponent<Dropdown>();
        days = GetComponent<Dropdown>();
        years = GetComponent<InputField>();*/
        //note when using get component you only use such when it is attached 
        months.ClearOptions();
        months.AddOptions(monthsList);

        createEventButton.onClick.AddListener(OnCreate);
        clearFieldsButton.onClick.AddListener(OnClear);

        List<string> daysList = new List<string>() { };
        for (int i = 0; i<=31; i++)
        {
            daysList.Add(i.ToString());
        }
        days.ClearOptions();
        days.AddOptions(daysList);
        
    }

    private void OnCreate()
    {
        //flow for adding the event to the db
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