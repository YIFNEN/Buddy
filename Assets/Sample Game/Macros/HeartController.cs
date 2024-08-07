using UnityEngine;

public class HeartController : MonoBehaviour
{
    public float lifespan = 3f;  // 하트가 사라지기까지의 시간

    void Start()
    {
        // lifespan 시간이 지나면 하트를 제거
        Destroy(gameObject, lifespan);
    }
}
