using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool ChangeScale;
    private TMP_Text _textMeshPro;
    private Vector3 _origScale;

    void Start()
    {
        if (gameObject.GetComponentInChildren<TMP_Text>() != null)
            _textMeshPro = GetComponentInChildren<TMP_Text>();
        _origScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ChangeScale == true)
            SetScale(_origScale + new Vector3(.2f, .2f, .2f));
        if (_textMeshPro != null)
            _textMeshPro.color = new Color32(225, 225, 225, 225);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetScale(_origScale);
        if (_textMeshPro != null)
            _textMeshPro.color = new Color32(50, 50, 50, 225);
    }
    private void SetScale(Vector3 newScale)
    {
        transform.localScale = newScale;
    }
}

