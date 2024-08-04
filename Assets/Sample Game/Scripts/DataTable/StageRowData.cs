using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{
    public class StageWaveData
    {
        public string Monster_ID;
        public float Time;
        public int Mon_Count;
        public float Mon_Spawn_Time;
    }

    public class StageRowData : RowData
    {
        public StageRowData(int index) : base(index)
        {
        }
        public string Name;
        public string Des;
        public string SceneName;

        public List<StageWaveData> WaveDatas = new List<StageWaveData>();
    }
}