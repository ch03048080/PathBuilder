using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum States
    {
        Empty,      // 아무것도 없는 흙
        Tunnel,     // 통로
        Chamber,    // 방
        Resource,   // 자원이 있는 타일
        Wall        // 팔 수 없는 벽
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
