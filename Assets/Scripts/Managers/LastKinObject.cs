using System.Text;
using RTLTMPro;
using UnityEngine;

public class LastKinObject : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro fullNameText;
    [SerializeField] private RTLTextMeshPro rankNameText;
    
    private Casualty lastKinCasualtyData;

    public void Init(Casualty lastKinCasualtyData)
    {
        this.lastKinCasualtyData = lastKinCasualtyData;

        UpdateText();
    }

    private void UpdateText()
    {
        StringBuilder strBuilder = new StringBuilder();

        if (!string.IsNullOrEmpty(lastKinCasualtyData.FirstName))
        {
            strBuilder.Append(lastKinCasualtyData.FirstName + " ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.FirstName2))
        {
            strBuilder.Append(lastKinCasualtyData.FirstName2 + " ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.NickName))
        {
            strBuilder.Append($"({lastKinCasualtyData.NickName}) ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.LastName))
        {
            strBuilder.Append(lastKinCasualtyData.LastName + " ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.LastName2))
        {
            strBuilder.Append(lastKinCasualtyData.LastName2 + " ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.LastName2))
        {
            rankNameText.text = lastKinCasualtyData.LastName2;
        }
        else
        {
            rankNameText.text = "אין דרגה במסד נתונים";
        }

        fullNameText.text = strBuilder.ToString();

    }
    
}