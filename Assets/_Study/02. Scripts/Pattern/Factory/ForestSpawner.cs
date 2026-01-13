using System.Collections;
using UnityEngine;



public class ForestSpawner : MonsterFactory
{
    protected override MonsterCore CreateMonster(string type)
    {
        MonsterCore monster = null;
        switch (type)
        {
            case "Slime":
                monster = new Slime();
                break;
            case "Orc":
                monster = new Orc();
                break;
        }

        return monster;
    }

}
