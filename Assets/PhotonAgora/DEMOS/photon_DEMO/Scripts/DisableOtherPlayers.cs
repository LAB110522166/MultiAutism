using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOtherPlayers : Photon.PunBehaviour
{
    private void Awake()
    {
        // ����ʨ��L���a
        if (!photonView.isMine)
        {
            enabled = false;
        }
    }
}
