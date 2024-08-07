using UnityEngine;

public class JellyClick : MonoBehaviour
{
    public GameObject heartPrefab;  // ��Ʈ �������� ������ ����
    public float heartSpawnOffset = 0.5f;  // ��Ʈ�� ������ ��ġ ����

    void OnMouseDown()
    {
        // ��Ʈ ���� ��ġ ���
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-heartSpawnOffset, heartSpawnOffset), Random.Range(-heartSpawnOffset, heartSpawnOffset), 0);

        // ��Ʈ�� ����
        Instantiate(heartPrefab, spawnPosition, Quaternion.identity);
    }
}
