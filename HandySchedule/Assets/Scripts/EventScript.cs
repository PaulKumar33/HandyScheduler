using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class EventScript : MonoBehaviour {

    struct PublicEvent
    {
        public string Name;
        public string Location;
        public string Time;

        public int Year;
        public int Month;
        public int Day;
    };

    //important globals belonging to the class
    string eName;
    string eLocation;
    string eTime;

    int eYear;
    int eMonth;
    int eDay;

    List<PublicEvent> eventList;

    //


    public EventScript(string eventName, string eventLocation, int eventYear, int eventDay, int eventMonth, string eventTime)
    {
        /*
         * creates an instance of an event object. Should handle multiple events
         */

        //initialize a list to hold event structures in case of multiple events and initialize it null
        eventList = new List<PublicEvent>();        

        //stores all the information of the event
        this.eName = eventName;
        this.eLocation = eventLocation;
        this.eTime = eventTime;

        this.eYear = eventYear;
        this.eMonth = eventMonth;
        this.eDay = eventDay;
    }

    public void CreateEventCall()
    {
        PublicEvent ev = CreateEventObject();
        eventList.Add(ev);
    }

    private PublicEvent CreateEventObject()
    {
        PublicEvent eventNew;

        eventNew.Name = eName;
        eventNew.Location = eLocation;
        eventNew.Time = eTime;
        eventNew.Day = eDay;
        eventNew.Month = eMonth + 1;
        eventNew.Year = eYear;

        return eventNew;
    }

    public void DisplayLocalEventContents(string eventName, Action<bool, string> callback)
    {
        /*
         *Displays the content of a given event given the event name
         */
        string nameHold = null;
        if (eventList != null)
        {
            foreach (PublicEvent element in eventList)
            {
                nameHold = element.Name;
                if (nameHold == eventName)
                {
                    //display contents of structure
                    string res;
                    Debug.Log("Event Name: " + element.Name);
                    Debug.Log("Event Location: " + element.Location);
                    Debug.Log("Time of the event: "+element.Time);
                    Debug.Log("");
                    Debug.Log("");
                    Debug.Log("");

                    res = string.Format("Event Name: {0} \n" +
                        "Event Location: {1} \n" +
                        "Time of the Event: {2} \n" +
                        "{3}/{4}/{5}", element.Name, element.Location, element.Time, element.Day, element.Month, element.Year);

                    callback(true, res);
                    return;
                }
                else
                    continue;
            }

            Debug.Log("No Such Event Exists. Try another name");
            callback(false, "No Such Event Exists. Try another name");
        }
        else
        {
            Debug.Log("Event List is null. No events exist");
            callback(false, "Event List is null. No events exist");
        }
    }

    public bool EditLocalEvent(string eventName, string eventLocation = null, string eventTime = null, int eventYear = 0, int eventDay = 0, int eventMonth = 0)
    {
        foreach(PublicEvent element in eventList)
        {

        }
        return false;
    }

}
