using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject scrollbar;
    private float scroll_pos = 0;
    float[] pos;
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
    }
    private GameObject obj;
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }


        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                //if (obj == null)
                //{
                //    shopManager.SetShopPlayerMaterials(i);
                //    obj = transform.GetChild(i).gameObject;
                //}
                //else if(obj != transform.GetChild(i).gameObject)
                //{
                //    shopManager.SetShopPlayerMaterials(i);
                //    obj = transform.GetChild(i).gameObject;
                //}

                //if (transform.GetChild(i).localScale.x < 0.9f)
                //    shopManager.SetShopPlayerMaterials(i);

                transform.GetChild(i).localScale = Vector3.Lerp(transform.GetChild(i).localScale, new Vector3(1f, 1f, 1), 0.1f);
                //transform.GetChild(i).localScale = Vector3.Lerp(transform.GetChild(i).localScale, new Vector3(100, 100, 100), 0.1f);


                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        //transform.GetChild(j).localScale = Vector3.Lerp(transform.GetChild(j).localScale, new Vector3(80, 80, 80), 0.1f);
                        transform.GetChild(j).localScale = Vector3.Lerp(transform.GetChild(j).localScale, new Vector3(.8f, .8f, .8f), 0.1f);
                    }
                }
            }
        }

    }
}