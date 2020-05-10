using UnityEngine;
using UnityEngine.UI;
using System;

public class TextBoxValue : MonoBehaviour
{
    [SerializeField] private InputField Field_X;
    [SerializeField] private InputField Field_Y;
    [SerializeField] private int MaxNumberLength = 2;

    public InputFieldValues GetInputFieldsValues()
    {
        InputFieldValues NewValue;
        NewValue.Width = CheckCorrectInput(Field_X);
        NewValue.Height = CheckCorrectInput(Field_Y);
        return NewValue;
    }

    private int CheckCorrectInput(InputField field)
    {
        string acceptedText = field.text;
        string outputText = "";
        int result = 0;
        int maxLength = MaxNumberLength;

        for (int i = 0; i < acceptedText.Length; i++)
        {
            if (Char.IsDigit(acceptedText[i]))
                outputText += acceptedText[i];
            else
                continue;
        }

        if(outputText != "")
        {
            if (outputText.Length > maxLength)
            {
                outputText = outputText.Substring(0, maxLength);
            }
            field.text = outputText;
            result = int.Parse(outputText);
        }
        return result;
    }
}
