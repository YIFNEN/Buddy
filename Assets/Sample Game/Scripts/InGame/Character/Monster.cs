using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SampleGame.InGame
{
    public partial class Monster : MonoBehaviour
    {
        public MonsterRowData rowData;


        public float HP => rowData.HP;
        public float AttackDelayTime => rowData.AttackDealyTime;
        public float RunSpeed => rowData.RunSpeed;

        private void Awake()
        {
        }

        private void Start()
        {
        }

        public void SetRowData(MonsterRowData data)
        {
            rowData = data;
        }
    }
}
