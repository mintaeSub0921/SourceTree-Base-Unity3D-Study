using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleDataManager : MonoBehaviour
{
    [Serializable]
    public class CharacterData
    {
        public string characterID;
        public string name;
        public int hp;
        public int attack;

        public CharacterData(string characterID, string name, string hp, string attack)
        {
            this.characterID = characterID;
            this.name = name;
            this.hp = int.Parse(hp);
            this.attack = int.Parse(attack);
        }
    }

    public string URL;

    public List<CharacterData> characterDatas = new List<CharacterData>();

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        Debug.Log(data);

        string[] lines = data.Split("\n");

        for (int i = 0; i < lines.Length; i++)
        {
            string[] rows = lines[i].Split(",");

            CharacterData newData = new CharacterData(rows[0], rows[1], rows[2], rows[3]);
            characterDatas.Add(newData);
        }

        Debug.Log($"파싱 완료 -> 총 {characterDatas.Count}개 데이터 완료");
    }
}