using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataArtifacts : MonoBehaviour
{


    public static List<bool> isArtifactActiveList = new List<bool>();



    public static void SaveArtifactsData()
    {
        for (int i = 0; i < ArtifactDB.DB.Count; i++)
        {
            isArtifactActiveList.Add(ArtifactDB.DB[i].isArtifactActive);
        }
    }
}
