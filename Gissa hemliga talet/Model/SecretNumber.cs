using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissa_hemliga_talet.Model
{
    public class SecretNumber
    {
        private const int MaxNumberOfGuesses = 7;
        private int _number;
        List<int>  _previousGuesses;

        public void Initialize()
        {
            Random random = new Random();
            int _number = random.Next(1, 100);
            _previousGuesses.Clear();
            outcome = Outcome.Indefinite;
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
           public get
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
            get { _previousGuesses.Last }

            set{outcome = _previousGuesses.Last }
        }

        public  IEnumerable<int> PreviousGuesses
        {
            get;
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
            else if(_previousGuesses.Contains(guess))
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