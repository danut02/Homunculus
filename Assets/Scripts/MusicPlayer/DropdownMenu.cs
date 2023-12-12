using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DropdownMenu : MonoBehaviour
{
    public Dropdown dropdown;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public AudioManager audioManager;
    public Slider slider;
    public bool isNewSongSelected = false;

    void Start()
    {
        LoadMusicAndPopulateDropdown();
        dropdown.onValueChanged.AddListener(PlaySelectedSong);
        dropdown.RefreshShownValue(); // Make sure the current selection is visible
        
    }

    void LoadMusicAndPopulateDropdown()
    {
        string folderPath = "Assets/Songs"; // Update the folder path as needed

        if (System.IO.Directory.Exists(folderPath))
        {
            string[] audioFilePaths = System.IO.Directory.GetFiles(folderPath, "*.mp3");

            List<string> clipNames = new List<string>();

            foreach (string audioFilePath in audioFilePaths)
            {
                AudioClip audioClip = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>(audioFilePath);
                if (audioClip != null)
                {
                    audioClips.Add(audioClip);
                    clipNames.Add(audioClip.name);
                }
            }

            // Clear and set the options for the dropdown
            dropdown.ClearOptions();
            dropdown.AddOptions(clipNames);
        }
        else
        {
            Debug.LogError("Folder does not exist: " + folderPath);
        }
    }

    public void SetNewSongSelected(bool selected)
    {
        isNewSongSelected = selected;
    }
    public void PlaySelectedSong(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < audioClips.Count)
        {
            AudioClip selectedClip = audioClips[selectedIndex]; // Get the selected audio clip

            if (audioManager != null)
            {
                audioManager.SetAudioClip(selectedClip);
                
                // Update the current track to match the selected index
                audioManager.SetCurrentTrack(selectedIndex);
                
                /// Trigger playback in the AudioManager
                audioManager.ChangePlayStop();
                
                audioManager.UpdateSongTitle(selectedClip.name);
            }

            // Set the slider's value to the end of the selected song
            if (slider != null)
            {
                slider.maxValue = selectedClip.length;
            }
            
            SetNewSongSelected(true);
        }
        else
        {
            Debug.LogError("Invalid selection index: " + selectedIndex);
        }
    }
    

    
    public void UpdateSelectedOption(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < dropdown.options.Count)
        {
            dropdown.value = selectedIndex;
        }
    }
    
}