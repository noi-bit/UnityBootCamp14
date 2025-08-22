using UnityEngine;
using UnityEngine.EventSystems;

public class dragdropSystem : MonoBehaviour
{
    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnDragDelegate(PointerEventData data)
    {
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        transform.position = rayPoint;  
    }

}
