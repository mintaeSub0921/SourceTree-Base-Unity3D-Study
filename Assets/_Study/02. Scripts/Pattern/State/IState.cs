using UnityEngine;

public interface IState
{
    void StateUpdate(MonoBehaviour mono);
    void StateEnter(MonoBehaviour mono);
    void StateExit(MonoBehaviour mono);
}

