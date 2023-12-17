using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
public bool buttonPressed;
public int buttonInt;
 
public void OnPointerDown(PointerEventData eventData){
     buttonPressed = true;
     buttonInt = 1;
}
 
public void OnPointerUp(PointerEventData eventData){
    buttonPressed = false;
    buttonInt = 0;
}
}