using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;


[System.Serializable]
public class Dialogue
{
    public string npcName;
    [TextArea(3, 10)]
    public string[] sentences;
}

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;
    private Queue<string> sentences;
    private bool isTyping = false;
    private bool isSentenceComplete = false;
    GameManager gameManager;

    private PlayerInputHandler inputHandler;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sentences = new Queue<string>();
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); 
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        isSentenceComplete = false;
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        isSentenceComplete = true;
    }

    private void Update()
    {
        if (inputHandler.SkipTextInput && isSentenceComplete && !isTyping)
        {
            DisplayNextSentence();
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of dialogue.");
        if (gameManager.AreAllLevelsNotFailed() && gameManager.AreAllLevelsVisited())
        {
            //SceneManager.LoadScene("Graduation");
            Debug.Log("End of GAME.");
            SceneManager.LoadScene("MainMenu");
            GameManager.Instance.ShowOptionsMenu();
        }
        else if (gameManager.AreAllLevelsVisited() && gameManager.isResited && !gameManager.AreAllLevelsNotFailed())
        {
            Debug.Log("Some levels have failed. Going back to Lobby.");
            gameManager.ResitLevel();
            SceneManager.LoadScene("Lobby");
        }
        else if (!gameManager.AreAllLevelsVisited())
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            GameManager.Instance.ShowOptionsMenu();
        }
    }
}

