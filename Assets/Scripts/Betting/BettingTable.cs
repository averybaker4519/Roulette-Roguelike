using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BettingTable : MonoBehaviour
{
    // Variables

    #region Variables

    [Header("Betting Amount")]
    [SerializeField] private TextMeshProUGUI bettingAmountText;
    [SerializeField] private Slider betSlider;

    [Header("Button Prefab")]
    [SerializeField] private GameObject bettingButtonObject;

    [Header("Straight Pocket Button Generation")]
    [SerializeField] private RectTransform straightButtonContainer;

    [Header("Zero Pocket Button Generation")]
    [SerializeField] private RectTransform zeroButtonContainer;

    #endregion




    // Functions

    #region Functions


    #region UI Functions

    public void UpdateUI()
    {
        betSlider.maxValue = RunManager.Instance.chips;
    }

    private void OnBetAmountChanged(float x)
    {
        bettingAmountText.text = $"Bet Amount: {x}";
    }

    private Color GetPocketColor(RoulettePocket pocket)
    {
        return pocket.baseColor switch
        {
            RoulettePocket.PocketColor.RED => Color.red,
            RoulettePocket.PocketColor.BLACK => Color.black,
            RoulettePocket.PocketColor.GREEN => Color.green,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    #endregion



    #region Betting Button Population

    public void GenerateBettingButtons()
    {
        PopulateStraightPockets();
        PopulateZeroPockets();
    }

    public void PopulateStraightPockets()
    {
        foreach (var pocket in RunManager.Instance.currentWheel.pockets)
        {
            if (pocket.baseNumber == 0) continue; // skip 0, as it is not a valid straight bet

            var button = Instantiate(bettingButtonObject, straightButtonContainer);
            button.transform.localScale = Vector3.one;

            // setting text
            TextMeshProUGUI buttonTextObject = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonTextObject.text = pocket.baseNumber.ToString();
            buttonTextObject.enableAutoSizing = true;

            // setting bet info
            BettingButton bettingScript = button.GetComponent<BettingButton>();
            bettingScript.parentBettingTable = this;
            bettingScript.betType = BetType.Straight;
            bettingScript.number = pocket.baseNumber;
            button.GetComponent<Image>().color = GetPocketColor(pocket);
        }
    }

    public void PopulateZeroPockets()
    {
        foreach (var pocket in RunManager.Instance.currentWheel.pockets)
        {
            if (pocket.baseNumber != 0) continue;

            var button = Instantiate(bettingButtonObject, zeroButtonContainer);
            button.transform.localScale = Vector3.one;

            // setting text
            TextMeshProUGUI buttonTextObject = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonTextObject.text = pocket.baseNumber.ToString();
            buttonTextObject.enableAutoSizing = true;

            // setting bet info
            BettingButton bettingScript = button.GetComponent<BettingButton>();
            bettingScript.parentBettingTable = this;
            bettingScript.betType = BetType.Straight;
            bettingScript.number = pocket.baseNumber;
            button.GetComponent<Image>().color = GetPocketColor(pocket);
        }
    }

    #endregion



    #region Built in functions

    private void Start()
    {
        betSlider.maxValue = RunManager.Instance.chips;
        betSlider.onValueChanged.AddListener(OnBetAmountChanged);

        var wheel = RunManager.Instance.currentWheel;
        wheel.AfterSpinResolved += AfterSpinResolved;

        GenerateBettingButtons();
    }


    private void AfterSpinResolved()
    {
        UpdateUI();
    }

    #endregion


    #endregion
}
