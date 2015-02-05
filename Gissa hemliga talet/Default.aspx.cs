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
            get { return Session["secretnumber"] as SecretNumber ?? (SecretNumber)(Session["secretnumber"] = new SecretNumber()); }
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
                    PresentationArea.Text = "Du har slut på¨gissningar :(";
                }
                if (SecretNumber.Outcome == Outcome.Correct)
                {
                    PresentationArea.Text = "Korrekt! du gissade det hemliga talet!";
                }
                if (SecretNumber.Outcome == Outcome.PreviousGuess)
                {
                    PresentationArea.Text = "Redan gissat det talet :p";
                }

                PresentationArea.Text = SecretNumber.Outcome.ToString();
                PresentationArea.Visible = true;

                //Kör en session där vad man skickar till SecretNumber.cs sparas.
                //Värdet kommer att presentras i en array i min label som  finns inuti default.aspx
                //Man kommer att behöva skicka ett värde till 7 värden har nåtts, isåfall ska de korrekta svaret skrivas ut.
                

                 
            }
        }
    }
}