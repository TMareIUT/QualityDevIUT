using System;

namespace Data.Code.Medias
{
    /// <summary>
    /// Classe générique implémentant un média
    /// </summary>
    public class Media
    {
        #region Privates Members
        public string m_Titre { get; set; }
        public int m_NumeroReference { get; set; }
        public int m_NombreExemplairesDisponibles { get; set; }
        #endregion

        #region Constructeur
        public Media(string p_titre, int p_numeroReference, int p_nombreExemplairesDisponibles)
        {
            m_Titre = p_titre;
            m_NumeroReference = p_numeroReference;
            m_NombreExemplairesDisponibles = p_nombreExemplairesDisponibles;
        }

        public Media()
        {
        }
        #endregion

        #region Public Méthodes : accesseurs
        /// <summary>
        /// Retourne le titre du média
        /// </summary>
        /// <returns>string</returns>
        public string GetTitre()
        {
            return m_Titre;
        }
        /// <summary>
        /// Retourne le nombre d'exemplaire du média
        /// </summary>
        /// <returns>string</returns>
        public int GetNExemplairesDispo()
        {
            return m_NombreExemplairesDisponibles;
        }
        /// <summary>
        /// Retourne le nulméro de référence du média
        /// </summary>
        /// <returns>string</returns>
        public int GetNumeroReference()
        {
            return m_NumeroReference;
        }
        #endregion

        #region Public Méthodes : Tools
        /// <summary>
        /// Affichage des infos du média
        /// </summary>
        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Titre : {m_Titre}");
            Console.WriteLine($"Numéro de Référence : {m_NumeroReference}");
            Console.WriteLine($"Nombre d'Exemplaires Disponibles : {m_NombreExemplairesDisponibles}");
        }
        /// <summary>
        /// Ajoute un exemplaire au nombre d'exemplaire du média
        /// </summary>
        public void AddExemplaire()
        {
            m_NombreExemplairesDisponibles++;
        }
        /// <summary>
        /// Retire un exemplaire au nombre d'exemplaire du média
        /// </summary>
        public void TakeOffExemplaire()
        {
            m_NombreExemplairesDisponibles--;
        }
        #endregion
    }

}