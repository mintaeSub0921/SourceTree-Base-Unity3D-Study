using System;
using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class XMLParser : MonoBehaviour
{
    [Serializable]
    public class CharacterData
    {
        public string CharID;
        public string Name;
        public int HP;
        public int Attack;

        public CharacterData() { }

        public CharacterData(string CharID, string Name, int HP, int Attack)
        {
            this.CharID = CharID;
            this.Name = Name;
            this.HP = HP;
            this.Attack = Attack;
        }

    }

    [Serializable]
    [XmlRoot("Characters")]
    public class CharacterList
    {
        [XmlElement("Character")]
        public List<CharacterData> Characters;
    }

    [SerializeField] private List<CharacterData> characterDatas = new List<CharacterData>();

    private void Start()
    {
        TextAsset dataFile = Resources.Load<TextAsset>("XMLData");
        string data = dataFile.text;

        ParsingData(data);

    }

    private void ParsingData(string data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(CharacterList));

        using (StringReader reader = new StringReader(data))
        {
            CharacterList loadedData = (CharacterList)serializer.Deserialize(reader); // Deserialize 역직렬화

            characterDatas = loadedData.Characters;
        }

        foreach (var characterData in characterDatas)
        {
            Debug.Log($"{characterData.CharID} / {characterData.Name} / {characterData.HP} / {characterData.Attack}");
        }
    }

    

}
