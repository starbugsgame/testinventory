using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.DynamicListUI.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleController : MonoBehaviour
{
    private Vector3 _movePoint;
    private ListViewModel _inventory;

    // Use this for initialization
    void Start()
    {
        _inventory = FindObjectOfType<ListViewModel>();
    }



    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Plane")
                    _movePoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                var item = hit.collider.GetComponent<ListItemViewModel>();


                if (item != null)
                {
                    var itemInHeirarchy = GetComponentsInChildren<ListItemViewModel>(true).First(x => x.name == item.name);
                    _inventory.AddItem(itemInHeirarchy);
                    item.transform.position = new Vector3(-1000, -1000, -1000);

                }
            }
        }

        if (_movePoint != Vector3.zero && Vector3.Distance(_movePoint, transform.position) > 0.3f)
        {
            transform.LookAt(_movePoint);
            transform.position = Vector3.MoveTowards(transform.position, _movePoint, 5f * Time.deltaTime);
        }
    }
}
