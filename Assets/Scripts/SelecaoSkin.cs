using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "seletor de Skin", menuName = "ScriptableObject/Seletor de Skin")]
public class SelecaoSkin : ScriptableObject
{
    public string skinName;
    public Sprite sprite;
    public RuntimeAnimatorController animControler;
}
    
