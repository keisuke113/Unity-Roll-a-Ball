using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // 球のオブジェクト

    private Vector3 offset; // 球からカメラまでの距離

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
