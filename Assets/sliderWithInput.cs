using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderWithInput : MonoBehaviour
{
    public Slider slider;                // Reference to the slider
    public TMP_InputField inputField;    // Reference to the input field (TextMeshPro)
    public bool isInteger = false;       // True if input should be integers

    private void Start()
    {
        // Set initial values
        inputField.text = slider.value.ToString(isInteger ? "0" : "0.00");

        // Add listeners to synchronize values
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        inputField.onEndEdit.AddListener(OnInputFieldValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // Update the input field when slider value changes
        inputField.text = isInteger ? Mathf.Round(value).ToString("0") : value.ToString("0.00");
    }

    private void OnInputFieldValueChanged(string input)
    {
        if (float.TryParse(input, out float value))
        {
            // Clamp the value to the slider's range
            value = Mathf.Clamp(value, slider.minValue, slider.maxValue);

            // Update the slider value
            slider.value = isInteger ? Mathf.Round(value) : value;

            // Update the input field to reflect the clamped value
            inputField.text = isInteger ? Mathf.Round(value).ToString("0") : value.ToString("0.00");
        }
        else
        {
            // Reset to the slider's current value if the input is invalid
            inputField.text = isInteger ? Mathf.Round(slider.value).ToString("0") : slider.value.ToString("0.00");
        }
    }
}
