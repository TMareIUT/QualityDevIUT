using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.LibraryManager;
using Data.Code.Medias;
using System.Linq;

namespace LibraryTTD
{
    [TestClass]
    public class LibraryTests
    {
        #region private members

        private Library m_Library;
        private string m_MediaName;
        private string m_UserName;
        private int m_NbExemplaire;
        private Media m_MediaTest;

        #endregion

        [TestInitialize]
        public void Init()
        {
            m_Library = new Library();
            m_MediaName = "Media de test";
            m_MediaTest = new Media(m_MediaName, 1502, 17);
            m_UserName = "Tony Maré";
            m_NbExemplaire = 17;
        }

        [TestCleanup]
        public void Clean()
        {
            m_Library = new Library();
        }

        [TestMethod]
        public void AddMediaOnLibrary()
        {
            Init();
            m_Library.AjouterMedia(m_MediaTest);
            Media v_mediaOfLibrary = m_Library[1502];

            Assert.AreEqual(1, m_Library.GetMedias().Count);
            Assert.AreEqual(m_MediaTest.GetTitre(), v_mediaOfLibrary.GetTitre());
            Assert.AreEqual(m_MediaTest.GetNumeroReference(), v_mediaOfLibrary.GetNumeroReference());
            Assert.AreEqual(m_MediaTest.GetNExemplairesDispo(), v_mediaOfLibrary.GetNExemplairesDispo());
        }

        [TestMethod]
        public void RemoveMediaOnLibrary()
        {
            AddMediaOnLibrary();
            m_Library.RetirerMedia(m_MediaTest);
            Assert.AreEqual(0, m_Library.GetMedias().Count);
        }

        [TestMethod]
        public void CreateEmprunt()
        {
            AddMediaOnLibrary();
            m_Library.EmprunterMedia(m_Library.RechercherMediaParTitre(m_MediaName).First(), m_UserName);

            Assert.AreEqual(1, m_Library.GetEmprunts().Count);
            Assert.AreEqual(m_UserName, m_Library.GetEmprunts().First().GetNomUtilisateur());
            Assert.AreEqual(m_MediaName, m_Library.GetEmprunts().First().GetMediaName());
            Assert.AreEqual(m_NbExemplaire - 1, m_Library.RechercherMediaParTitre(m_MediaName).First().GetNExemplairesDispo());
        }

        [TestMethod]
        public void RemoveEmprunt()
        {
            CreateEmprunt();

            m_Library.RetournerEmprunt(m_Library[m_Library.RechercherEmpruntParTitre(m_MediaName, m_UserName).First().GetMediaNumRef()]);

            Assert.AreEqual(true, m_Library.GetEmprunts().First().IsRetourned());
            Assert.AreEqual(m_NbExemplaire, m_Library.RechercherMediaParTitre(m_MediaName).First().GetNExemplairesDispo());
        }

        [TestMethod]
        public void SaveLibrary()
        {
            AddMediaOnLibrary();
            CreateEmprunt();

            m_Library.SaveLibrary();
        }

        [TestMethod]
        public void LoadLibrary()
        {
            SaveLibrary();
            Clean();

            m_Library.LoadLibrary();

            //Verification Medias
            Media v_mediaOfLibrary = m_Library[1502];
            Assert.AreEqual(1, m_Library.GetMedias().Count);
            Assert.AreEqual(m_MediaTest.GetTitre(), v_mediaOfLibrary.GetTitre());
            Assert.AreEqual(m_MediaTest.GetNumeroReference(), v_mediaOfLibrary.GetNumeroReference());
            Assert.AreEqual(m_NbExemplaire - 1, v_mediaOfLibrary.GetNExemplairesDispo());
            //Verification Emprunts
            Assert.AreEqual(1, m_Library.GetEmprunts().Count);
            Assert.AreEqual(m_UserName, m_Library.GetEmprunts().First().GetNomUtilisateur());
            Assert.AreEqual(m_MediaName, m_Library.GetEmprunts().First().GetMediaName());
            Assert.AreEqual(m_NbExemplaire - 1, m_Library.RechercherMediaParTitre(m_MediaName).First().GetNExemplairesDispo());

        }
    }
}