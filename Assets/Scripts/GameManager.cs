using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform board;
    public GameObject card;

    public int currentLevel = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }    
        
    }

    void Start()
    {
        board.GetComponent<CardSpawner>().SetCard(currentLevel);
    }

    void Update()
    {
        
    }

}
