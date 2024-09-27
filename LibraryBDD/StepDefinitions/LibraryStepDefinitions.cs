using Code.LibraryManager;
using Data.Code;
using Data.Code.Medias;
using TechTalk.SpecFlow.Assist;

namespace LibraryBDD.StepDefinitions
{
    [Binding]
    public sealed class LibraryStepDefinitions
    {
        private Library m_Library;
        private Media m_MediaTest;
        private Media m_toCompare;

        [Given("Create Library")]
        public void GivenCreateLibrary()
        {
            m_Library = new Library();
        }

        [Given("Add this media :")]
        public void GivenAddThisMedia(Table media)
        {
            m_MediaTest = media.CreateInstance<Media>();
        }
        [When("Add this media in library")]
        public void WhenAddThisMediaInLibrary()
        {
            m_Library.AjouterMedia(m_MediaTest);
        }

        [Then("The library contain media :")]
        public void ThenLibraryContainsMedia(Table media)
        {
            m_toCompare = media.CreateInstance<Media>();
            Assert.Equal(m_Library.GetMedias().FirstOrDefault().m_Titre, m_toCompare.m_Titre);
            Assert.Equal(m_Library.GetMedias().FirstOrDefault().m_NumeroReference, m_toCompare.m_NumeroReference);
            Assert.Equal(m_Library.GetMedias().FirstOrDefault().m_NombreExemplairesDisponibles, m_toCompare.m_NombreExemplairesDisponibles);
        }

        [When("Remove this media :")]
        public void WhenRemoveThisMedia(Table media)
        {
            Media m_MediaToRemove = media.CreateInstance<Media>();
            m_Library.RetirerMedia(m_Library[m_MediaToRemove.GetNumeroReference()]);
        }

        [Then("Library are empty")]
        public void ThenLibraryAreEmpty()
        {           
            Assert.Equal(0, m_Library.GetMedias().Count());
        }

        [When("Loan media with m_NumeroReference is (.*) with user (.*)")]
        public void WhenLoanMedia(int numRef, string user)
        {
            Media mediaEmprunte = m_Library[numRef];
            m_Library.EmprunterMedia(mediaEmprunte, user);
        }
        
        [Then("m_NombreExemplairesDisponibles of (.*) is (.*) in library")]
        public void ThenNumExemplaireHasReduced(int numRef, int number)
        {
            Media mediaEmprunte = m_Library[numRef];
            Assert.Equal(mediaEmprunte.m_NombreExemplairesDisponibles, number);
        }

        [Then("Loans contain one media with m_NumeroReference is (.*) and user is (.*)")]
        public void ThenLoansContainThisMedia(int numRef, string user)
        {
            Emprunt m_Emprunt = m_Library.RechercherEmpruntParNumeroDeReference(numRef, user).FirstOrDefault();
            if (m_Emprunt == null)
                throw new Exception();
            Assert.Equal(m_Emprunt.m_MediaNumRef, numRef);
        }

        [When("(.*) return media whose m_NumeroReference is (.*)")]
        public void WhenReturnLoan(string user, int numRef)
        {
            m_Library.RetournerEmprunt(m_Library[m_Library.RechercherEmpruntParNumeroDeReference(numRef, user).First().GetMediaNumRef()]);            
        }

        [Then("the loan of (.*) with m_NumeroReference (.*) is returned")]
        public void ThenLoanIsReturn(string user, int numRef)
        {
            Emprunt m_Emprunt = m_Library.RechercherEmpruntParNumeroDeReference(numRef, user).FirstOrDefault();
            if (m_Emprunt == null)
                throw new Exception();
            Assert.True(m_Emprunt.IsRetourned());
        }
    }
}