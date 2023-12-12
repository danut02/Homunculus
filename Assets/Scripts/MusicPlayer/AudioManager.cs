using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicList;
    public AudioSource source;
    public DropdownMenu dropdownMenu; // Reference to the DropdownMenu script

    public TMP_Text clipTitleText;
    public TMP_Text clipTimeText;
    public int  currentTrack;
    
    private int fullLength;
    private float playTime;
    private float originalVolume;

    public Button button;

    public Sprite startSprite;

    public Sprite stopSprite;
    public VolumeControl volumeControl;
    public bool isAutoPlaying; // Add a flag to control automatic song transition

    public Slider slider;
    private int lastPlayedSongIndex;




    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        originalVolume = source.volume;
        
        // Check if an audio clip is already assigned in the Inspector. If not, set it from the list.
        if (source.clip == null)
        {
            if (musicList.Length > 0)
            {
                source.clip = musicList[0];
                currentTrack = 0; // Set the current track index to the first song
            }
        }
        
        if (dropdownMenu != null)
        {
            dropdownMenu.UpdateSelectedOption(lastPlayedSongIndex);
        }
        
        ShowCurrentTitle();
        ShowPlayTime();
    }
    
    IEnumerator MusicEnd()
    {
        while(true) // Continuously check for the end of the song
        {
            if (!source.isPlaying && isAutoPlaying)
            {
                // The song has ended, automatically play the next one
                NextTitle();
            }
            
            playTime = source.time;
            ShowPlayTime();
            yield return null;
        }
    }

    public void NextTitle()
    {
        source.Stop();
        source.time = 0;
        currentTrack++;
        if (currentTrack > musicList.Length - 1)
        {
            currentTrack = 0;
        }

        source.clip = musicList[currentTrack];
        
        if (dropdownMenu != null)
        {
            dropdownMenu.UpdateSelectedOption(currentTrack);
        }
        
        
        // Set the slider's max value to the new audio clip's length
        if (slider != null)
        {
            slider.maxValue = source.clip.length;
            // Set the slider value to the end of the song to visually match the end.
            slider.value = source.clip.length;
        }
        
        //SHOW THE TITLE    
        ShowCurrentTitle();
        
        button.image.sprite = stopSprite;

        // Stop the MusicEnd coroutine before starting it again
        StopCoroutine(MusicEnd());
        
        isAutoPlaying = false; // Reset the flag when manually changing songs
        
        StartCoroutine(MusicEnd());
    }

    public void PreviousTitle()
    {
        source.Stop();
        source.time = 0;
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicList.Length - 1;
        }

        source.clip = musicList[currentTrack];

        if (dropdownMenu != null)
        {
            dropdownMenu.UpdateSelectedOption(currentTrack);
        }
        
        // Set the slider's max value to the new audio clip's length
        if (slider != null)
        {
            slider.maxValue = source.clip.length;
            // Set the slider value to the end of the song to visually match the end.
            slider.value = source.clip.length;
        }
        
        //SHOW THE TITLE
        ShowCurrentTitle();
        
        button.image.sprite = stopSprite;

        isAutoPlaying = false; // Reset the flag when manually changing songs
        
        StartCoroutine(MusicEnd());
    }

    public void ShowCurrentTitle()
    {
        clipTitleText.text = source.clip.name;
        fullLength = (int) source.clip.length;
    }

    public void ShowPlayTime()
    {
        if (source.clip != null && source.clip != musicList[currentTrack])
        {
            // The track has changed, reset playTime to 0
            playTime = 0;
        }
        clipTimeText.text = FormatTime(source.time) + " / " + FormatTime(source.clip.length);
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
    
    public void ChangePlayStop()
    {
        if (source.isPlaying)
        {
            // If the source is playing, pause it.
            source.Pause();
            button.image.sprite = startSprite;
            isAutoPlaying = false; // Disable automatic song transition when paused
        }
        else
        {
            // If the source is paused, play it.
            source.Play();
            button.image.sprite = stopSprite;
            isAutoPlaying = true; // Enable automatic song transition when unpaused
            StartCoroutine(MusicEnd());
        }
        
    }

    public void SetCurrentTrack(int selectedIndex)
    {
        currentTrack = selectedIndex;
    }

    // Update the song title text
    public void UpdateSongTitle(string title)
    {
        if (clipTitleText != null)
        {
            clipTitleText.text = title;
        }
    }
    
    public void SetAudioClip(AudioClip clip)
    {
        source.clip = clip;
    }
    
    public AudioSource GetAudioSource()
    {
        return source;
    }
    
    public void SeekAudio(float newPosition)
    {
        if (source != null)
        {
            // Ensure newPosition is within valid bounds.
            newPosition = Mathf.Clamp(newPosition, 0f, source.clip.length);
            source.time = newPosition;
        }
    }
    
    public void PauseAudio()
    {
        if (source.isPlaying)
        {
            source.Pause();
        }
    }
    
    public void ResumeAudio()
    {
        if (source.isPlaying == false)
        {
            source.Play();
        }
    }
    
    public void UpdatePlayTime(float newTime)
    {
        if (!source.isPlaying)
        {
            playTime = newTime;
        }
    }
    
    public bool IsAudioPlaying()
    {
        return source != null && source.isPlaying;
    }
}
