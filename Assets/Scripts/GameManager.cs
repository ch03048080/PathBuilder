using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
// 霸烙 概聪历 包府 (教臂沛)
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
 
    public static GameManager Instance
    {
        get
        {
            if (_instance == null) _instance = new GameManager();
            return _instance;
        }
    }

    //public GameState CurrentState { get; private set; } = GameState.Init; 
    public EnergyManager energyManager { get; private set; }
    public AntManager antManager { get; private set; }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        InitGame();
    }

    private void InitGame()
    {
        energyManager = FindAnyObjectByType<EnergyManager>();
        antManager = FindAnyObjectByType<AntManager>();

        energyManager.Init();
        antManager.Init();

    }

}
