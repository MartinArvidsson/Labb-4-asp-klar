using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Gissa_hemliga_talet.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess,
    }
    public class SecretNumber
    {
        private const int MaxNumberOfGuesses = 7;
        private int _number;
        List<int>  _previousGuesses = new List<int>(MaxNumberOfGuesses);

        public void Initialize()
        {
            _previousGuesses.Clear();
            Random random = new Random();
            _number = random.Next(1, 101);
            Outcome = Outcome.Indefinite;
        }
        public Outcome Outcome
        {
            get;
            private set;
        }
        
        public bool CanMakeGuess
        {
            get{
                if(_previousGuesses[6] != MaxNumberOfGuesses)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int Count
        {
            get
            {
                return _previousGuesses.Count;
            }


        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
                
            }
        }       
        public  IReadOnlyList<int> PreviousGuesses
        {
            get { return _previousGuesses.AsReadOnly(); }
            
        }       
        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (_previousGuesses.Contains(guess))
            {
                Outcome = Outcome.PreviousGuess;
            }
            else if(guess == _number)
            {
                Outcome = Outcome.Correct;
                //Gissat korrekt, inga fler gissningar ska gå att göra, resetknappen ska synas m.m..
            }
            else if(guess < _number)
            {
                Outcome = Outcome.Low;
            }
            else if(guess > _number)
            {
                Outcome = Outcome.High;
            }
            else if(guess == MaxNumberOfGuesses)
            {
                Outcome = Outcome.NoMoreGuesses;
            }
            return Outcome;
        }

        public SecretNumber()
        {
            Initialize();
        }

    }
}