 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimpleRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotationA, rotationB, rotationC;
    [SerializeField] private SpriteRenderer spriteA, spriteB, spriteC;
    [SerializeField] private Color startColor, endColor;
    [SerializeField] Material mat;

    // Update is called once per frame
    private void Start()
    {
        //ColorChangeAnimation(spriteA);
        //ColorChangeAnimation(spriteB);
        //ColorChangeAnimation(spriteC);

        Sequence materialSequence = DOTween.Sequence();
        materialSequence.Append(mat.DOBlendableColor(startColor, 2.5f));
        materialSequence.Append(mat.DOBlendableColor(endColor, 2.5f));
        materialSequence.SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        spriteA.transform.Rotate(rotationA);
        spriteB.transform.Rotate(rotationB);
        spriteC.transform.Rotate(rotationC);
    }

    void ColorChangeAnimation(SpriteRenderer spriteToColor)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(spriteToColor.DOBlendableColor(startColor, 2.5f));
        mySequence.Append(spriteToColor.DOBlendableColor(endColor, 2.5f));
        mySequence.SetLoops(-1, LoopType.Yoyo);

        
    }
}
