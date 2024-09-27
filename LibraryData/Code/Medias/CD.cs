using System;

namespace Data.Code.Medias
{
    /// <summary>
    /// Classe implémentant le média de type CD
    /// </summary>
    public class Cd : Media
    {
        #region Privates Members
        public string m_Artiste { get; set; }
        #endregion

        #region Constructeur
        public Cd(string p_titre, int p_numeroReference, int p_nombreExemplairesDisponibles, string p_artiste)
            : base(p_titre, p_numeroReference, p_nombreExemplairesDisponibles)
        {
            m_Artiste = p_artiste;
        }
        #endregion

        #region Public Méthodes : accesseurs
        /// <summary>
        /// Retourne l'artiste du CD
        /// </summary>
        /// <returns>string</returns>
        public string GetArtiste()
        {
            return m_Artiste;
        }
        #endregion

        #region Public Méthodes : Tools
        /// <summary>
        /// Affiche les Infos sur le CD
        /// </summary>
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artiste : {m_Artiste}");
        }
        #endregion
    }

}