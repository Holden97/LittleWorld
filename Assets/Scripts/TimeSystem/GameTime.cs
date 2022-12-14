using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameTime
{
    public int year;
    public int quad;
    public int day;
    public int hour;
    public int minute;
    public int second;

    public GameTime(int year, int quad, int day, int hour, int minute, int second)
    {
        this.year = year;
        this.quad = quad;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

    public void AddOneDay()
    {
        day++;
        EventCenter.Instance.Trigger(EventEnum.DAY_CHANGE.ToString(), this);
        if (day >= 30)
        {
            day = 1;
            quad++;
            EventCenter.Instance.Trigger(EventEnum.QUAD_CHANGE.ToString(), this);
            if (quad >= 15)
            {
                quad = 1;
                year++;
                EventCenter.Instance.Trigger(EventEnum.YEAR_CHANGE.ToString(), this);
                if (year >= 10000)
                {
                    year = 0;
                }
            }
        }
    }

    public void AddTick()
    {
        EventCenter.Instance.Trigger(nameof(EventEnum.GAME_TICK), this);

        second++;
        EventCenter.Instance.Trigger(EventEnum.SECOND_CHANGE.ToString(), this);
        if (second >= 60)
        {
            second = 0;
            minute++;
            EventCenter.Instance.Trigger(EventEnum.MINUTE_CHANGE.ToString(), this);
            if (minute >= 60)
            {
                minute = 0;
                hour++;
                EventCenter.Instance.Trigger(EventEnum.HOUR_CHANGE.ToString(), this);
                if (hour >= 24)
                {
                    hour = 0;
                    AddOneDay();
                }
            }
        }
    }
}