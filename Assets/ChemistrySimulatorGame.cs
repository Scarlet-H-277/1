using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemistrySimulatorGame : MonoBehaviour
{
    [System.Serializable]
    public class Element
    {
        public string symbol;
        public string name;
        public float atomicWeight;

        public Element(string symbol, string name, float atomicWeight)
        {
            this.symbol = symbol;
            this.name = name;
            this.atomicWeight = atomicWeight;
        }
    }

    public Text reactionText;
    public Button hydrogenButton;
    public Button oxygenButton;
    public Button triggerReactionButton;
    public GameObject reactionEffect;

    private List<Element> selectedElements = new List<Element>();
    private List<Element> elements = new List<Element>()
    {
        new Element("H", "Hydrogen", 1.008f),
        new Element("O", "Oxygen", 15.999f)
    };

    void Start()
    {
        hydrogenButton.onClick.AddListener(() => SelectElement(elements[0]));
        oxygenButton.onClick.AddListener(() => SelectElement(elements[1]));
        triggerReactionButton.onClick.AddListener(TriggerReaction);
        UpdateReactionText();
    }

    void SelectElement(Element element)
    {
        selectedElements.Add(element);
        UpdateReactionText();
    }

    void UpdateReactionText()
    {
        if (selectedElements.Count == 0)
        {
            reactionText.text = "Select elements to react.";
        }
        else
        {
            string selectedText = "Selected: ";
            foreach (Element elem in selectedElements)
            {
                selectedText += elem.symbol + " ";
            }
            reactionText.text = selectedText;
        }
    }

    void TriggerReaction()
    {
        if (selectedElements.Count == 2 &&
            selectedElements[0].symbol == "H" && selectedElements[1].symbol == "O")
        {
            reactionText.text = "Reaction: H2 + O -> H2O (Water)";
            Instantiate(reactionEffect, transform.position, Quaternion.identity);
        }
        else
        {
            reactionText.text = "Invalid reaction. Try different elements.";
        }
        selectedElements.Clear();
        UpdateReactionText();
    }
}
