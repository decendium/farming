using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public Color customColor;
    public Material originalColor;
    public int cropType = 1;

    private bool isGrowing = false;
    private bool finishedGrowing = false;
    private bool hasSelectedType = false;
    private float growthDuration = 5f; 
    private const int maxSize = 3; 

    private Renderer cropRenderer;
    private Vector3 originalScale;
    private GameManager gameManager;

    private void Start()
    {
        cropRenderer = GetComponent<Renderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        // Original scale for ResetCrop.
        originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        // If it is finished growing, reset it.
        if (finishedGrowing)
        {
            ResetCrop();
        }

        // If the crop is no longer growing and you click on it, make it grow.
        if (!isGrowing)
        {
            if (hasSelectedType)
            {
                isGrowing = true;
                StartCoroutine(GrowCrop());
            } else
            {
                // Logic to select crop type
                gameManager.ToggleSelectionScreen();
                // Toggle selection screen using gamemanager function
                hasSelectedType = true;
            }
        }
    }

    private void Update()
    {

    }

    private IEnumerator GrowCrop()
    {
        float elapsedTime = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = startScale + new Vector3(0f, maxSize, 0f);

        while (elapsedTime < growthDuration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / growthDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the final size if its not already.
        transform.localScale = targetScale;

        // Fully grown, change color
        cropRenderer.material.color = customColor; 
        isGrowing = false; 
        finishedGrowing = true;
    }

    // Resets the crop to its default.
    private void ResetCrop()
    {
        transform.localScale = originalScale;
        cropRenderer.material = originalColor;
        isGrowing = false;
        finishedGrowing = false;
        hasSelectedType = false;
    }
}