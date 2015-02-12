using Gissa_hemliga_talet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gissa_hemliga_talet
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get 
            {
                return Session["secretnumber"] as SecretNumber ?? (SecretNumber)(Session["secretnumber"] = new SecretNumber()); //Om SecretNumber inte är null retneras ett värde annars skapas en session.
                 
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                int userGuess = int.Parse(Guessarea.Text);
                SecretNumber.MakeGuess(userGuess);

                if (SecretNumber.Outcome == Outcome.Low)
                {
                    PresentationArea.Text = "Du gissade för lågt!";
                }
                if (SecretNumber.Outcome == Outcome.High)
                {
                    PresentationArea.Text = "Du gissade för högt!";
                }
                if (SecretNumber.Outcome == Outcome.NoMoreGuesses)
                {
                    PresentationArea.Text = string.Format("Du har slut på gissningar :( svaret var {0}",SecretNumber.Number);
                    Guessarea.Enabled = false;
                    GuessButton.Visible = false;
                    ResetButton.Visible = true;
                }
                if (SecretNumber.Outcome == Outcome.Correct) 
                {
                    PresentationArea.Text = "Korrekt! du gissade det hemliga talet!";
                    Guessarea.Enabled = false;
                    GuessButton.Visible = false;
                    ResetButton.Visible = true;
                }
                if (SecretNumber.Outcome == Outcome.PreviousGuess)
                {
                    PresentationArea.Text = "Redan gissat det talet!";
                }

                //PresentationArea.Text = SecretNumber.Outcome.ToString();
                ResultPlaceholder.Visible=true;
                PreviousGuessesArea.Text = string.Join(" ",SecretNumber.PreviousGuesses);
                Console.Write(SecretNumber.PreviousGuesses);

                //PreviousGuessesArea.Text = ; //<- Tidigare gissningar ska presenteras här-
                //Kör en session där vad man skickar till SecretNumber.cs sparas.
                //Värdet kommer att presentras i en array i min label som  finns inuti default.aspx
                //Man kommer att behöva skicka ett värde till 7 värden har nåtts, isåfall ska de korrekta svaret skrivas ut.
                
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {           
            SecretNumber.Initialize();
        }
    }
}