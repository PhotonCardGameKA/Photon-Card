using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        //override
    }
    protected virtual void OnEnable()
    {
        this.ResetValue();
    }
    protected virtual void ResetValue()
    {

    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void Start()
    {

    }
}
