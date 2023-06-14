using UnityEngine;
using System.IO;
using UnityEngine.UI;
using AnotherFileBrowser.Windows;

public class LoadFile : MonoBehaviour
{
    [SerializeField] private Button chooseFileButton;
    [SerializeField] private Button defaultFileButton;
    [SerializeField] private Button loadDataButton;
    [SerializeField] private Text filePathText; // Текстовое поле для отображения пути к выбранному файлу
    [SerializeField] private Text checker;

    [SerializeField] private GameObject helpNotes;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject robot;
    [SerializeField] private ModelController mc;
    private bool defIsPicked = false;
    

    FileBrowser filePicker = new FileBrowser();
   

    private string filePath;
    [SerializeField] private int[][] arrays; // Массив массивов для хранения данных

    void Start()
    {
        loadDataButton.onClick.AddListener(ReadFile);
        chooseFileButton.onClick.AddListener(OpenFileExplorer);
        defaultFileButton.onClick.AddListener(LoadDefaultFile);
    }

    public void pickDefault() 
    {
        string fileName = "Default";
        filePathText.text = fileName;
    }

    public void LoadDefaultFile()
    {
        string fileName = "Default";     
        filePathText.text = fileName;
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        if (textAsset != null)
        {
            Debug.Log("Called2");
            string[] lines = textAsset.text.Split('\n');
            Debug.Log(lines.Length + "lines");
            arrays = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] numbers = line.Trim().Split(' ');

                int[] array = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    int number;
                    if (int.TryParse(numbers[j], out number))
                        array[j] = number;
                    else
                        Debug.LogWarning("Неверный формат числа: " + numbers[j]);
                }
                arrays[i] = array;

            }
            defIsPicked = true;
        }
        else
            Debug.Log("Не удалось загрузить файл из ресурсов: ");
    }

    public void OpenFileExplorer()
    {
        defIsPicked = false;
        filePath = filePicker.OpenFilesBrowser();
        if (filePath == null)
            filePathText.text = "Default";
        else 
        filePathText.text = filePath;
        
    }

    private void ReadFile()
    {
        if (defIsPicked)
            ShowArray();
        else
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                arrays = new int[lines.Length][];

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] numbers = line.Split(' ');

                    int[] array = new int[numbers.Length];
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        int number;
                        if (int.TryParse(numbers[j], out number))
                            array[j] = number;
                        else
                            Debug.LogWarning("Неверный формат числа: " + numbers[j]);
                    }
                    arrays[i] = array;
                }
                ShowArray();
            }
            else
            {
                LoadDefaultFile();
                ShowArray();
            }
        }

        PushData();

    }

    private void ShowArray() 
    {
        string array = "";
        for (int i = 0; i < 6; i++) 
        {
            foreach (int num in arrays[i]) 
            {
                array += num.ToString();
                array += " | ";
            }
            array += "\n";
        }
        checker.text = array;
    }
    
    private void PushData() 
    {
        startMenu.SetActive(false);
        robot.SetActive(true);
        helpNotes.SetActive(true);
        exitButton.SetActive(true);
        mc.SetCoordinates(arrays);
    }
}
