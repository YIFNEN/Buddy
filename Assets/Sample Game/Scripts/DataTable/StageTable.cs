using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SampleGame
{

    public class StageTable : Table
    {
        public override void Load(string path)
        {
            var list = CSVReader.Read(path);
            for (int index =0; list.Count > index; ++index)
            {
                var dic = list[index];
                
                string name = dic["Name"].ToString();
                string des = dic["Des"].ToString();
                string sceneName = dic["SceneName"].ToString();

                StageRowData rowData = new StageRowData(index);
                rowData.Name = name;
                rowData.Des = des;
                rowData.SceneName = sceneName;
                rowData.WaveDatas.Add(NewWaveData(dic, "Wave1_Monster_ID", "Wave1_Time", "Wave1_Mon_Count", "Wave1_Mon_Spawn_Time"));
                rowData.WaveDatas.Add(NewWaveData(dic, "Wave2_Monster_ID", "Wave2_Time", "Wave2_Mon_Count", "Wave2_Mon_Spawn_Time"));


                Add(rowData);
            }

            StageWaveData NewWaveData(Dictionary<string, object> dic, string id, string time, string count, string spawn_time)
            {
                string wav_mon_id = dic[id].ToString();
                float wav_mon_time = float.Parse(dic[time].ToString());
                int wav_mon_count = int.Parse(dic[count].ToString());
                float wav_mon_spawn_time = float.Parse(dic[spawn_time].ToString());


                StageWaveData wave1 = new StageWaveData();
                wave1.Monster_ID = wav_mon_id;
                wave1.Mon_Spawn_Time = wav_mon_spawn_time;
                wave1.Mon_Count = wav_mon_count;
                wave1.Mon_Spawn_Time = wav_mon_spawn_time;

                return wave1;   
            }
        }
    }
}