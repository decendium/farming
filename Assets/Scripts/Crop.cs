using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public ParticleSystem harvestParticles;
    public Color finishedColor;
    public Color originalColor;
    public int cropType = 1;

    private bool isGrowing = false;
    private bool finishedGrowing = false;
    private bool hasSelectedType = false;
    private float growthDuration = 5f; 
    private const int maxSize = 3;

    private Renderer cropRenderer;
    private Renderer harvestRenderer;
    private AudioSource harvestingSound;
    private Vector3 originalScale;
    private GameManager gameManager;

    private void Start()
    {
        cropRenderer = GetComponent<Renderer>();
        harvestRenderer = harvestParticles.GetComponent<Renderer>();
        harvestingSound = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        // Original scale for ResetCrop.
        originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        // If the player is not selecting a crop currently
        if (!gameManager.IsSelecting())
        {
            // If it is finished growing, reset it.
            if (finishedGrowing)
            {
                HarvestCrop();
            }
            // If it isn't finished growing and is not growing,
            // That means it is at its default state.
            else if (!isGrowing)
            {
                // If the player has selected a crop type, start growing the crop.
                if (hasSelectedType)
                {
                    isGrowing = true;
                    StartCoroutine(GrowCrop(cropType));
                }
                else
                {
                    // If the player hasn't selected a crop type, then make the player select one. 
                    gameManager.AssignSelectedCrop(this);
                    gameManager.ToggleSelectionScreen();
                    hasSelectedType = true;
                }
            }
        }
    }

    // IEnumerator to grow the crop (lerp the y scale of it). 
    private IEnumerator GrowCrop(int type)
    {
        float elapsedTime = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = startScale + new Vector3(0f, maxSize, 0f);

        while (elapsedTime < (growthDuration * type))
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / (growthDuration * type));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the final size if its not already.
        transform.localScale = targetScale;

        // Fully grown, change color
        cropRenderer.material.color = finishedColor; 
        isGrowing = false; 
        finishedGrowing = true;
    }



    // Resets the crop to its default, and adds one to the value in the inventory based on cropType.
    private void HarvestCrop()
    {
        SelectMaterial(cropType);
        transform.localScale = originalScale;
        cropRenderer.material.color = originalColor;
        isGrowing = false;
        finishedGrowing = false;
        hasSelectedType = false;
        harvestParticles.Play();
        harvestingSound.Play();

        switch (cropType)
        {
            case 1:
                if (gameManager.inventory.ContainsKey("c1"))
                {
                    gameManager.inventory["c1"]++;
                }
                break;
            case 2:
                if (gameManager.inventory.ContainsKey("c2"))
                {
                    gameManager.inventory["c2"]++;
                }
                break;
            case 3:
                if (gameManager.inventory.ContainsKey("c3"))
                {
                    gameManager.inventory["c3"]++;
                }
                break;
            case 4:
                if (gameManager.inventory.ContainsKey("c4"))
                {
                    gameManager.inventory["c4"]++;
                }
                break;
            default:
                Debug.LogError("Invalid crop type: " + cropType);
                break;
        }
    }

    // Selects the crop type, and changes the colors based on the crop type.
    public void SelectCrop(int crop)
    {
        cropType = crop;
        SetColorAndPrice(crop);
    }

    // Selects the material for the crop harvesting particles.
    public void SelectMaterial(int c)
    {
        harvestRenderer.material = gameManager.cropMaterials[c-1];
    }
    
    // Sets the colors of the crop based on the crop type.
    // Also deducts price for crop from the players balance. 
    void SetColorAndPrice(int cropType)
    {
        if (cropType == 1)
        {
            if (gameManager.balance >= 5)
            {
                SetCropColors(new Color(1.0f, 0.882f, 0.145f), new Color(1.0f, 0.749f, 0f)); // Light yellow to dark yellow (orange)
                ChangeBalance(-5);
            }
        }
        else if (cropType == 2)
        {
            if (gameManager.balance >= 15)
            {
                SetCropColors(new Color(1.0f, 0.447f, 0.447f), new Color(0.651f, 0.153f, 0.153f)); // Light red to dark red
                ChangeBalance(-15);
            }
        }
        else if (cropType == 3)
        {
            if (gameManager.balance >= 45)
            {
                SetCropColors(new Color(0.561f, 0.561f, 1.0f), new Color(0.314f, 0.314f, 0.8f)); // Light blue to dark blue
                ChangeBalance(-45);
            }
        }
        else if (cropType == 4)
        {
            if (gameManager.balance >= 135)
            {
                SetCropColors(new Color(0.686f, 1.0f, 0.38f), new Color(0.478f, 0.749f, 0.216f)); // Light green to dark green
                ChangeBalance(-135);
            }
        }
    }

    // Actually changes the crops colors.
    public void SetCropColors(Color color, Color changedFinishedColor)
    {
        cropRenderer.material.color = color;
        originalColor = color;
        finishedColor = changedFinishedColor;
    }

    // Changes the player's balance.
    void ChangeBalance(int price)
    {
        gameManager.ChangeBalance(price);
    }
}
