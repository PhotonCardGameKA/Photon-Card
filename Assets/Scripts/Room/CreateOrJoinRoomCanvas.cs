using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField] private CreateRoomMenu createRoomMenu;
    private RoomCanvases roomCanvases;
    [SerializeField] private RoomListingMenu _roomListingMenu;
    public void FirstInitialize(RoomCanvases canvases)
    {
        roomCanvases = canvases;
        createRoomMenu.FirstInitialize(canvases);
        _roomListingMenu.FirstInitialize(canvases);
    }
}
