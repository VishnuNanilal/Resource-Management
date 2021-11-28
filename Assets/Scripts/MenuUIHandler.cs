using UnityEngine;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
namespace ResourceSimulation.Core
{
    [DefaultExecutionOrder(1000)]
    public class MenuUIHandler : MonoBehaviour
    {
        public ColorPicker ColorPicker;

        private void Awake() {
            ColorPicker.onColorChanged += NewColorSelected;
        }

        public void NewColorSelected(Color color)
        {
            //empty for now. Color Changing logic moved to ColorManager.
        }
        
        private void Start()
        {
            ColorPicker.Init();
            //this will call the NewColorSelected function when the color picker have a color button clicked.
            ColorPicker.onColorChanged += NewColorSelected;
        }
    }
}

