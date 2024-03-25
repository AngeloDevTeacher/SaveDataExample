using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePrune : MonoBehaviour
{
    [SerializeField] bool HideItemsInList = false;
    [SerializeField] Component[] ThingsToHide;
    // Start is called before the first frame update

    private void OnValidate()
    {
        if (HideItemsInList)
        {
            foreach (var item in ThingsToHide)
            {
                item.hideFlags |= HideFlags.HideInHierarchy;
                item.hideFlags |= HideFlags.HideInInspector;
            }
        }
        else
        {
            foreach (var item in ThingsToHide)
            {
                item.hideFlags |= HideFlags.None;

            }
        }
    }
}
