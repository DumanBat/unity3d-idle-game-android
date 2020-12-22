using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Artifact", menuName = "ScriptableObjects/Artifact", order = 3)]
public class Artifact : ScriptableObject
{
    public int artifactID;

    public string artifactName;
    public string artifactDescription;
    public Image artifactImage;

    public enum ArtifactTypes { TreeProfitMultiplier, AllTreesProfitMultiplier,  BonusValueMultiplier, BonusFrequencyMultiplier};
    public ArtifactTypes artifactType;

    public enum PanelTypes {nothing, Apple, Orange, Strawberry, Banana, Mango, Grape, Blueberry, Cherry, Lemon, Peach, Melon, Watermelon};
    public PanelTypes panelType;

    public int multiplier;
    public bool isArtifactActive;
    public bool isAvailableToBuy;

    public int artifactCost;
}
