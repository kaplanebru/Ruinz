using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stairs : Horizontal
{
    public override void Tweening(int i)
    {
        brick.transform.DOScaleY(endSize, ease);
        brick.transform.DOMoveX(transform.position.x + i, ease);
        brick.transform.DOMoveY(baseSize + transform.position.y + i, ease);
    }
}
