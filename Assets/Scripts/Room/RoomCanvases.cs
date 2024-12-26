using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvases : MonoBehaviour
{
    [SerializeField] private CreateOrJoinRoomCanvas createOrJoinRoomCanvas;
    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas => createOrJoinRoomCanvas;
    [SerializeField] private CurrentRoomCanvas currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas => currentRoomCanvas;

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CurrentRoomCanvas.FirstInitialize(this);
        CreateOrJoinRoomCanvas.FirstInitialize(this);
    }
}
