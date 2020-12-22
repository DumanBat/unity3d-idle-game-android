using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Artifacts : MonoBehaviour
{
    /* INFO
    1. Need to add functionality to activeArtifacts panel in scene
    2. Etot script eto ebaniy kolhoz, prosto dichayshaya cyganshina


    */

    // UI
    public Button artifactsPanelCloseButton;
    public GameObject artifactsPanel;

    // UI/DATA panel1
    public GameObject panel1;
    public Image panelImage1;
    public Text panelName1;
    public Text panelDescription1;
    public Text panelCost1;
    public static int selectedArtifactID1;
    public Button buyArtifact1;
    public GameObject activeArtifact11, activeArtifact12, activeArtifact13, activeArtifact14;
    public List<GameObject> activeArtifactList1 = new List<GameObject>();
                        

    // UI/DATA panel2
    public GameObject panel2;
    public Image panelImage2;
    public Text panelName2;
    public Text panelDescription2;
    public Text panelCost2;
    public static int selectedArtifactID2;
    public Button buyArtifact2;
    public GameObject activeArtifact21, activeArtifact22, activeArtifact23, activeArtifact24;
    public List<GameObject> activeArtifactList2 = new List<GameObject>();

    // UI/DATA panel3
    public GameObject panel3;
    public Image panelImage3;
    public Text panelName3;
    public Text panelDescription3;
    public Text panelCost3;
    public static int selectedArtifactID3;
    public Button buyArtifact3;
    public GameObject activeArtifact31, activeArtifact32, activeArtifact33, activeArtifact34;
    public List<GameObject> activeArtifactList3 = new List<GameObject>();

    // UI/DATA panel4
    public GameObject panel4;
    public Image panelImage4;
    public Text panelName4;
    public Text panelDescription4;
    public Text panelCost4;
    public static int selectedArtifactID4;
    public Button buyArtifact4;
    public GameObject activeArtifact41, activeArtifact42, activeArtifact43, activeArtifact44;
    public List<GameObject> activeArtifactList4 = new List<GameObject>();

    //DATA
    ArtifactDB artifactDB;
    public GlobalValue globalValue;
    public Bonus bonus;


    void Awake()
    {
        //DATA

        artifactDB = GetComponent<ArtifactDB>();
    }

    void Start()
    {
        //UI
        artifactsPanelCloseButton.onClick.AddListener(ArtifactsPanelClose);

        

        buyArtifact1.onClick.AddListener(ArtifactPurchase1);
        buyArtifact2.onClick.AddListener(ArtifactPurchase2);
        buyArtifact3.onClick.AddListener(ArtifactPurchase3);
        buyArtifact4.onClick.AddListener(ArtifactPurchase4);

        // active artifacts 1
        activeArtifactList1.Add(activeArtifact11);
        activeArtifactList1.Add(activeArtifact12);
        activeArtifactList1.Add(activeArtifact13);
        activeArtifactList1.Add(activeArtifact14);

        activeArtifactList2.Add(activeArtifact21);
        activeArtifactList2.Add(activeArtifact22);
        activeArtifactList2.Add(activeArtifact23);
        activeArtifactList2.Add(activeArtifact24);

        activeArtifactList3.Add(activeArtifact31);
        activeArtifactList3.Add(activeArtifact32);
        activeArtifactList3.Add(activeArtifact33);
        activeArtifactList3.Add(activeArtifact34);

        activeArtifactList4.Add(activeArtifact41);
        activeArtifactList4.Add(activeArtifact42);
        activeArtifactList4.Add(activeArtifact43);
        activeArtifactList4.Add(activeArtifact44);

        for (int i = 0; i < 4; i++)
        {
            activeArtifactList1[i].SetActive(false);
            activeArtifactList2[i].SetActive(false);
            activeArtifactList3[i].SetActive(false);
            activeArtifactList4[i].SetActive(false);
        }

        PlaceArtifactsInPanels();

    }

 
    void Update()
    {
        if (GlobalValue.globalCash >= ArtifactDB.DB[selectedArtifactID1].artifactCost)
        {
            buyArtifact1.interactable = true;
        }
        else if (GlobalValue.globalCash < ArtifactDB.DB[selectedArtifactID1].artifactCost)
        {
            buyArtifact1.interactable = false;
        }


        if (GlobalValue.globalCash >= ArtifactDB.DB[selectedArtifactID2].artifactCost)
        {
            buyArtifact2.interactable = true;
        }
        else if (GlobalValue.globalCash < ArtifactDB.DB[selectedArtifactID2].artifactCost)
        {
            buyArtifact2.interactable = false;
        }

        if (GlobalValue.globalCash >= ArtifactDB.DB[selectedArtifactID3].artifactCost)
        {
            buyArtifact3.interactable = true;
        }
        else if (GlobalValue.globalCash < ArtifactDB.DB[selectedArtifactID3].artifactCost)
        {
            buyArtifact3.interactable = false;
        }

        if (GlobalValue.globalCash >= ArtifactDB.DB[selectedArtifactID4].artifactCost)
        {
            buyArtifact4.interactable = true;
        }
        else if (GlobalValue.globalCash < ArtifactDB.DB[selectedArtifactID4].artifactCost)
        {
            buyArtifact4.interactable = false;
        }


    }



    public void PlaceArtifactsInPanels()
    {
        // tree profit multiplier, panel1
        for (int i = 0; i < artifactDB.artifactsCount; i++)
        {
            if (ArtifactDB.DB[i].artifactType == Artifact.ArtifactTypes.TreeProfitMultiplier && ArtifactDB.DB[i].isArtifactActive == true)
            {
                activeArtifactList1[i].SetActive(true);
            }


            if (ArtifactDB.DB[i].artifactType == Artifact.ArtifactTypes.TreeProfitMultiplier  && ArtifactDB.DB[i].isArtifactActive == false)
            {
                selectedArtifactID1 = i;

                panelName1.text = ArtifactDB.DB[selectedArtifactID1].artifactName;
                panelImage1 = ArtifactDB.DB[selectedArtifactID1].artifactImage;
                panelDescription1.text = ArtifactDB.DB[selectedArtifactID1].artifactDescription;
                panelCost1.text = ArtifactDB.DB[selectedArtifactID1].artifactCost.ToString();

                

                break;
            }
        }


        // all trees profit multiplier, panel2
        for (int i = 0; i < artifactDB.artifactsCount; i++)
        {
            if (ArtifactDB.DB[i].artifactType == Artifact.ArtifactTypes.AllTreesProfitMultiplier && ArtifactDB.DB[i].isArtifactActive == true)
            {
                activeArtifactList2[i].SetActive(true);
            }


            if (ArtifactDB.DB[i].artifactType == Artifact.ArtifactTypes.AllTreesProfitMultiplier && ArtifactDB.DB[i].isArtifactActive == false)
            {
                selectedArtifactID2 = i;

                panelName2.text = ArtifactDB.DB[selectedArtifactID2].artifactName;
                panelImage2 = ArtifactDB.DB[selectedArtifactID2].artifactImage;
                panelDescription2.text = ArtifactDB.DB[selectedArtifactID2].artifactDescription;
                panelCost2.text = ArtifactDB.DB[selectedArtifactID2].artifactCost.ToString();

                break;
            }
        }

        // bonus value multiplier, panel3
        for (int i = 0; i < artifactDB.artifactsCount; i++)
        {
            if (ArtifactDB.DB[i].artifactType == Artifact.ArtifactTypes.BonusValueMultiplier && ArtifactDB.DB[i].isArtifactActive == true)
            {
                activeArtifactList3[i].SetActive(true);
            }


            if (ArtifactDB.DB[i].artifactType == Artifact.ArtifactTypes.BonusValueMultiplier && ArtifactDB.DB[i].isArtifactActive == false)
            {
                selectedArtifactID3 = i;

                panelName3.text = ArtifactDB.DB[selectedArtifactID3].artifactName;
                panelImage3 = ArtifactDB.DB[selectedArtifactID3].artifactImage;
                panelDescription3.text = ArtifactDB.DB[selectedArtifactID3].artifactDescription;
                panelCost3.text = ArtifactDB.DB[selectedArtifactID3].artifactCost.ToString();

                break;
            }
        }

        // bonus frequency multiplier, panel4
        for (int i = 0; i < artifactDB.artifactsCount; i++)
        {
            if (ArtifactDB.DB[i].artifactType == Artifact.ArtifactTypes.BonusFrequencyMultiplier && ArtifactDB.DB[i].isArtifactActive == true)
            {
                activeArtifactList4[i].SetActive(true);
            }


            if (ArtifactDB.DB[i].artifactType == Artifact.ArtifactTypes.BonusFrequencyMultiplier && ArtifactDB.DB[i].isArtifactActive == false)
            {
                selectedArtifactID4 = i;

                panelName4.text = ArtifactDB.DB[selectedArtifactID4].artifactName;
                panelImage4 = ArtifactDB.DB[selectedArtifactID4].artifactImage;
                panelDescription4.text = ArtifactDB.DB[selectedArtifactID4].artifactDescription;
                panelCost4.text = ArtifactDB.DB[selectedArtifactID4].artifactCost.ToString();


                break;
            }
        }

    }


    




    // tree profit multiplier, panel1
    public void ArtifactPurchase1()
    {
        

        switch (ArtifactDB.DB[selectedArtifactID1].panelType)
        {
            case Artifact.PanelTypes.Apple:
                {
                    globalValue.appleHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.appleHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }

            case Artifact.PanelTypes.Orange:
                {
                    globalValue.orangeHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.orangeHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }

            case Artifact.PanelTypes.Strawberry:
                {
                    globalValue.strawberryHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.strawberryHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Banana:
                {
                    globalValue.bananaHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.bananaHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Mango:
                {
                    globalValue.mangoHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.mangoHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Grape:
                {
                    globalValue.grapeHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.grapeHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Blueberry:
                {
                    globalValue.blueberryHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.blueberryHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Cherry:
                {
                    globalValue.cherryHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.cherryHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Lemon:
                {
                    globalValue.lemonHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.lemonHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Peach:
                {
                    globalValue.peachHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.peachHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Melon:
                {
                    globalValue.melonHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.melonHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }
            case Artifact.PanelTypes.Watermelon:
                {
                    globalValue.watermelonHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    globalValue.watermelonHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID1].multiplier;
                    break;
                }

        }

        globalValue.CashValueChange(-ArtifactDB.DB[selectedArtifactID1].artifactCost, 0);

        ArtifactDB.DB[selectedArtifactID1].isArtifactActive = true;
        ArtifactDB.DB[selectedArtifactID1].isAvailableToBuy = false;

        PlaceArtifactsInPanels();
    }


    // all trees profit multiplier, panel2
    public void ArtifactPurchase2()
    {
        

        globalValue.appleHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.appleHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.orangeHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.orangeHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.strawberryHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.strawberryHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.bananaHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.bananaHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.mangoHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.mangoHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.grapeHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.grapeHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.blueberryHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.blueberryHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.cherryHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.cherryHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.lemonHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.lemonHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.peachHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.peachHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.melonHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.melonHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        globalValue.watermelonHarvest.tree.defaultHarvestAmountRenewed *= ArtifactDB.DB[selectedArtifactID2].multiplier;
        globalValue.watermelonHarvest.tree.harvestAmount *= ArtifactDB.DB[selectedArtifactID2].multiplier;

        // NEED TO UPDATE BLYAT
        globalValue.CashValueChange(-ArtifactDB.DB[selectedArtifactID2].artifactCost, 0);

        ArtifactDB.DB[selectedArtifactID2].isArtifactActive = true;
        ArtifactDB.DB[selectedArtifactID2].isAvailableToBuy = false;

        PlaceArtifactsInPanels();
    }

    // bonus value multiplier, panel3
    public void ArtifactPurchase3()
    {

        Bonus.cashBonusValue *= ArtifactDB.DB[selectedArtifactID3].multiplier;
        Bonus.goldBonusValue *= ArtifactDB.DB[selectedArtifactID3].multiplier;

        globalValue.CashValueChange(-ArtifactDB.DB[selectedArtifactID3].artifactCost, 0);

        ArtifactDB.DB[selectedArtifactID3].isArtifactActive = true;
        ArtifactDB.DB[selectedArtifactID3].isAvailableToBuy = false;

        PlaceArtifactsInPanels();
    }

    // bonus frequency multiplier, panel4
    public void ArtifactPurchase4()
    {
        Bonus.minTime /= ArtifactDB.DB[selectedArtifactID4].multiplier;
        Bonus.maxTime /= ArtifactDB.DB[selectedArtifactID4].multiplier;

        globalValue.CashValueChange(-ArtifactDB.DB[selectedArtifactID4].artifactCost, 0);

        ArtifactDB.DB[selectedArtifactID4].isArtifactActive = true;
        ArtifactDB.DB[selectedArtifactID4].isAvailableToBuy = false;

        PlaceArtifactsInPanels();
    }


    //UI
    public void ArtifactsPanelClose()
    {
        artifactsPanel.SetActive(false);
        LSideUIContoller.isAnyPanelisActive = false;
    }
}
