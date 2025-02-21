using UnityEngine;

namespace RapidFireTactics
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem collectParticles;
        [SerializeField] protected AudioClip collectClip;

        private AudioSource audioSource;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                Debug.Log("Need to asign Component <b>AudioSource</b>");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerScript playerScript = other.GetComponent<PlayerScript>();

                OnPlayerDetected(playerScript);
            }
        }

        protected virtual void OnPlayerDetected(PlayerScript playerScript)
        {
            CollectVisuals();
        }

        protected virtual void CollectVisuals()
        {
            //PlayClip
            if (audioSource != null)
            {
                audioSource.Play();
            }

            //Play Particles
            if (collectParticles != null)
            {
                collectParticles.Play();
            }
        }

    }
}
