using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stairs : Horizontal
{
public override void Tweening(GameObject brick, float ease, float endSize, int i)
    {
        base.Tweening(brick, ease, endSize, i);
        brick.transform.DOMoveY(baseSize + transform.position.y + i, ease);
    }
}
