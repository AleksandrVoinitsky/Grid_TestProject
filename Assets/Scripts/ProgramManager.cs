using UnityEngine;

[RequireComponent(typeof(LetterShifter), typeof(LetterGenerator), typeof(TextBoxValue))]
public class ProgramManager : MonoBehaviour
{
    public static ProgramManager instance = null;
    private LetterShifter shifter;
    private LetterGenerator generator;
    private TextBoxValue textBoxValue;

    void Start()
    {
        if (instance == null)
        { 
            instance = this; 
        }
        else if (instance == this)
        { 
            Destroy(gameObject); 
        }

        shifter = GetComponent<LetterShifter>();
        generator = GetComponent<LetterGenerator>();
        textBoxValue = GetComponent<TextBoxValue>();
    }

    public void GenerateButtonPressed()
    {
        shifter.ClearData();
        generator.CreateBoard(textBoxValue.GetInputFieldsValues());
    }

    public void ShifterButtonPressed()
    {
        shifter.StartShuffleTiles(generator.GetTilesList());
    }
}
