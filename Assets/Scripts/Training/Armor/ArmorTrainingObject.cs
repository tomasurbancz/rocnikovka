using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorTrainingObject : MonoBehaviour
{
    public Image Image;
    public TrainingObjectType TrainingObject;
    public Vector2 Direction;
    public enum TrainingObjectType
    {
        Apple,
        Star
    }

    public static ArmorTrainingObject Create(Image imageToClone, TrainingObjectType trainingObjectType, Vector3 spawnPosition, Vector2 direction)
    {
        GameObject appleObject = new GameObject("Apple");
        ArmorTrainingObject trainingObject = appleObject.AddComponent<ArmorTrainingObject>();

        trainingObject.Image = Instantiate(imageToClone, imageToClone.transform.parent);
        trainingObject.Image.transform.position = spawnPosition;
        trainingObject.Image.transform.localScale = imageToClone.transform.localScale;
        trainingObject.Image.color = new Color(trainingObject.Image.color.r, trainingObject.Image.color.g, trainingObject.Image.color.b, 1);

        trainingObject.TrainingObject = trainingObjectType;
        trainingObject.Direction = direction;

        return trainingObject;
    }
}
