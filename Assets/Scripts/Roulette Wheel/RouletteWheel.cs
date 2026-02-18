using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class RouletteWheel : MonoBehaviour
{
    // Variables
    #region Variables

    [Header("Wheel Info")]
    [SerializeField] public Wheel wheelDefinition;
    public List<RoulettePocket> pockets;

    [Header("Prefabs")]
    [SerializeField] private PocketObject pocketObject;

    [DoNotSerialize] public SpinContext context;

    #endregion


    // Events
    #region Events

    public event Action OnSpinStart;
    public event Action OnSpinning;
    public event Action<RoulettePocket> OnSpinResolved;
    public event Action AfterSpinResolved;

    #endregion



    // Functions
    #region Functions

    private void Awake()
    {
        pockets = new List<RoulettePocket>(wheelDefinition.pockets);
        GenerateWheel();
        RunManager.Instance.currentWheel = this;
    }

    #region Generation

    public void GenerateWheel()
    {
        PocketObject[] objects = FindObjectsByType<PocketObject>(FindObjectsSortMode.None);

        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i].gameObject);
        }
        
        float offset = 360f / pockets.Count;
        
        for (int i = 0; i < pockets.Count; i++)
        {
            PocketObject o = Instantiate(pocketObject, transform);

            o.SetPocket(pockets[i]);

            o.SetPosition(i, offset);
        }
    }

    public void AddNewPocket(RoulettePocket pocket)
    {
        pockets.Add(pocket);

        GenerateWheel();
    }

    #endregion



    #region Spinning logic and events

    public void Spin()
    {
        context = new SpinContext(pockets);

        // spin start event
        SpinStart();

        // during spin if needed
        DuringSpin();

        //spin end event
        RoulettePocket result = GetRandomPocketFromContext(context);
        ResolveSpin(result);
        print("Number of pockets: " + context.pockets.Count);

        AfterSpin();
    }

    // test function
    private RoulettePocket GetRandomPocketFromContext(SpinContext context)
    {
        int index = UnityEngine.Random.Range(0, context.pockets.Count);
        return context.pockets[index];
    }

    private void SpinStart()
    {
        OnSpinStart?.Invoke();
    }

    private void DuringSpin()
    {
        OnSpinning?.Invoke();
    }

    private void ResolveSpin(RoulettePocket pocket)
    {
        OnSpinResolved?.Invoke(pocket);
    }

    private void AfterSpin()
    {
        AfterSpinResolved?.Invoke();
    }

    #endregion



    #endregion
}
