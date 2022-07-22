using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blow : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float frameDelay = 0.1f;
    [SerializeField] private Image image;
    public bool isFree = true;

    public void MakeBlow()
    {
        StartCoroutine(BlowCoroutine());
    }

    public IEnumerator BlowCoroutine()
    {
        isFree = false;
        for(int i = 0; i < sprites.Length; i++)
        {
            image.sprite = sprites[i];
            yield return new WaitForSeconds(frameDelay);
        }
        transform.localPosition = Vector3.zero;
        isFree = true;
    }
}
