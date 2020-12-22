using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeDB : MonoBehaviour
{

    public static SortedDictionary<int, Tree> treeDataBase = new SortedDictionary<int, Tree>();



    void Awake()
    { 
        foreach (Tree tree in Resources.LoadAll<Tree>("ScriptableObjects/Trees"))
        {
            if (!treeDataBase.ContainsKey(tree.treeID))
            {
                treeDataBase.Add(tree.treeID, tree);
                
            }
        }

        
        /*for (int i = 0; i < treeDataBase.Count; i++)
        {
            Debug.Log(treeDataBase[i] + " element in tree data base number " + i);
        }*/
    }
}
