using UnityEngine;

public class JellyClick : MonoBehaviour
{
    public GameObject heartPrefab;  // 하트 프리팹을 연결할 변수
    public float heartSpawnOffset = 0.5f;  // 하트가 생성될 위치 조정

    void OnMouseDown()
    {
        // 하트 생성 위치 계산
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-heartSpawnOffset, heartSpawnOffset), Random.Range(-heartSpawnOffset, heartSpawnOffset), 0);

        // 하트를 생성
        Instantiate(heartPrefab, spawnPosition, Quaternion.identity);
    }
}
