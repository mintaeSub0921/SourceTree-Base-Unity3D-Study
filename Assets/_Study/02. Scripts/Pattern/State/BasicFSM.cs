using UnityEngine;

public class BasicFSM : MonoBehaviour
{
    public enum MonsterState { Idle, Patrol, Trace, Attack }
    public MonsterState monsterState = MonsterState.Idle;

    private void Update()
    {
        switch (monsterState)
        {
            case MonsterState.Idle:
                Debug.Log("Idle : 몬스터 대기중");
                break;
            case MonsterState.Patrol:
                Debug.Log("Patrol : 몬스터 정찰중");
                break;
            case MonsterState.Trace:
                Debug.Log("Trace : 몬스터 추격중");
                break;
            case MonsterState.Attack:
                Debug.Log("Attack : 몬스터 공격중");
                break;
        }
    }

    public void SetState(MonsterState newState) // 상태변경
    {
        if (monsterState != newState)
            monsterState = newState;
    }
}
