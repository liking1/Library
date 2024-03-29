﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        public String Autor, Cipher, Name, Year;

        public Book(String autor, String Cipher, String name, String year)
        {
            this.Autor = autor;
            this.Cipher = Cipher;
            this.Name = name;
            this.Year = year;
        }

        public object Clone()
        {
            return new Book(Autor, Cipher, Name, Year);
        }

        public void Print()
        {
            Console.WriteLine($"Author  : {Autor}," +
                $"\n Cipher : {Cipher}," +
                $"\n Name   : {Name}," +
                $"\n Year   : {Year}");
        }
    }

    class Library
    {
        private Book[] books;

        public Library(Book book)
        {
            this.AddBook(book);
        }
        public void AddBook(String autor, String Cipher, String name, String year)
        {

            Book[] tmp = (Book[])books.Clone();
            books = new Book[books.Length + 1];

            for (int i = 0; i < books.Length; i++)
            {
                books[i] = tmp[i];
            }
            Book book = new Book(autor, Cipher, name, year);
            books[books.Length - 1] = book;
        }
        public void AddBook(Book book)
        {
            if (this.books == null)
            {
                Console.WriteLine($"fdsfdfs");
                books = new Book[1];
                books[0] = (Book)book.Clone();
                return;
                
            }
            Book[] tmp = (Book[])books.Clone();
            books = new Book[books.Length + 1];

            for (int i = 0; i < books.Length - 1; i++)
            {
                books[i] = (Book)tmp[i].Clone();
            }
            Book book1 = book;
            books[books.Length - 1] = book1;


        }
        // +
        public void SortBooksByName()
        {
            Array.Sort(books, (e, e2) => { return e.Autor.CompareTo(e2.Autor); });
        }

        // +
        public void SortBooksByYear()
        {
            Array.Sort(books, (e, e2) => { return e.Year.CompareTo(e2.Year); });
            //SortBooksByName();
        }
        public void SearchBookByAuthor(String author)
        {
            int index = Array.FindIndex(books, (e) => { return e.Autor.Equals(author); });
            Console.WriteLine($" Book with same author : ");
            books[index].Print();
        }

        // +
        public void DeleteBook(String cipher)
        {
            int index = Array.FindIndex(books, (e) => { return e.Cipher.Equals(cipher); });
            Book[] tmp = new Book[books.Length];

            if (index != -1)
            {
                books.CopyTo(tmp, 0);
                Array.Resize(ref books, books.Length - 1);
            }
            else
            {
                return;
            }
            for (int i = books.Length - 1, j = i + 1; 0 <= i; --i)
            {
                if (index == j)
                {
                    --j;
                }
                books[i] = (Book)tmp[j].Clone();
                --j;
            }
        }

        // +
        public void Print()
        {
            foreach (var item in books)
            {
                item.Print();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("akaban", "eeee", "harry potter", "2001");
            Book book2 = new Book("ckaban", "12345", "shirds", "2005");
            Book book3 = new Book("dkaban", "123456", "uber", "2020");
            Book book4 = new Book("bkaban", "1234567", "delivery", "2015");

            Library library = new Library(book);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);

            library.Print();
            Console.WriteLine("----------- Enother operations ---------");
            //library.DeleteBook("12345"); // +
            //library.SearchBook("ckaban");
            ////library.sortBooksByYear(); +
            library.SortBooksByName(); // +

            library.SearchBookByAuthor("dkaban");
            library.Print();
        }
    }
}