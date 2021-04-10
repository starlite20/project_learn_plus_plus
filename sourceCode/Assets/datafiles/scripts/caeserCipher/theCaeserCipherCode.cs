using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handles all the functionalites within the Caeser Cipher Code
public class theCaeserCipherCode : MonoBehaviour
{
    public GameObject cipherKey, cipherTextObject, plainTextObject;
    public InputField plainTextInputField;

    public AudioSource buttonAudioSource;
    public AudioClip buttonAudioClip;

    public GameObject infoBoxObject;
    public Animator infoBoxAnimation;

    string plainText, cipherKeyText, cipherText;
    int cipherKeyValue;
    char aligner;

    void changeTextDisplayed()
    {
        //Obtaining the Plain Text
        plainText = plainTextObject.GetComponent<Text>().text;
        cipherText = string.Empty;

        foreach (char character in plainText)
        {
            //new character is not an alphabet
            if( !char.IsLetter(character) )
            {
                cipherText = cipherText + character;
            }
            else
            {
                aligner = char.IsUpper(character) ? 'A' : 'a';
                cipherText = cipherText + ( (char)( ( ( (character+cipherKeyValue) -aligner) %26) + aligner) );
                //Debug.Log("LETTER " + cipherText);
            }
        }

        //Displaying the Cipher Text
        cipherTextObject.GetComponent<Text>().text = cipherText;
    }

    public void cipherKeyIncrements()
    {
        //play sound
        buttonAudioSource.PlayOneShot(buttonAudioClip);

        cipherKeyText = cipherKey.GetComponent<Text>().text;
        cipherKeyValue = int.Parse(cipherKeyText);
        cipherKeyValue++;

        cipherKey.GetComponent<Text>().text = cipherKeyValue.ToString();
        changeTextDisplayed();
    }

    public void cipherKeyDecrements()
    {
        //play sound
        buttonAudioSource.PlayOneShot(buttonAudioClip);

        cipherKeyText = cipherKey.GetComponent<Text>().text;
        cipherKeyValue = int.Parse(cipherKeyText);
        if(cipherKeyValue != 0)
            cipherKeyValue--;
        
        cipherKey.GetComponent<Text>().text = cipherKeyValue.ToString();
        changeTextDisplayed();
    }

    // Invoked when the value of the text field changes.
    public void newTextDetected()
    {
        cipherKeyValue = 0;
        cipherKey.GetComponent<Text>().text = cipherKeyValue.ToString();

        //Displaying resetted text
        cipherTextObject.GetComponent<Text>().text = "Your Cipher will be generated here";
    }

    // Start is called before the first frame update
    void Start()
    {
        infoBoxObject.SetActive(false);
        plainTextInputField.onValueChanged.AddListener(delegate {newTextDetected(); });
    }

    public void onInfoClicked()
    {
        buttonAudioSource.PlayOneShot(buttonAudioClip);
        infoBoxObject.SetActive(true);
    }

    public void onInfoClosed()
    {
        buttonAudioSource.PlayOneShot(buttonAudioClip);
        infoBoxAnimation.SetTrigger("closecaeser");
        StartCoroutine(playCloseInfoAnimation());
    }

    IEnumerator playCloseInfoAnimation()
    {
        yield return new WaitForSeconds(2f);
        infoBoxObject.SetActive(false);
    }
}
