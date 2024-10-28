using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    [SerializeField] private Text _text;
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    public void OnClick_Button()
    {
        SetCustomNumber();
    }
    private void SetCustomNumber()
    {
        System.Random rd = new System.Random();
        int result = rd.Next(0, 99);
        _text.text = result.ToString();


        //
        _myCustomProperties["RandomNumber"] = result;
        // _myCustomProperties.Remove("RandomNumber");
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
    }
}
