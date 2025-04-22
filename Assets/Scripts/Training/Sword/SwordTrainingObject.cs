using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordTrainingObject : MonoBehaviour
{
    public Image _image;
    public Image _collision;
    public int _collisionKey;
    public TrainingObjectType _trainingObjectType;
    public enum TrainingObjectType
    {
        Apple,
        Star
    }

    public static SwordTrainingObject Create(Image imageToClone, Image collision, int collisionKey, TrainingObjectType trainingObjectType)
    {
        GameObject appleObject = new GameObject("Apple");
        SwordTrainingObject trainingObject = appleObject.AddComponent<SwordTrainingObject>();

        trainingObject._image = Instantiate(imageToClone, imageToClone.transform.parent);
        trainingObject._image.transform.position = imageToClone.transform.position;
        trainingObject._image.transform.localScale = imageToClone.transform.localScale;
        trainingObject._image.color = new Color(trainingObject._image.color.r, trainingObject._image.color.g, trainingObject._image.color.b, 1);

        trainingObject._collision = collision;
        trainingObject._collisionKey = collisionKey;
        trainingObject._trainingObjectType = trainingObjectType;

        return trainingObject;
    }
}
