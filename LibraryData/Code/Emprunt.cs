using Data.Code.Medias;
using System;

namespace Data.Code
{
    /// <summary>
    /// Classe implémentant l'emprunt
    /// </summary>
    public class Emprunt
    {
        #region Privates Members
        public string m_MediaName { get; set; }
        public int m_MediaNumRef { get; set; }
        public string m_NomUtilisateur { get; set; }
        public DateTime m_DateEmprunt { get; set; }
        public DateTime m_DateEcheance { get; set; }
        public bool m_Retourne { get; set; }
        public DateTime m_DateRetour { get; set; }
        #endregion

        #region Public Méthodes : accesseurs
        /// <summary>
        /// Retourne le nom du média emprunté
        /// </summary>
        /// <returns></returns>
        public string GetMediaName()
        {
            return m_MediaName;
        }
        /// <summary>
        /// Retourne le numéro de référence de l'emprunt
        /// </summary>
        /// <returns></returns>
        public int GetMediaNumRef()
        {
            return m_MediaNumRef;
        }
        /// <summary>
        /// Retourne l'utilisateur qui a effectué un emprunt
        /// </summary>
        /// <returns></returns>
        public string GetNomUtilisateur()
        {
            return m_NomUtilisateur;
        }
        /// <summary>
        /// Retourne la date d'emprunt
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateEmprunt()
        {
            return m_DateEmprunt;
        }

        /// <summary>
        /// Retourne la date d'échéance de l'emprunt
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateEcheance()
        {
            return m_DateEcheance;
        }

        /// <summary>
        /// Retourne la date de retour de l'emprunt
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateRetour()
        {
            return m_DateRetour;
        }

        /// <summary>
        /// Acceseurs de la date de retour
        /// </summary>
        /// <param name="p_DateDeRetour">date de retour à insérer</param>
        public void SetDateRetour(DateTime p_DateDeRetour)
        {
            m_DateRetour = p_DateDeRetour;
        }

        /// <summary>
        /// Booléen qui indique si le média a été rendu
        /// </summary>
        /// <returns></returns>
        public bool IsRetourned()
        {
            return m_Retourne;
        }

        /// <summary>
        /// Permet de définir le booléen IsRetourned
        /// </summary>
        /// <param name="isRetourne"></param>
        public void SetRetour(bool isRetourne)
        {
            m_Retourne = isRetourne;
        }
        #endregion

        #region Constructeurs
        public Emprunt(Media p_media, string p_nomUtilisateur, DateTime p_dateEmprunt, DateTime p_dateEcheance)
        {
            m_MediaName = p_media.GetTitre();
            m_MediaNumRef = p_media.GetNumeroReference();
            m_NomUtilisateur = p_nomUtilisateur;
            m_DateEmprunt = p_dateEmprunt;
            m_DateEcheance = p_dateEcheance;
        }

        public Emprunt()
        {
        }
        #endregion
        /// <summary>
        /// Affichage des infos concernant l'emprunt
        /// </summary>
        public void AfficherInfos()
        {
            Console.WriteLine($"Titre : {m_MediaName}");
            Console.WriteLine($"Numéro de Référence : {m_MediaNumRef}");
            Console.WriteLine($"Utilisateur : {m_NomUtilisateur}");
            Console.WriteLine($"Date d'emprunt : {m_DateEmprunt}");
            Console.WriteLine($"Date d'écheance : {m_DateEcheance}");
            Console.WriteLine($"Retourné : {(m_Retourne ? "Oui" : "Non")}");
            if(m_Retourne) Console.WriteLine($"Date de retour : {m_DateRetour}");
        }
        
    }
}