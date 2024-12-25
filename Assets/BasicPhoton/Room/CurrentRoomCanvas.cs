using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField] private PlayerListingMenu _playerListingMenu;
    [SerializeField] private LeaveRoomMenu _leaveRoomMenu;
    public LeaveRoomMenu LeaveRoomMenu => _leaveRoomMenu;

    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
        _playerListingMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);
    }
    public void Show()
    {
        gameObject.SetActive(true);
        LobbyManager.Instance.OnLoadingRoomScreen();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
        LobbyManager.Instance.OnLoadingLobbyScreen();
    }
}

