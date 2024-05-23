using DG.Tweening;
using UnityEngine;

public class Glasses : MonoBehaviour
{
    [SerializeField] private float startPosY, startPosZ;
    [SerializeField] private float middlePosY, middlePosZ;
    [SerializeField] private float finishPosY, finishPosZ;

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