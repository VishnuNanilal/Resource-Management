using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    Text text;
    int InventorySpace;

    private void Awake() {
        text = GetComponent<Text>();
    }

    private void Start() {
        InventorySpace = Base.Instance.InventorySpace == -1 ? Int32.MaxValue : Base.Instance.InventorySpace;
    }

    private void Update() {
        InventorySpace = InventorySpace == -1 ? Int32.MaxValue : InventorySpace;
        text.text = Base.Instance.GetCurrentAmount() + " / "+ InventorySpace;
    }
}
