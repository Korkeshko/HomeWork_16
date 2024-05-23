using DG.Tweening;
using UnityEngine;

public class Glasses : MonoBehaviour
{
    [SerializeField] private float startPosY;
    [SerializeField] private float startPosZ;
    [SerializeField] private float middlePosY;
    [SerializeField] private float middlePosZ;
    [SerializeField] private float finishPosY;
    [SerializeField] private float finishPosZ;  

    public void PutOnGlasses()
    {
        DOTween.Sequence()
                .Append(transform.DOLocalMoveY(middlePosY, 2f))
                .Join(transform.DOLocalMoveZ(middlePosZ, 2f))
                     .Append(transform.DOLocalMoveY(finishPosY, 1f))
                     .Join(transform.DOLocalMoveZ(finishPosZ, 1f));
    } 

    public void TakeOffGlasses()
    {
        DOTween.Sequence()
                .Append(transform.DOLocalMoveY(middlePosY, 1f))
                .Join(transform.DOLocalMoveZ(middlePosZ, 1f))
                     .Append(transform.DOLocalMoveY(startPosY, 2f))
                     .Join(transform.DOLocalMoveZ(startPosZ, 2f));
    } 
}
