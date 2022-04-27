using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOtherPlayers : Photon.PunBehaviour
{
    private void Awake()
    {
        // 不能動到其他玩家
        if (!photonView.isMine)
        {
            enabled = false;
        }
    }
}
