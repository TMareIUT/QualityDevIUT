using System;
using Data.Code.Medias;
using Data.Code;
using Data.Code.Tools;

namespace Code.LibraryManager
{
    public class Library
    {
        #region Private Members
        private List<Media> Medias { get; set; }
        private List<Emprunt> Emprunts { get; set; }

        private readonly DataManager DataManager = new DataManager();
        #endregion

        #region Constructeurs
        public Library()
        {
            Medias = new List<Media>();
            Emprunts = new List<Emprunt>(); 
        }
        #endregion
        /// <summary>
        /// Accesseurs permettant de récupérer les Médias
        /// </summary>
        /// <returns></returns>
        public List<Media> GetMedias()
        {
            return Medias;
        }
        /// <summary>
        /// Accesseurs permettant de récupérer les Emprunts
        /// </summary>
        /// <returns></returns>
        public List<Emprunt> GetEmprunts()
        {
            return Emprunts;
        }
        #region Public Méthodes : Indexeur
        /// <summary>
        /// Indexeur pour accéder aux médias par leur numéro de référence
        /// </summary>
        /// <param name="p_numeroReference">Numéro de référence du média</param>
        /// <returns></returns>
        public Media this[int p_numeroReference]
        {
            get
            {
                return (Medias.Count > 0) ? Medias.Find(media => media.GetNumeroReference() == p_numeroReference) : null;
            }
        }
        /// <summary>
        /// Indexeur pour accéder aux médias par leur titre
        /// </summary>
        /// <param name="p_titre">Titre du média</param>
        /// <returns></returns>
        public Media this[string p_titre]
        {
            get
            {
                return (Medias.Count > 0) ? Medias.Find(media => media.GetTitre() == p_titre) : null;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Méthode pour ajouter un média à la bibliothèque
        /// </summary>
        /// <param name="media">Media à ajouter</param>
        public void AjouterMedia(Media media)
        {
            Medias.Add(media);
            Console.WriteLine($"Ajout du média {media.GetTitre()} à la bibliothèque.");
        }

        /// <summary>
        /// Méthode pour retirer un média de la bibliothèque
        /// </summary>
        /// <param name="media">Média à retirer</param>
        public void RetirerMedia(Media media)
        {
            Medias.Remove(media);
            Console.WriteLine($"Retrait du média {media.GetTitre()} de la bibliothèque.");
        }

        /// <summary>
        /// Méthode pour emprunter un média
        /// </summary>
        /// <param name="media">Média à emprunter</param>
        /// <param name="nomUtilisateur"></param>
        /// <exception cref="InvalidOperationException">Utilisateur qui emprunte le média</exception>
        public void EmprunterMedia(Media media, string nomUtilisateur)
        {
            if (media.GetNExemplairesDispo() > 0)
            {
                media.TakeOffExemplaire();
                // Enregistrez les détails de l'emprunt
                Emprunt emprunt = new Emprunt(media, nomUtilisateur, DateTime.Now, DateTime.Now.AddDays(14));
                Emprunts.Add(emprunt);
            }
            else
            {
                throw new InvalidOperationException("Le média n'est pas disponible pour l'emprunt.");
            }
        }

        /// <summary>
        /// Méthode pour retourner un média emprunté
        /// </summary>
        /// <param name="media">Média retourné</param>
        public void RetournerEmprunt(Media media)
        {
            media.AddExemplaire();
            // Mettez à jour les enregistrements d'emprunt pour marquer le média comme retourné.
            // Recherchez l'emprunt correspondant pour marquer le média comme retourné
            if (Emprunts != null && Emprunts.Count > 0)
            {
                Emprunt emprunt = Emprunts.Find(e => e.GetMediaNumRef() == media.GetNumeroReference() && !e.IsRetourned());
                if (emprunt != null)
                {
                    emprunt.SetRetour(true);
                    emprunt.SetDateRetour(DateTime.Now);
                }
            }
        }

        #region Affichage
        /// <summary>
        /// Méthode pour afficher tous les médias présent dans la bibliothèque
        /// </summary>
        public void AfficherTousLesMedias()
        {
            Console.WriteLine("Médias dans la bibliothèque :");
            foreach (Media media in Medias)
            {
                media.AfficherInfos();
                Console.WriteLine();
            }
        }

        public void AfficherTousLesEmprunts()
        {
            Console.WriteLine("Médias dans la bibliothèque :");
            foreach (Emprunt emprunt in Emprunts)
            {
                emprunt.AfficherInfos();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Méthode pour afficher les détails d'un média par son numéro de référence
        /// </summary>
        /// <param name="numeroReference">Numéro de référence du média</param>
        public void AfficherMediaParNumeroReference(int numeroReference)
        {
            Media media = this[numeroReference];
            if (media != null)
            {
                media.AfficherInfos();
            }
            else
            {
                Console.WriteLine("Aucun média trouvé avec ce numéro de référence.");
            }
        }

        /// <summary>
        /// Méthode pour afficher les médias empruntés par un utilisateur
        /// </summary>
        /// <param name="nomUtilisateur">Utilisateur qui a emprunté</param>
        /// <returns></returns>
        public List<Media> MediasEmpruntesParUtilisateur(string nomUtilisateur)
        {
            List<Media> mediasEmpruntes = new List<Media>();

            foreach (Emprunt emprunt in Emprunts)
            {
                if (emprunt.GetNomUtilisateur() == nomUtilisateur && !emprunt.IsRetourned())
                {
                    mediasEmpruntes.Add(Medias[emprunt.GetMediaNumRef()]);
                }
            }

            return mediasEmpruntes;
        }

        /// <summary>
        ///  Méthode pour afficher les statistiques de la bibliothèque
        /// </summary>
        public void AfficherStatistiques()
        {
            int mediasDisponibles = 0;
            foreach (Media m in Medias)
            {
                mediasDisponibles += m.GetNExemplairesDispo();
            }

            Console.WriteLine($"Nombre de médias dans la bibliothèque : {Medias.Count}");
            Console.WriteLine($"Médias empruntés : {Emprunts.Count}");
            Console.WriteLine($"Médias disponibles actuellement : {mediasDisponibles}");
        }
        #endregion

        #region Recherche
        /// <summary>
        /// Méthode pour rechercher un média par titre
        /// </summary>
        /// <param name="titre">Titre du média</param>
        /// <returns></returns>
        public List<Media> RechercherMediaParTitre(string titre)
        {
            return Medias.FindAll(media => media.GetTitre().Contains(titre, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Méthode pour rechercher un emprunt par titre et selon un utilisateur
        /// </summary>
        /// <param name="titre">Nom du média emprunté</param>
        /// <param name="nomUtilisateur">Utilisateur ayant emprunté</param>
        /// <returns></returns>
        public List<Emprunt> RechercherEmpruntParTitre(string titre, string nomUtilisateur)
        {
            return Emprunts.FindAll(emprunt => emprunt.GetMediaName().Contains(titre, StringComparison.OrdinalIgnoreCase) && emprunt.GetNomUtilisateur() == nomUtilisateur);
        }
        /// <summary>
        /// Méthode pour rechercher un emprunt par titre et selon un utilisateur
        /// </summary>
        /// <param name="numeroReference">Numéro de référence du média emprunté</param>
        /// <param name="nomUtilisateur">Utilisateur ayant emprunté</param>
        /// <returns></returns>
        public List<Emprunt> RechercherEmpruntParNumeroDeReference(int numeroReference, string nomUtilisateur)
        {
            return Emprunts.FindAll(emprunt => emprunt.GetMediaNumRef() == numeroReference && emprunt.GetNomUtilisateur() == nomUtilisateur);
        }

        /// <summary>
        /// Méthode pour rechercher un média par auteur
        /// </summary>
        /// <param name="auteur">Auteur du média</param>
        /// <returns></returns>
        public List<Media> RechercherMediaParAuteur(string auteur)
        {
            return Medias.FindAll(media => media is Livre && ((Livre)media).GetAuteur().Contains(auteur, StringComparison.OrdinalIgnoreCase));
        }
        #endregion                

        /// <summary>
        /// Méthode d'appel au datamanager pour la sauvegarde de la bibliothèque
        /// </summary>
        public void SaveLibrary()
        {
            DataManager.SauvegarderBibliothèque(Medias, Emprunts);
        }
        /// <summary>
        /// Méthode d'appel au datamanager pour le chargement de la bibliothèque
        /// </summary>
        public void LoadLibrary()
        {
            List<Media> v_mediasTmp;
            List<Emprunt> v_empruntTmp;
            DataManager.ChargerBibliothèque(out v_mediasTmp, out v_empruntTmp);
            Medias = v_mediasTmp;
            Emprunts = v_empruntTmp;
        }
        #endregion

        #region Surcharge Opérateur
        /// <summary>
        /// Ajout d'un média à la librairie
        /// </summary>
        /// <param name="library">Librairie concernée</param>
        /// <param name="media">Média à ajouter</param>
        /// <returns></returns>
        public static Library operator +(Library library, Media media)
        {
            // Recherchez si le média existe déjà dans la bibliothèque par son numéro de référence
            Media existingMedia = library[media.GetNumeroReference()];

            if (existingMedia != null)
            {
                // Le média existe déjà, augmentez le nombre d'exemplaires disponibles
                existingMedia.AddExemplaire();
            }
            else
            {
                // Le média n'existe pas encore, ajoutez-le à la bibliothèque
                library.Medias.Add(media);
            }

            return library;
        }
        /// <summary>
        /// Retrait d'un média de la librairie
        /// </summary>
        /// <param name="library">Librairie concernée</param>
        /// <param name="media">Média à retirer</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Library operator -(Library library, Media media)
        {
            // Recherchez si le média existe déjà dans la bibliothèque par son numéro de référence
            Media existingMedia = library[media.GetNumeroReference()];

            if (existingMedia != null)
            {
                if (existingMedia.GetNExemplairesDispo() > 0)
                {
                    // Décrémentez le nombre d'exemplaires disponibles
                    existingMedia.TakeOffExemplaire();

                    if (existingMedia.GetNExemplairesDispo() == 0)
                    {
                        // S'il ne reste plus d'exemplaires disponibles, retirez le média de la bibliothèque
                        library.Medias.Remove(existingMedia);
                    }
                }
                else
                {
                    // Lancez une exception si le média n'est pas disponible pour le retrait
                    throw new InvalidOperationException("Le média n'est pas disponible pour le retrait.");
                }
            }
            else
            {
                // Lancez une exception si le média n'est pas trouvé dans la bibliothèque
                throw new InvalidOperationException("Le média n'est pas trouvé dans la bibliothèque.");
            }

            return library;
        }
        #endregion
    }

}