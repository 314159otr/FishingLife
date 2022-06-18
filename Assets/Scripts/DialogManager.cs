using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TextMeshProUGUI textoDialogo;
    [SerializeField] int letrasSegundo;
    [SerializeField] GameObject inventario;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public int currentLine = 0;
    Dialog dialog;
    private bool escribiendo;

    public void ShowDialog(Dialog dialog)
    {
        this.dialog = dialog;
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) )&& !escribiendo )
        {
            dialogBox.SetActive(true);
            if (currentLine < dialog.Lines.Count)
            {
                
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
                ++currentLine;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().hablando = false;
                currentLine = 0;
                dialogBox.SetActive(false);
                inventario.SetActive(true);
            }
            
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        escribiendo = true;
        textoDialogo.text = "";
        foreach (var letra in line.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(1f / letrasSegundo);
        }
        escribiendo = false;
    }
}
