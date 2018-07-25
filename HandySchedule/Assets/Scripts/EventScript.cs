using System.Collections;
using UnityEngine;
using System.Collections.Generic;

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


    private EventScript(string eventName, string eventLocation, int eventYear, int eventDay, int eventMonth, string eventTime)
    {
        /*
         * creates an instance of an event object. Should handle multiple events
         */

        //initialize a list to hold event structures in case of multiple events and initialize it null
        eventList = new List<PublicEvent>();
        eventList = null;

        //stores all the information of the event
        eName = eventName;
        eLocation = eventLocation;
        eTime = eventTime;

        eYear = eventYear;
        eMonth = eventMonth;
        eDay = eventDay;
    }

    private PublicEvent CreateEventObject()
    {
        PublicEvent eventNew;

        eventNew.Name = eName;
        eventNew.Location = eLocation;
        eventNew.Time = eTime;
        eventNew.Day = eDay;
        eventNew.Month = eMonth;
        eventNew.Year = eYear;

        return eventNew;
    }

    public bool DisplayLocalEventContents(string eventName)
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
                    return true;
                    print("Event Name: " + element.Name);
                    print("Event Location: " + element.Location);
                    print("Time of the event: "+element.Location);
                    print("");
                    print("");
                    print("");
                }
                else
                    continue;
            }

            print("No Such Event Exists. Try another name");
            return false;
        }
        else
        {
            Debug.Log("Event List is null. No events exist");
            return false;
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
