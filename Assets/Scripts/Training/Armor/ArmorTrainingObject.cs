using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorTrainingObject : MonoBehaviour
{
    public Image _image;
    public TrainingObjectType _trainingObjectType;
    public Vector2 _direction;
    public enum TrainingObjectType
    {
        Apple,
        Star
    }

    public static ArmorTrainingObject Create(Image imageToClone, TrainingObjectType trainingObjectType, Vector3 spawnPosition, Vector2 direction)
    {
        GameObject appleObject = new GameObject("Apple");
        ArmorTrainingObject trainingObject = appleObject.AddComponent<ArmorTrainingObject>();

        trainingObject._image = Instantiate(imageToClone, imageToClone.transform.parent);
        trainingObject._image.transform.position = spawnPosition;
        trainingObject._image.transform.localScale = imageToClone.transform.localScale;
        trainingObject._image.color = new Color(trainingObject._image.color.r, trainingObject._image.color.g, trainingObject._image.color.b, 1);

        trainingObject._trainingObjectType = trainingObjectType;
        trainingObject._direction = direction;

        return trainingObject;
    }
}
