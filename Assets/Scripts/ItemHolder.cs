using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Item Item => item;

    [SerializeField] Item item = default;
    [SerializeField] Canvas canvas = default;
    [SerializeField] float offset = 3f;
    [SerializeField] TMP_Text tmpText = default;

    Vector3 playerRotation;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRotation = other.transform.localRotation.eulerAngles;
            ShowItemInfo();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideItemInfo();
        }
    }

    void ShowItemInfo()
    {
        tmpText.gameObject.SetActive(true);
        canvas.transform.eulerAngles = playerRotation;
        canvas.transform.localPosition = transform.localPosition;
        canvas.transform.Translate(Vector3.right * offset, Space.Self);

        tmpText.text = $"Name: {item.Name}\nWeight: {item.Weight}kg";
    }

    public void HideItemInfo()
    {
        tmpText.gameObject.SetActive(false);
    }
}
