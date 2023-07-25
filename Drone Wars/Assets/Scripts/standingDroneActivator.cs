using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standingDroneActivator : MonoBehaviour
{
    [SerializeField] GameObject gameObject1;
    [SerializeField] float activateTime1;
    [SerializeField] GameObject gameObject2;
    [SerializeField] float activateTime2;
    [SerializeField] GameObject gameObject3;
    [SerializeField] float activateTime3;
    [SerializeField] GameObject gameObject4;
    [SerializeField] float activateTime4;
    [SerializeField] GameObject gameObject5;
    [SerializeField] float activateTime5;
    [SerializeField] GameObject enemy1;
    [SerializeField] float activate1;
    [SerializeField] GameObject enemy2;
    [SerializeField] float activate2;
    [SerializeField] GameObject enemy3;
    [SerializeField] float activate3;
    

    private IEnumerator activationCoroutine; // Store the reference to the coroutine

    void Start()
    {
        gameObject1.SetActive(false);
        gameObject2.SetActive(false);
        gameObject3.SetActive(false);
        gameObject4.SetActive(false);
        gameObject5.SetActive(false);
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);

        // Start the coroutine and store the reference
        activationCoroutine = SetActive();
        StartCoroutine(activationCoroutine);
        StartCoroutine("activationEnemy");
    }

    IEnumerator SetActive()
    {
        while (true)
        {
            if (!gameObject1.activeSelf)
            {
                yield return new WaitForSeconds(activateTime1);
                gameObject1.SetActive(true);
            }

            if (!gameObject2.activeSelf)
            {
                yield return new WaitForSeconds(activateTime2);
                gameObject2.SetActive(true);
            }

            if (!gameObject3.activeSelf)
            {
                yield return new WaitForSeconds(activateTime3);
                gameObject3.SetActive(true);
            }

            if (!gameObject4.activeSelf)
            {
                yield return new WaitForSeconds(activateTime4);
                gameObject4.SetActive(true);
            }

            if (!gameObject5.activeSelf)
            {
                yield return new WaitForSeconds(activateTime5);
                gameObject5.SetActive(true);
            }
            yield return new WaitForSeconds(5f);

            // Deactivate the game objects before the next iteration
            gameObject1.SetActive(false);
            gameObject2.SetActive(false);
            gameObject3.SetActive(false);
            gameObject4.SetActive(false);
            gameObject5.SetActive(false);
        }
    }
    IEnumerator activationEnemy()
    {
        if (!enemy1.activeSelf)
        {
            yield return new WaitForSeconds(activate1);
            enemy1.SetActive(true);
        }

        if (!enemy2.activeSelf)
        {
            yield return new WaitForSeconds(activate2);
            enemy2.SetActive(true);
        }

        if (!enemy3.activeSelf)
        {
            yield return new WaitForSeconds(activate3);
            enemy3.SetActive(true);
        }
        yield return new WaitForSeconds(10f);
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);

    }
    void Update()
    {
        // No need to check if the coroutine is running or stop it as it's now in an infinite loop.
    }
}