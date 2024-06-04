using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class UConsole
{
    public static event Action<string> ReadLine; 

    public static void WriteLine(string line)
    {
        UnityConsole.Instance.WriteLine(line);
    }
}

public class UnityConsole: MonoBehaviour
{
    public static UnityConsole Instance;
    
    [SerializeField] private TMP_Text outputText;  // Assign in Inspector
    [SerializeField] private TMP_InputField inputField;  // Assign in Inspector
    [SerializeField] private Button submitButton;  // Assign in Inspector
    [SerializeField] private ScrollRect scrollRect;  // Assign in Inspector

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        
        // Add a listener to the submit button to handle input
        submitButton.onClick.AddListener(HandleSubmit);
        // Ensure the input field is ready to receive input at start
        inputField.ActivateInputField();
        inputField.onSubmit.AddListener(delegate { HandleSubmit(); });
    }

    private void HandleSubmit()
    {
        string input = inputField.text;
        if (!string.IsNullOrWhiteSpace(input))
        {
            WriteLine("> " + input);  // Display the user input in the output area
            ProcessCommand(input);
        }
        inputField.text = "";  // Clear the input field
        inputField.ActivateInputField();  // Refocus on the input field
    }

    // Method to add text to the output area
    public void WriteLine(string text)
    {
        outputText.text += text + "\n";
        // Scroll to the bottom every time text is added
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }

    // Placeholder for processing commands, you can expand this method as needed
    private void ProcessCommand(string command)
    {
        // Here, add your command processing logic
        WriteLine("Processed command: " + command);  // Example response
    }
}