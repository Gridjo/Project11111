using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{
    public TextMesh ScrapText;

    private void Awake()
    {
        ScrapText.text = "0";
    }

    public void ShowScrapText()
    {
        ScrapText.text = $"{PlayerVariables.Instance.GetScrapsAmount()}";
    }

    public void CheckRecycle(HVRGrabberBase grabberBase, HVRGrabbable grabbable)
    {
        if(grabbable.TryGetComponent(out RecyclerItem item))
        {
            PlayerVariables.Instance.AddScraps(item);
            Destroy(item.gameObject);
            ShowScrapText();
        }
        else
        {
            Debug.LogError("Nullable item. lol");
        }
    }
}
