using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//[ExecuteInEditMode()]
public class LoadingScreenProgressBar : MonoBehaviour
{
    public GameObject loadingCanvas;


    // Progress bar
    public float minimumProgress;
    public float maximumProgress;
    public float currentProgress;

    public Image mask;
    public Image fill;
    public Color color;

    void Awake()
    {
        minimumProgress = 0;
        currentProgress = 0;
        maximumProgress = 5;
        loadingCanvas.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine("LoadingProgressBar");
    }

    void Update()
    {

        GetCurrentFill();


    }

    void GetCurrentFill()
    {

        float currentOffset = currentProgress - minimumProgress;
        float maximumOffset = maximumProgress - minimumProgress;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }

    IEnumerator LoadingProgressBar()
    {
        yield return new WaitForSeconds(0.5f);
        currentProgress = 0.5f;
        yield return new WaitForSeconds(1);
        currentProgress = 2.5f;
        yield return new WaitForSeconds(2);
        currentProgress = 4.5f;
        yield return new WaitForSeconds(0.5f);
        currentProgress = 5f;
        yield return new WaitForSeconds(Random.Range(2f,3f));

        loadingCanvas.SetActive(false);
    }
}
