using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SampleGame
{

    public class MonsterTable : Table
    {
        public override void Load(string path)
        {
            var list = CSVReader.Read(path);
            for (int index = 0; list.Count > index; ++index)
            {
                var dic = list[index];

                string name = dic["Name"].ToString();
                string resorucePath = dic["Path"].ToString();
                float hp = float.Parse(dic["HP"].ToString());
                float runSpeed = float.Parse(dic["RunSpeed"].ToString());
                float attackDealyTime = float.Parse(dic["AttackDealyTime"].ToString());

                MonsterRowData rowData = new MonsterRowData(index);
                rowData.Name = name;
                rowData.ResourcePath = resorucePath;
                rowData.HP = hp;
                rowData.RunSpeed = runSpeed;
                rowData.AttackDealyTime = attackDealyTime;

                Add(rowData);
            }
        }
    }
}