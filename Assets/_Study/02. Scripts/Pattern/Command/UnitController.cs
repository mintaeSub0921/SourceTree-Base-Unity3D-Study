using UnityEngine;
using System.Collections.Generic;

public class UnitController : MonoBehaviour
{
    private Unit unit;

    private ICommand attackCommand;
    private ICommand moveCommand;
    private ICommand skillCommand;

    private Queue<ICommand> commandQueues = new Queue<ICommand>();
    private Stack<ICommand> executeCommands = new Stack<ICommand>();

    private void Awake()
    {
        unit = GetComponent<Unit>();

        attackCommand = new AttackCommand(unit);
        moveCommand = new MoveCommand(unit);
        skillCommand = new SkillCommand(unit, "FireBall");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackCommand.Execute();
            executeCommands.Push(attackCommand);
        } // 즉시 실행
        else if (Input.GetKeyDown(KeyCode.W))
        {
            moveCommand.Execute();
            executeCommands.Push(moveCommand);

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            skillCommand.Execute();
            executeCommands.Push(skillCommand);

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            commandQueues.Enqueue(attackCommand);
        } // 기능 누적
        else if (Input.GetKeyDown(KeyCode.X))
        {
            commandQueues.Enqueue(moveCommand);

        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            commandQueues.Enqueue(skillCommand);

        }

        if (Input.GetKeyDown(KeyCode.Return)) // 한번에 실행
        {
            while (commandQueues.Count > 0)
            {
                ICommand command = commandQueues.Dequeue();
                command.Execute();
                executeCommands.Push(command);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 최근에 실행한 기능 취소
        {
            if (executeCommands.Count > 0)
            {
                ICommand lastCommand = executeCommands.Pop();
                Debug.Log($"명령 취소 : {lastCommand.GetType().Name}");

                lastCommand.Cancel();

            }
            else
            {
                Debug.Log("되돌릴 명령이 없습니다");
            }
        }


    }


}
