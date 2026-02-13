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



    #endregion




    // Functions

    #region Functions


    #region Betting Slider

    private void OnBetAmountChanged(float x)
    {
        bettingAmountText.text = $"Bet Amount: {x}";
    }

    #endregion


    #region Built in functions

    private void Start()
    {
        betSlider.maxValue = RunManager.Instance.chips;
        betSlider.onValueChanged.AddListener(OnBetAmountChanged);
    }

    #endregion


    #endregion
}
