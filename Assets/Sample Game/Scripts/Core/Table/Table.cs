

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SampleGame
{
    public class Table
    {
        private List<RowData> rows = new List<RowData>();



        public virtual void Load(string path)
        {
        }

        public T GetRowDataByIndex<T>(int index) where T : RowData
        {
            return rows[index] as T;
        }

        protected void Add(RowData data)
        {
            rows.Add(data);
        }
    }
}