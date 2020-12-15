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
    bool shouldDisplayInfo = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldDisplayInfo = true;
            ShowItemInfo();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldDisplayInfo = false;
            HideItemInfo();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (shouldDisplayInfo)
        {
            playerRotation = other.transform.localRotation.eulerAngles;
            canvas.transform.eulerAngles = playerRotation;
            canvas.transform.localPosition = transform.localPosition;
            canvas.transform.Translate(Vector3.right * offset, Space.Self);
        }
    }

    void ShowItemInfo()
    {
        tmpText.gameObject.SetActive(true);

        tmpText.text = $"Name: {item.Name}\nWeight: {item.Weight}kg\nPress \"{KeyCode.F}\" to pick up";
    }

    public void HideItemInfo()
    {
        tmpText.gameObject.SetActive(false);
    }
}
