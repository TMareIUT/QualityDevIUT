using System;

namespace Data.Code.Medias
{
    /// <summary>
    /// Classe implémentant le média de type DVD
    /// </summary>
    public class Dvd : Media
    {
        #region Privates Members
        public int m_Duree { get; set; }
        #endregion

        #region Constructeur
        public Dvd(string p_titre, int p_numeroReference, int p_nombreExemplairesDisponibles, int p_duree)
            : base(p_titre, p_numeroReference, p_nombreExemplairesDisponibles)
        {
            m_Duree = p_duree;
        }
        #endregion

        #region Public Méthodes : accesseurs
        /// <summary>
        /// Retourne la durée du DVD
        /// </summary>
        /// <returns>string</returns>
        public int GetDuree()
        {
            return m_Duree;
        }
        #endregion

        #region Public Méthodes : Tools
        /// <summary>
        /// Retourne les infos du DVD
        /// </summary>
        /// <returns>string</returns>
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Durée : {m_Duree} minutes");
        }
        #endregion
    }
}