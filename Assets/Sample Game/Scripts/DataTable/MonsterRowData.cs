using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{

    [System.Serializable]
    public class MonsterRowData : RowData
    {
        public MonsterRowData(int index) : base(index)
        {
        }

        [ReadOnly] public string Name;
        [ReadOnly] public string ResourcePath;
        [ReadOnly] public float HP;
        [ReadOnly] public float RunSpeed;
        [ReadOnly] public float AttackDealyTime;
    }
}