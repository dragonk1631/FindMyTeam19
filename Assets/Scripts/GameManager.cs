using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Slider timerBarSlider;
    [SerializeField] private Text levelValueText;
    public Transform board;
    public GameObject card;
    private float maxTime = 30.0f;
    private float currentTime;
    private int startLevel = 1;
    public int currentLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void Start()
    {
        currentLevel = startLevel;
        board.GetComponent<CardSpawner>().SetCard(currentLevel);
        currentTime = maxTime;
        timerBarSlider.maxValue = maxTime;
        timerBarSlider.value = currentTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        timerBarSlider.value = currentTime;
        levelValueText.text = currentLevel.ToString();
    }
}
