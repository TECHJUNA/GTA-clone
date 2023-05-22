using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSwap : MonoBehaviour
{
    public List<CinemachineVirtualCamera> AllCharacterCameras = new List<CinemachineVirtualCamera>();
    public int CameraList = 0;

    void Start()
    {
        SwapCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CameraList++;
            SwapCamera();
        }
    }

   void SwapCamera()
    {
        if(AllCharacterCameras.Count - 1 < CameraList)
        {
            CameraList = 0;
        }
        for(int i = 0; i < AllCharacterCameras.Count;i++)
        {
            if(CameraList==i) 
            {
                AllCharacterCameras[i].gameObject.SetActive(true);
            }
            else
            {
               AllCharacterCameras[i].gameObject.SetActive(false);   
            }
        }   
    }
}
