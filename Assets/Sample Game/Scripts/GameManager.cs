using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] Itemgoldlist;
    public Sprite[] JellySpritelist;
    public int[] JellyJelatinlist;
    public string[] JellyNamelist;
    public Vector3[] PointList;

    public RuntimeAnimatorController[] LevelAc;

    public void ChangeAC(Animator anim, int level)
    {
        anim.runtimeAnimatorController = LevelAc[level-1];

    }
}
