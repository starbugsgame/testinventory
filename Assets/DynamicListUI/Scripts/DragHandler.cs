
using Assets.DynamicListUI.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private GameObject _draggableItem;
    private Vector3 _startPosition;
    private Image _originalImage;
    private ListViewModel _listViewModel;
    private Button _button;

    void Start()
    {
        _listViewModel = GetComponentInParent<ListViewModel>();
        _button = GetComponent<Button>();
        _originalImage = _listViewModel.GetContentImage(_button);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _draggableItem = gameObject;
        _startPosition = transform.position;
        _listViewModel.Adorner.SetImage(_originalImage);
        _listViewModel.Adorner.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f) * _listViewModel.AdornerSize;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var screenPoint = new Vector3(eventData.position.x, eventData.position.y, 1f);
        _listViewModel.Adorner.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _listViewModel.Adorner.ResetImage();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 1000f);

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            _listViewModel.OnDragEnd(_button, hit.transform.gameObject);
        }
    }

    void OnDestroy()
    {
        if (_listViewModel == null) return;
        _listViewModel.Adorner.ResetImage();
    }


}
