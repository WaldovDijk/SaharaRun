using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject m_Camera;
    Quaternion m_Rotation;
    [SerializeField] float m_RotateSpeed;
    void Start()
    {
        m_RotateSpeed = m_RotateSpeed * Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Rotation = m_Camera.transform.rotation;

        m_Camera.transform.position += new Vector3(10f * Time.deltaTime,0f);
        RotateCamera();
        Debug.Log(m_Rotation.x);
    }

    void RotateCamera()
    {
        if(m_Rotation.x == 0 ||
            m_Rotation.x < 90)
        {
            m_Camera.transform.Rotate(m_RotateSpeed, 0f, 0f, Space.Self);
        }

        if (m_Rotation.x == 90 &&
            m_Rotation.x > 0)
        {
            m_Camera.transform.Rotate(-m_RotateSpeed, 0f, 0f, Space.Self);
        }


    }
}
