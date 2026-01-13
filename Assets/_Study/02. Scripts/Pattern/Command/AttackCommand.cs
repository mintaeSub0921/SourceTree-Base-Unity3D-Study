
using UnityEngine;

public class AttackCommand : ICommand
{
    public Unit unit;

    public AttackCommand(Unit unit)
    {
        this.unit = unit;
    }

    public void Cancel()
    {
        unit.AttackCancel();
    }

    public void Execute()
    {
        unit.Attack();
    }
}

