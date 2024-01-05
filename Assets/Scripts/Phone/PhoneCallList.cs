using TMPro;
using UnityEngine;

public class PhoneCallList : MonoBehaviour
{
    [SerializeField] private PhoneCall[] _calls;
    [SerializeField] private TMP_InputField _field;
    
    private AudioSource _audioPlayer;

    private void Start()
    {
        _audioPlayer = GetComponent<AudioSource>();
        if (_audioPlayer == null)
        {
            _audioPlayer = gameObject.AddComponent<AudioSource>();
        }
    }

    public void MakePhoneCall()
    {
        string enteredPhoneNumber = _field.text;
        PhoneCall foundCall = FindPhoneCallByNumber(enteredPhoneNumber);
        
        if (foundCall != null)
        {
            _audioPlayer.clip = foundCall.audioSource;
            _audioPlayer.Play();
        }
        else
        {
            Debug.Log("Phone call not found for the entered number: " + enteredPhoneNumber);
        }
    }

    private PhoneCall FindPhoneCallByNumber(string phoneNumber)
    {
        foreach (PhoneCall call in _calls)
        {
            if (call.phoneNumber == phoneNumber)
            {
                return call;
            }
        }
        
        return null;
    }
}
