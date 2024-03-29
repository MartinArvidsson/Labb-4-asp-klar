﻿using System;
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
        private const int MaxNumberOfGuesses = 7; // Antal gissningar

        private int _number; //Vad som ska bli ett randomtal
        List<int> _previousGuesses; // Listan där gissnignarna ska sparas, storleken är maxgisnningar

        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize(); // Startar initialize när klassen körs
        }
        public void Initialize()
        {
            _previousGuesses.Clear(); //  Tömmer listan med tidigare gissningar
            Random random = new Random();// Ger _number ett randomtal
            _number = random.Next(1, 101);// Ger _number ett randomtal
            Outcome = Outcome.Indefinite;
        }
        public Outcome Outcome
        {
            get;
            private set;
        }
        public int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        }
        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses && !_previousGuesses.Contains(_number);
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
        public IReadOnlyList<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }

        }
        public Outcome MakeGuess(int guess)
        {
            if (!CanMakeGuess)
            {
                return Outcome = Outcome.NoMoreGuesses;
            }

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_previousGuesses.Contains(guess))
            {
                return Outcome = Outcome.PreviousGuess;
            }
            else
            {
                _previousGuesses.Add(guess);

                if (guess == _number)
                {
                    Outcome = Outcome.Correct;
                }
                else if (guess < _number)
                {
                    Outcome = Outcome.Low;
                }
                else
                {
                    Outcome = Outcome.High;
                }

                return Outcome;
            }
        }
    }
}