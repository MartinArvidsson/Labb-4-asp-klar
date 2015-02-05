using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissa_hemliga_talet.Model
{
    public class SecretNumber
    {
        int MaxNumberOfGuesses = 7;
        int _number;
        List<int>  _previousGuesses;

        public bool CanMakeGuess
        {
            get;
        }

        public int Count
        {
            get;
        }

        public int? Number
        {
            get;
        }       
        enum Outcome{
            Indefinite,
            Low,
            High,
            Correct,
            NoMoreGuesses,
            PreviousGuess,
        }
        public Outcome outcome
        {
            get;
            set;
        }

        public  IEnumerable<int> PreviousGuesses
        {
            get;
        }
        public void Initialize(){

        }
        
        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(guess == _number)
            {
                outcome = Outcome.Correct;
            }
            else if(guess < _number)
            {
                outcome = Outcome.Low;
            }
            else if(guess > _number)
            {
                outcome = Outcome.High;
            }
            else if(guess == _previousGuesses.Contains(guess))
            {
                outcome = Outcome.PreviousGuess;
            }
            else if(guess == MaxNumberOfGuesses)
            {
                outcome = Outcome.NoMoreGuesses;
            }
        }

        public SecretNumber()
        {

        }

    }
}