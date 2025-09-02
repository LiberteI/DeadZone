using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

/*
    This script is responsible for managing survival days.

    There should be 10 days in total, with escalation raising gradually. For example: during the first night, generate 100
        normal zombies. During the second, generate 200 zombies with 20% of mutant... during the 5th, do an event like poisonous gas leak,
        making player have to fix filter otherwise survivors' health drops.

    develop a day & night transition system.

    during the day, zombies are less aggressive and spawned less. Scale the whole day-time into 5 minutes. the sun gradually drops and start waves during sunset.
    player could choose to skip the day. in this situation, do a smooth transition to avoid instant scene change.

    during the night zombies are aggressive and normally spawned. the night will gradually reach the dawn, when the night finishes.

    Daytime's config would stay the same but nights' changes

    Implement a simple FSM 
*/

/*
    During stage 2 dev: make a survival time loop:
    day - night - day - night ........ *

    during the day: start count down; spawn zombie; press p to skip *

    during the night: track night num; start count down; if zombie gets cleared: transition to day; *

    after 4 nights, print win. *
*/
public enum GameStateType {
    Day, Night
}
public class GameplayManager : MonoBehaviour
{   
    [SerializeField] private List<NightConfig> nights;

    [SerializeField] private DayConfig dayConfig;

    private int curNightIdx;

    private GameStateType curType;

    [SerializeField] private float curDuration;

    private bool canSkip = false;

    private bool hasWon;
    void OnEnable()
    {
        EventManager.OnClearLevel += SetCanSkip;

    }
    void OnDisable()
    {
        EventManager.OnClearLevel -= SetCanSkip;
    }
    void Start()
    {
        StartCircle();
    }

    void Update()
    {
        
        if (hasWon)
        {
            return;
        }
        UpdateDuration();

        TryUpdateCurState();

        TrySkip();

        TryWinning();
    }
    private void SetCanSkip()
    {
        canSkip = true;
    }
    private void TrySkip()
    {
        if (!canSkip)
        {
            return;
        }
        if (curType == GameStateType.Day)
        {
            if (Input.GetKeyDown("p"))
            {
                curDuration = 0;
            }
        }
        // for testing purpose:

        else
        {
            if (Input.GetKeyDown("p"))
            {
                curDuration = 0;
            }
        }

    }
    private void StartCircle()
    {   
        curType = GameStateType.Day;

        EventManager.RaiseOnBreakingDawn(dayConfig);

        curDuration = dayConfig.duration;

        curNightIdx = 0;
    }
    private void UpdateDuration()
    {
        if (curDuration > 0)
        {
            curDuration -= Time.deltaTime;
        }
    }

    private void TryUpdateCurState()
    {
        if (curDuration > 0)
        {
            return;
        }
        if (curType == GameStateType.Day)
        {
            curType = GameStateType.Night;

            EventManager.RaiseOnNightFall(nights[curNightIdx]);

            curDuration = nights[curNightIdx].duration;

            Debug.Log($"NIGHT {curNightIdx + 1}");

            curNightIdx += 1;

            canSkip = false;
        }
        else
        {
            curType = GameStateType.Day;

            EventManager.RaiseOnBreakingDawn(dayConfig);

            curDuration = dayConfig.duration;

            Debug.Log("Breaking Dawn!");

            canSkip = false;
        }
    }

    private void TryWinning()
    {
        if (hasWon)
        {
            return;
        }

        if (curNightIdx >= nights.Count)
        {
            Debug.Log("you won");
            hasWon = true;
        }
    }



}
