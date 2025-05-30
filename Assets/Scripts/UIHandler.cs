using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{

   public static UIHandler instance { get; private set; }

   // UI dialogue window variables
   public float displayTime = 4.0f;
   private VisualElement m_NonPlayerDialogue;
   Label m_DialogueText;
   private float m_TimerDisplay;


   // Awake is called when the script instance is being loaded (in this situation, when the game scene loads)
   private void Awake()
   {
       instance = this;
   }

   // Start is called before the first frame update
   private void Start()
   {

       UIDocument uiDocument = GetComponent<UIDocument>(); 

       m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
       m_DialogueText = m_NonPlayerDialogue.Q<VisualElement>("Background").Q<Label>("Label");
       if (m_DialogueText == null)
       {
        Debug.Log("Could not find :(");
       }
       m_NonPlayerDialogue.style.display = DisplayStyle.None;
       m_TimerDisplay = -1.0f;

   }



   private void Update()
   {
       if (m_TimerDisplay > 0)
       {
           m_TimerDisplay -= Time.deltaTime;
           if (m_TimerDisplay < 0)
           {
               m_NonPlayerDialogue.style.display = DisplayStyle.None;
           }
       }
   }

   
   public void DisplayDialogue(string message)
   {

      if (m_NonPlayerDialogue != null)
      {
         m_DialogueText.text = message;  
      }

   m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
   m_TimerDisplay = displayTime;
   }

}
