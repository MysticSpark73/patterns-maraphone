using System;
using System.Collections.Generic;
using Patterns.Decorator.Items;

namespace Patterns.Decorator.Decorators
{
    public class BorrowableDecorator : MediaItemDecorator
    {
        protected List<string> _borrowers = new();
        
        public BorrowableDecorator(MediaItem item) : base(item)
        { }

        public void BorrowItem(string borrower)
        {
            if (_item.Copies <= 0) return;
            
            _item.Copies--;
            _borrowers.Add(borrower);
        }

        public void ReturnItem(string borrower)
        {
            if (_borrowers.Remove(borrower))
            {
                _item.Copies++;
            }
        }

        public override void Display()
        {
            base.Display();
            foreach (var borrower in _borrowers)
            {
                Console.Out.WriteLine("Borrower : {0}", borrower);
            }
        }
    }
}