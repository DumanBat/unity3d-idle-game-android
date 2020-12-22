using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactDB : MonoBehaviour
{
    public int artifactsCount;

    /*private static Dictionary<int, Artifact> _db = new Dictionary<int, Artifact>();

    public Dictionary<int, Artifact> DB { get => _db; set => _db = value; }*/

    public static SortedDictionary<int, Artifact> DB = new SortedDictionary<int, Artifact>();

    void Awake()
    {
        foreach (Artifact artifactSO in Resources.LoadAll<Artifact>("ScriptableObjects/Artifacts"))
        {
            if (!DB.ContainsKey(artifactSO.artifactID))
            {
                DB.Add(artifactSO.artifactID, artifactSO);
            }
        }

        artifactsCount = DB.Count;
    }
}
