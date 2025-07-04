using UnityEngine;
using System.Linq;

public class CardSpawner : MonoBehaviour
{
    public GameObject card;
    //public Transform board;

    private int cardCount;
    private int column = 4;
    private int row = 1;

    private int index = -1;

    // 인수로 받아온 레벨값을 바탕으로 카드를 게임보드에 세팅
    public void SetCard(int level) 
    {
        row = level + 1;                // 난이도에 따라서 열값 세팅
        cardCount = column * row;
        int cardPair = cardCount / 2;
        
        // 배열에 값을 세팅
        int[] arr = new int[cardCount];
        for (int i = 0; i < (cardPair); i++)
        { 
            arr[++index] = i;       // 이부분 코딩을 좀더 우아하게
            arr[++index] = i;       // 알기쉽긴 한데....
        }
        // 배열을 이용해서 카드를 생성하고 인덱스를 부여
        arr = arr.OrderBy(x => Random.Range(0, cardPair)).ToArray();
        for (int i = 0; i < cardCount; i++) 
        {
            float x = (i % column) * 1.47f;     // 최적값은 노가다로 알아냄....
            float y = (i / column) * 1.2f;      // 보드의 값을 가져와서 수학식으로 걔산한 아주 우아한 코드를 짜고 싶다....

            // 생성된 카드를 보드의 중앙으로 이동시키는 보정값
            float plusX = 7.5f;                 // 보드의 값을 받아와서 맞춰서 보정하는 수준의 코드작성이 필요함
            float plusY = -1.8f;
            GameObject go = Instantiate(card, this.transform);
            go.transform.position = new Vector2(x + plusX, y + plusY);
        }

        Debug.Log("현재레벨 : " + level);
        Debug.Log("총 카드 수 : " + cardCount);
        Debug.Log("배열 길이: " + arr.Length);                  // 배열의 길이 출력
        Debug.Log("배열 값: " + string.Join(", ", arr));       // 배열의 모든 값 출력 (한 줄에 콤마로 구분)


    }
}
