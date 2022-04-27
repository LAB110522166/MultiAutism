using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class ManualPhotonViewAllocator : MonoBehaviour
{

    Color currentColor;
    Color currColor;
    Vector3 tempColor = new Vector3(0, 0, 0);
    int timer = 0;

    //方法1
    void Awake()
    {
        currentColor = GetComponent<Renderer>().material.color;
    }
    void Update()
    {
        PhotonView pv = this.gameObject.GetPhotonView();
        if (currentColor != GetComponent<Renderer>().material.color)
        {
            if(timer >= 10)
            {
                timer = 0;
                currentColor = GetComponent<Renderer>().material.color;
                pv.RPC("SetColor", PhotonTargets.AllBuffered, new Vector3(currentColor.r, currentColor.g, currentColor.b));
            }
            else
            {
                timer++;
            }

        }
        else
        {
            timer = 0;
        }
    }
    [PunRPC]
    public void SetColor(Vector3 trueColor)
    {
        Color truelyColor = new Color(trueColor.x, trueColor.y, trueColor.z);
        currentColor = truelyColor;
        GetComponent<Renderer>().material.color = truelyColor;
    }
    /*
    //方法2和3
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //方法2傳出端
            currColor = GetComponent<Renderer>().material.color;
            tempColor = new Vector3(currColor.r, currColor.g, currColor.b);
            stream.SendNext(tempColor);
            
            //方法3傳出端
            currColor = GetComponent<Renderer>().material.color;
            tempColor = new Vector3(currColor.r, currColor.g, currColor.b);
            stream.Serialize(ref tempColor);
        }
        else
        {
            //方法2接收端
            tempColor = (Vector3)stream.ReceiveNext();
            GetComponent<Renderer>().material.color = new Color(tempColor.x, tempColor.y, tempColor.z);
            
            //方法3接收端
            tempColor = Vector3.zero;
            stream.Serialize(ref tempColor);
            GetComponent<Renderer>().material.color = new Color(tempColor.x, tempColor.y, tempColor.z);
        }
    
    }
    */

    public void AllocateManualPhotonView()
    {

    }


}
