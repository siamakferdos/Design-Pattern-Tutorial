﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Adapter
{
    /// <summary>
    /// MainApp startup class for Real-World 
    /// Decorator Design Pattern.
    /// </summary>
    class MainApp
    {

    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    abstract class LibraryItem
    {
        private int _numCopies;

        // Property
        public int NumCopies
        {
            get { return _numCopies; }
            set { _numCopies = value; }
        }

        public abstract void Display();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class Book : LibraryItem
    {
        private string _author;
        private string _title;

        // Constructor
        public Book(string author, string title, int numCopies)
        {
            this._author = author;
            this._title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", _author);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;

        // Constructor
        public Video(string director, string title,
          int numCopies, int playTime)
        {
            this._director = director;
            this._title = title;
            this.NumCopies = numCopies;
            this._playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", _director);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        // Constructor
        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    /// <summary>
    /// The 'ConcreteDecorator' class
    /// </summary>
    class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();

        // Constructor
        public Borrowable(LibraryItem libraryItem)
          : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();

            foreach (string borrower in borrowers)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }
}