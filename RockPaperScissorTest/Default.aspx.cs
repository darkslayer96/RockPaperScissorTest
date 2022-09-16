using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RockPaperScissorTest.Models;

namespace RockPaperScissorTest
{
    public enum Choice { rock, paper, scissors };

    [Serializable()]
    public partial class _Default : Page
    {
        protected Choice playerOption { get; set; }
        protected Choice botOption { get; set; }
        public List<Results> listResults;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                listResults = (List<Results>)ViewState["listResults"];
                return;

            }
            else
            {
                //set viewstate
                ViewState["Lose"] = 0;
                ViewState["Win"] = 0;
                ViewState["Draw"] = 0;
                listResults = new List<Results>();
            }



        }

        protected void rockButton_Click(object sender, ImageClickEventArgs e)
        {
            MakeGameChoices(Choice.rock);
            DisplayResult();
        }

        protected void paperButton_Click(object sender, ImageClickEventArgs e)
        {
            MakeGameChoices(Choice.paper);
            DisplayResult();
        }

        protected void scissorsButton_Click(object sender, ImageClickEventArgs e)
        {
            MakeGameChoices(Choice.scissors);
            DisplayResult();
        }

        private void DisplayResult()
        {
              Results result = new Results();
            //return viewstates
              result.Win = (int)ViewState["Win"];
              result.Draw = (int)ViewState["Draw"];
              result.Lose = (int)ViewState["Lose"];

            if (listResults == null)
            {
                listResults = new List<Results>();
            }
          

        result.PlayerOption = playerOption;
            result.BotOption = botOption;

            if (playerOption == botOption) 
            {

                result.Draw += 1;
                ViewState["Draw"] = result.Draw;
                resultLabel.Text = "DRAW!";
            }
            else if (
                (playerOption == Choice.rock && botOption == Choice.scissors)
                ||
                (playerOption == Choice.paper && botOption == Choice.rock)
                ||
                (playerOption == Choice.scissors && botOption == Choice.paper)
                )
            {

          
                result.Win += 1;
                ViewState["Win"] = result.Win;
                resultLabel.Text = "WIN!";
            }
            else 
            {
                result.Lose += 1;
                ViewState["Lose"] = result.Lose;
                resultLabel.Text = "LOSE!";
            }

            listResults.Add(result);
            ViewState["listResults" ]= listResults;
        }


        private void MakeGameChoices(Choice player)
        {
            playerOption = player;
            yourChoiceImage.ImageUrl = GameChoiceToAssetURL(playerOption);

            botOption = ChooseComputerResponse();
            computerChoiceImage.ImageUrl = GameChoiceToAssetURL(botOption);
        }

        private Choice ChooseComputerResponse()
        {
            Choice[] choices = { Choice.rock, Choice.paper, Choice.scissors };
            Random rnd = new Random();
            int randomResult = rnd.Next(1, 4);
            return choices[randomResult - 1];
        }


        private string GameChoiceToAssetURL(Choice gc)
        {
            string PREFIX = "Assets/";

            if (gc == Choice.rock)
            {
                return PREFIX + "rock.png";
            }
            else if (gc == Choice.paper)
            {
                return PREFIX + "paper.png";
            }
            else
            {
                return PREFIX + "scissors.png";
            }
        }
    }
}