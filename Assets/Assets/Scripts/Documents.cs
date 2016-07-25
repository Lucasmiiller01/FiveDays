using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Documents  
{
    private string name, text;
    private int value;
    private Vector3 propriets;
    private bool use;
    private int used;
    public Documents(string name, string text, Vector3 propriets, int value)
    {
        this.name = name;
        this.text = text;
        this.propriets = propriets;
        this.value = value;
        used = 0;
    }
    public void Use()
    {
        use = true;
    }
    public bool GetUse()
    {
        return use;
    }
    public int GetValue()
    {
        return value;
    }
    public string GetName()
    {
        return name;
    }
    public int GetUsed()
    {
        return used;
    }
    public void SetUsed(int i)
    {
        used = i;
    }
    public string GetText()
    {
        return text;
    }
    public Vector3 GetVector()
    {
        return propriets;
    }


}
