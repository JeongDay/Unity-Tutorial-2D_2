using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTimeUI;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // playTimeUI.text = string.Format("플레이 시간 : {0:F0}초", timer);
        
        playTimeUI.text = $"플레이 시간 : {timer:F0}초";
    }
}