using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    public Slot[] slots;

    public void DropItem(Vector3 dropPos)
    {
        // 랜덤 아이템 설정
        var randomIndex = Random.Range(0, items.Length);

        // 아이템 생성
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        // 랜덤한 방향으로 힘을 가하는 기능
        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        // 랜덤한 회전으로 힘을 가하는 기능
        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        foreach (var slot in slots) // 모든 슬롯에 대해서
        {
            if (slot.isEmpty) // 슬롯이 비어있을 경우
            {
                slot.AddItem(item);
                break;
            }
        }
    }
}