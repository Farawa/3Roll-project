using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowsContainer : MonoBehaviour
{
    [SerializeField] private GameObject blowPrefab;
    private List<Blow> blows = new List<Blow>();

    public void SetBlow(Vector3 position)
    {
        Blow blow = null;
        for (int i = 0; i < blows.Count; i++)
        {
            if (blows[i].isFree)
            {
                blow = blows[i];
                break;
            }
        }
        if (blow == null)
            blow = SpawnBlow();
        blow.transform.position = position;
        blow.MakeBlow();
    }

    private Blow SpawnBlow()
    {
        var blow = Instantiate(blowPrefab, transform).GetComponent<Blow>();
        blows.Add(blow);
        return blow;
    }
}
