using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TextMeshProUGUI textoDialogo;
    [SerializeField] int letrasSegundo;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void ShowDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string line)
    {
        textoDialogo.text = "";
        foreach (var letra in line.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(1f / letrasSegundo);
        }
    }
}
