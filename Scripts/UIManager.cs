using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    

    //ui references
    [SerializeField] Slider scrapSlider;
    [SerializeField] Image blackoutScreen;
    [SerializeField] Image powerupIcon1;
    [SerializeField] Image powerupIcon2;
    public GameObject GameOverScreen;
    public List<GameObject> upgradeIcons = new List<GameObject>();


    //component references
    [SerializeField] private PlayerTools playerTools;
    
    //variables
    private int upgradeDeficet;

    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
        blackoutScreen.gameObject.SetActive(true);
        blackoutScreen.DOFade(0, 0.5f);

        scrapSlider.maxValue = playerTools.scrapLevelThreshholds[0];
        //upgradeDeficet = playerTools.scrapLevelThreshholds[0];

        for (int i = 0; i < upgradeIcons.Count; i++)
        {
            upgradeIcons[i].SetActive(false);
        }

    }

    void UpdateScrapbar(int playerLevel)
    {
        upgradeIcons[playerLevel - 1].SetActive(true);
        upgradeDeficet += playerTools.scrapLevelThreshholds[playerLevel-1];
        scrapSlider.maxValue = playerTools.scrapLevelThreshholds[playerLevel];
        
    }

    void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    private void OnScrapPickedUp(int scrapAmmount)
    {
        //scrapCountText.text = scrapAmmount.ToString();
        scrapSlider.value = scrapAmmount - upgradeDeficet;
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += GameOver;
        PlayerTools.OnScrapCollected += OnScrapPickedUp;
        PlayerTools.OnPlayerLevelup += UpdateScrapbar;
    }

    private void OnDestroy()
    {
        PlayerHealth.OnPlayerDamaged -= GameOver;
        PlayerTools.OnScrapCollected -= OnScrapPickedUp;
        PlayerTools.OnPlayerLevelup += UpdateScrapbar;
    }

    
}
