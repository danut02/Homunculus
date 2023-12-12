using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MusicSlider : MonoBehaviour
{
    public Slider slider;
    
    public AudioManager audioManager; // Reference to AudioManager script

    private bool isDragging = false;
    private AudioSource source;
    private bool playBeforeDrag; // Store the state of the ChangePlayStop button
    
    // Start is called before the first frame update
    void Start()
    {
        if (audioManager != null)
        {
            // Get the AudioSource component from your AudioManager.
            source = audioManager.GetAudioSource();
            if (source != null)
            {
                // Set the slider's max value to the audio clip's length.
                slider.maxValue = source.clip.length;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (source != null)
        {
            // Update the slider's value to match the current audio playback position.
            slider.value = source.time;
            audioManager.ShowPlayTime();
        }
    }

    public void OnPointerDown()
    {
        // Called when the pointer clicks on the slider.
        isDragging = true;
        
        // Store the state of the ChangePlayStop button
        playBeforeDrag = audioManager.IsAudioPlaying();
        
        // Pause audio playback while dragging to prevent conflicts.
        audioManager.PauseAudio();
        
        // Set a flag to disable automatic song transition during dragging.
        audioManager.isAutoPlaying = false;
        
    }

    public void OnDrag()
    {
        // Called when the slider is dragged.
        if (isDragging)
        {
            float seekPosition = slider.value;
            if (seekPosition >= source.clip.length)
            {
                // The user has dragged to the end, so consider it as manual pause
                audioManager.UpdatePlayTime(seekPosition); // Update the play time.
                audioManager.ShowPlayTime(); // Update the UI with the dragged position.
            }
            else
            {
                audioManager.SeekAudio(seekPosition);
            }
        }
    }
    
    public void OnPointerUp()
    {
        // Called when the pointer is released from the slider.
        isDragging = false;
        // Check if the ChangePlayStop button was in play state before dragging
        if (playBeforeDrag)
        {
            // Resume audio playback if it was in play state
            audioManager.isAutoPlaying = true; // Enable automatic song transition after dragging
            audioManager.ResumeAudio();
        }
    }
}
