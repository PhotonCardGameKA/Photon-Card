// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;

// public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public Transform parentToReturnTo = null;
//     public Transform placeHolderParent = null;

//     GameObject placeHolder = null;


//     void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
//     {
//         Debug.Log("OnBeginDrag");

//         placeHolder = new GameObject();
//         placeHolder.transform.SetParent(this.transform.parent);
//         LayoutElement le = placeHolder.AddComponent<LayoutElement>();
//         le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
//         le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
//         le.flexibleHeight = 0;
//         le.flexibleWidth = 0;

//         placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
//         parentToReturnTo = this.transform.parent;
//         placeHolderParent = parentToReturnTo;
//         this.transform.SetParent(this.transform.parent.parent);

//         GetComponent<CanvasGroup>().blocksRaycasts = false;
//     }

//     void IDragHandler.OnDrag(PointerEventData eventData)
//     {
//         throw new System.NotImplementedException();
//     }
//     public void OnEndDrag(PointerEventData eventData)
//     {
//         throw new System.NotImplementedException();
//     }

// }
