using TMPro;
using UnityEngine;

public class MessageTest : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField hoge;

    private TextGene textGene;

    public void SendMassage()
    {
        if (textGene == null)
        {
            textGene = GameObject.FindWithTag("TextBoard").GetComponent<TextGene>();
        }
        textGene.AddText(hoge.text);
        hoge.text = "";
    }
}
