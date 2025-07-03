using UnityEngine;

public class Potion : MonoBehaviour, IItem
{
    private Inventory inventory;

    public enum PotionType { Gold, Hp, Mp }
    public PotionType potionType;
    
    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        
        Obj = gameObject;
    }
    
    void OnMouseDown()
    {
        Get();
    }

    public GameObject Obj { get; set; }

    public void Get()
    {
        Debug.Log($"{this.name}을 획득했습니다.");
        
        inventory.AddItem(this, transform);
        
        gameObject.SetActive(false);
    }

    public void Use()
    {
        switch (potionType)
        {
            case PotionType.Gold:
                // 체력과 마나 회복
                break;
            case PotionType.Hp:
                // 체력 회복
                break;
            case PotionType.Mp:
                // 마나 회복
                break;
        }
    }
}