

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{
    public class RowData
    {
        public RowData(int index)
        {
            this.Index = index;
        }

        public int Index { get; private set; }
    }
}