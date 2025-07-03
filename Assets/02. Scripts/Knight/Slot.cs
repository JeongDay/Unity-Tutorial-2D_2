using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private IItemObject item; // 슬롯에 들어올 아이템
    [SerializeField] private Image itemImage; // 먹은 아이템의 이미지가 들어갈 위치
    [SerializeField] private Button slotButton; // 아이템 Use()를 하기 위한 버튼

    public bool isEmpty = true;
    
    void Awake()
    {
        slotButton.onClick.AddListener(UseItem);
    }

    void OnEnable() // 오브젝트가 On될 때마다 1번 실행되는 기능
    {
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void AddItem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false;
        itemImage.sprite = newItem.Icon;
        itemImage.SetNativeSize();
        
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
}