using System;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using NUnit.Framework;
using log4net.Repository.Hierarchy;
using log4net;

namespace SpecFlowNunit
{
    [Binding]
    public class YandexMailTestSteps : BaseTest
    {
        LogInPage logInPage;
        User user;
        PostPage postPage;
        ToTypeLetterPage toTypeLetterPage;
        DraftsPage draftsPage;
        CurrentDraftLetterPage currentDraftLetterPage;
        SentPage sentPage;
        TrashBoxPage trashBoxPage;
        YandexDiskMainPage yandexDiskMainPage;
        TrashInYandexDiscPage trashInYandexDiscPage;

        private static readonly ILog logger = LogManager.GetLogger(typeof(YandexMailTestSteps));

        //log in        
        [Given(@"I have login page and post page")]
        public void GivenIHaveLoginPage()
        {            
            logInPage = new LogInPage();
            logger.Info("Login page is created");

            postPage = new PostPage();
            logger.Info("Post page is created");
        }

        [Given(@"I have a user's (.*) and (.*)")]
        public void GivenIHaveAUserSAnd(string Email, string Password)
        {
            user = new User(Email, Password);
            logger.Info("User with specific email and password is crested");
        }

        [When(@"^I (?:do login-procedure|login)$")]
        public void WhenIDoLogin_Procedure()
        {            
            logInPage.DoLogin(user);
            logger.Debug("User is logged in");
        }
        
        [Then(@"the exit-link will appeared")]
        public void ThenTheExit_LinkWillAppeared()
        {            
            postPage.CheckLogin();
            logger.Debug("Login is checked");
        }

        //type letter
        [Given(@"To type letter page")]
        public void GivenToTypeLetterPage()
        {
            toTypeLetterPage = new ToTypeLetterPage();
            logger.Info("Letter page is created");
        }
                
        [When(@"I type a (.*), a (.*) and a (.*) and click 'Save'")]
        public void WhenITypeAAAndAAndClick(string Email, string Theme, string Letter)
        {
            postPage.WriteLetterClick();
            toTypeLetterPage.WriteDraftAndSave(Email, Theme, Letter);
            logger.Debug("Dreft is saved");
        }


        [Then(@"Draft is appeared")]
        public void ThenDraftIsAppeared()
        {
            postPage.HaveDraftsFolderCheck();
            logger.Debug("Drafts folder is created");
        }

        //check letter and send it
        [Given(@"I have Drafts page and current draft page")]
        public void GivenIHaveDraftsPageAndCurrentDraftPage()
        {
            draftsPage = new DraftsPage();
            logger.Info("Drafts page is created");
            currentDraftLetterPage = new CurrentDraftLetterPage();
            logger.Info("Current draft page is created");
        }

        [When(@"I open darfts")]
        public void WhenIOpenDarfts()
        {
            postPage.OpenDrafts();
            logger.Debug("Drafts page is open");
        }

        [When(@"Click last draft")]
        public void WhenClickLastDraft()
        {
            draftsPage.DraftClickAndCheck();
            logger.Debug("Scecified draft is open");
        }

        [When(@"Check a (.*), a (.*) and a (.*) in it")]
        public void WhenCheckAAAndAInIt(string Email, string Theme, string Letter)
        {
            currentDraftLetterPage.CheckLetter(Email, Theme, Letter);
            logger.Debug("Draft is checked");
        }

        [Then(@"I send it")]
        public void ThenISendIt()
        {
            currentDraftLetterPage.SendLetter();
            logger.Debug("Draft is sent");
        }

        [Then(@"Check the drafts folder is disappeared")]
        public void ThenCheckTheDraftsFolderIsDisappeared()
        {
            postPage.HaveNotDraftsFolderCheck();
            logger.Debug("Drafts folder is deleted");
        }

        //clear sent folder
        [Given(@"Sent page")]
        public void GivenSentPage()
        {
            sentPage = new SentPage();
            logger.Info("Sent page is created");
        }

        [When(@"I open sent folder")]
        public void WhenIOpenSentFolder()
        {
            postPage.OpenSents();
            logger.Debug("Sent page is open");
        }

        [When(@"Check the sent letter is appeared")]
        public void WhenCheckTheSentLetterIsAppeared()
        {
            sentPage.LetterInSentsAfterSendingCheck();
            logger.Debug("Sent letter is checked and chosen");
        }

        [Then(@"I clear sent folder")]
        public void ThenIClearSentFolder()
        {
            sentPage.ClearSents();
            logger.Debug("Sent folder is cleared");
        }

        //clear tarsh folder
        [Given(@"Trash page")]
        public void GivenTrashPage()
        {
            trashBoxPage = new TrashBoxPage();
            logger.Info("Trash page is created");
        }

        [When(@"I open trash folder")]
        public void WhenIOpenTrashFolder()
        {
            postPage.OpenDeleted();
            logger.Debug("Trash folder is open");
        }

        [Then(@"I clear tarsh folder")]
        public void ThenIClearTarshFolder()
        {
            trashBoxPage.ClearTrashBox();
            logger.Debug("Trash folder is cleared");
        }

        [Then(@"Exit")]
        public void ThenExit()
        {
            postPage.Exit();
            logger.Debug("User logged out");
        }


        //delete and restore picture in yandex disk        
        [Given(@"Yandex disk page and trash in yandex disk page")]
        public void GivenYandexDiskPageAndTrashInYandexDiskPage()
        {
            yandexDiskMainPage = new YandexDiskMainPage();
            trashInYandexDiscPage = new TrashInYandexDiscPage();
        }

        [When(@"I open yandex disk")]
        public void WhenIOpenYandexDisk()
        {
            postPage.OpenDisk();
        }

        [Then(@"I delete a picture")]
        public void ThenIDeleteAPicture()
        {
            yandexDiskMainPage.PicturesDelete();
        }

        [Then(@"I restore it")]
        public void ThenIRestoreIt()
        {
            trashInYandexDiscPage.PictureRestore();
        }

    }
}
