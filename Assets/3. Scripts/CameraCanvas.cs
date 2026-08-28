using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used: UI들이 카메라 캔버스를 주로 이용하니, 카메라 캔버스의 위치 등을 찾기 위한 스크립트.
/// </summary>
public class CameraCanvas : MonoBehaviour
{
    public static CameraCanvas Instance;

    public Transform cameraTransform;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
