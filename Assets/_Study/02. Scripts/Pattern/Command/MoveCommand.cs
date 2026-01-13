using UnityEngine;

public class MoveCommand : ICommand
{
    public Unit unit;

    public MoveCommand(Unit unit)
    {
        this.unit = unit;
    }

    public void Cancel()
    {
        unit.MoveCancel();
    }

    public void Execute()
    {
        unit.Move();
    }
}
