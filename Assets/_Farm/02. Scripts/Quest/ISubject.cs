using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    //List<IObserver> observers { get; }

    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyListener(string questName);
}
