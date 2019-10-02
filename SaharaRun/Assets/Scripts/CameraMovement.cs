using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject m_Camera;
    float m_RotateSpeed = 40f, m_MoveSpeed = 5.7f;
    [SerializeField] Transform m_TopPos, m_DownPos;
    private bool m_Rotating = false, m_Up = false;

    public bool _Rotating
    {
        get
        {
            return m_Rotating;
        }
        set
        {
            m_Rotating = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Rotating && !m_Up)
        {
            RotateCamera(new Vector3(90,0,0), new Vector3(transform.position.x, m_TopPos.position.y, m_TopPos.position.z));
        }
        if (m_Rotating && m_Up)
        {
            RotateCamera(new Vector3(0, 0, 0), new Vector3(transform.position.x, m_DownPos.position.y, m_DownPos.position.z));
        }


        MoveCamera();
    }

    void MoveCamera()
    {
         m_Camera.transform.position += new Vector3(10f * Time.deltaTime, 0f);

    }

    void RotateCamera(Vector3 Rotation, Vector3 Position)
    {
        Vector3 up = Position;

        transform.position = Vector3.MoveTowards(transform.position, up, m_MoveSpeed * Time.deltaTime);

        Vector3 to = Rotation;
        if (Vector3.Distance(m_Camera.transform.eulerAngles, to) > 0.01f)
        {
            m_Camera.transform.eulerAngles = Vector3.MoveTowards(transform.rotation.eulerAngles, to, m_RotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = to;
            m_Rotating = false;
            m_Up = !m_Up;
        }
    }
}
