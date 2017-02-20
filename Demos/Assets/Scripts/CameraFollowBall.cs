using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBall : MonoBehaviour
{
    void Start()
    {
        m_offset = transform.position - m_player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = m_player.transform.position + m_offset;
    }

    public GameObject m_player;
    private Vector3 m_offset;
}
