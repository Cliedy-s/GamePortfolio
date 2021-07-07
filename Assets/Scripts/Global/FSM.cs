using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eState
{
    STATE_NONE = -1, 
    STATE_STAND = 0, 
    STATE_MOVE, 
    STATE_ATTACK, 
}

public enum eEvent
{ 
    EVENT_STOPTOMOVE = 0,
    EVENT_STOPTOPATTACK = 1,
    EVENT_MOVETOSTOP,
    EVENT_MOVETOATTACK,
    EVENT_ATTACKTOMOVE,
    EVENT_ATTACKTOSTOP
}


public class FSM 
{
    Dictionary<eState, Dictionary<eEvent, eState>> stateList =
        new Dictionary<eState, Dictionary<eEvent, eState>>();

    eState curState;

    public eState CURSTATE
    {
        get { return curState; }
        set { curState = value; }
    }

    public FSM() { }

    public void AddState( eState _curState, eEvent inputEvent, eState _outState )
    {
        if(stateList.ContainsKey(_curState) )
        {
            stateList[_curState].Add(inputEvent, _outState);
        }
        else
        {
            Dictionary<eEvent, eState> list = new Dictionary<eEvent, eState>();
            list.Add(inputEvent, _outState);
            stateList.Add(_curState, list);
        }
    }
    
    public eState? GetOutState(eEvent inputEvent)
    {
        Dictionary<eEvent, eState> list = stateList[curState];

        eState outState;
        if( list.TryGetValue(inputEvent, out outState ) )
        {
            return list[inputEvent];
        }
        return null;
    }

    public void SetTransition( eEvent Event )
    {
        Dictionary<eEvent, eState> list = stateList[curState];
        eState result;
        if( list.TryGetValue( Event, out result ) )
        {
            curState = result;
        }
    }

    public void DisplayData()
    {
        foreach( KeyValuePair< eState, Dictionary<eEvent, eState> > one in stateList )
        {
            string str = one.Key.ToString() + "\n";

            foreach( KeyValuePair<eEvent, eState> o in one.Value )
            {
                str += "       " + o.Key.ToString() + " " + o.Value.ToString() + "\n";
            }

            Debug.Log(str);
        }
    }

}
