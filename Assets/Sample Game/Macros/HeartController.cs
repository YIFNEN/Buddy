using UnityEngine;

public class HeartController : MonoBehaviour
{
    public float lifespan = 3f;  // ��Ʈ�� ������������ �ð�

    void Start()
    {
        // lifespan �ð��� ������ ��Ʈ�� ����
        Destroy(gameObject, lifespan);
    }
}
